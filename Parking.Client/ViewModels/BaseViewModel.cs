using System.Reflection;
using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public class BaseViewModel<T>:IBaseViewModel<T>
{  
    protected HttpClient _httpClient;
    protected Routes Routes { get; set; }

    public BaseViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public int CurrentPage { get; set; } = 1;
    protected int PageSize { get; set; } = 5;
    protected string OrderField { get; set; } = "id";
    protected List<T> Entities { get; set; }
    public async Task LoadData()
    {
        var res = (await _httpClient.GetFromJsonAsync<List<T>>(String.Format(Routes.GetRoute("Get"),CurrentPage,PageSize,OrderField))).ToList();
        if (res.Any())
        {
            Entities = await GeRefModelType(res);
        }
        else {Entities = new List<T>();
            CurrentPage--;
        }
    }
    public async Task<IEnumerable<T>> Get()
    {
        if (Entities != null) return Entities.ToList();
        else
        {
            await LoadData();
            return Entities.ToList();
        }
        
    }
    public async Task<T> GetById(long id)
    {
        var res = await _httpClient.GetFromJsonAsync<T>(String.Format(Routes.GetRoute("GetById"), id));
        return (await GeRefModelType(new List<T>() {res})).FirstOrDefault();
    }

    public async Task<IEnumerable<T>> NextPage()
    {
        CurrentPage++;
        await LoadData();
        return await Get();
    }

    public async Task<IEnumerable<T>> PrevPage()
    {
        CurrentPage = CurrentPage <= 1 ? CurrentPage:CurrentPage-1;
        await LoadData();
        return await Get();
    }

    public async Task Create(T entity)
    {
        await _httpClient.PostAsJsonAsync("https://localhost:7164/api/car", entity);
    }

    public async Task Update(T entity)
    {
        await _httpClient.PutAsJsonAsync("https://localhost:7164/api/car", entity);
    }

    private async Task<List<T>> GeRefModelType(List<T> entities)
    {
        var props = typeof(T).GetProperties();

        foreach (var prop in props)
        {
            if (prop.PropertyType.IsClass && !(prop.GetValue(entities[0], null) is string))
            {
                var methodInfo = GetType().GetMethod("GetReferencesViewModelType");
                var methodConstracted = methodInfo.MakeGenericMethod(Type.GetType($"Parking.Client.Data.{prop.Name}"));
                object[] typeArgs = {prop.Name};
                var viewModel = methodConstracted.Invoke(this, typeArgs);
                foreach (var entity in entities)
                {
                    var entityId = entity.GetType().GetProperties().Where(x => x.Name.EndsWith("Id") && x.Name.Length>2).FirstOrDefault();
                    object[] refId = {(long) entityId.GetValue(entity, null)};
                    if (viewModel != null)
                    {
                        var insItem = (Task) viewModel.GetType().GetMethod("GetById").Invoke(viewModel, refId);
                        if (insItem != null)
                        {
                            await insItem.ConfigureAwait(false);
                            var resultProperty = insItem.GetType().GetProperty("Result");
                            prop.SetValue(entity, resultProperty?.GetValue(insItem));
                        }
                    }
                }
            }
        }
        return entities;
    }
    public IBaseViewModel<TEntity>? GetReferencesViewModelType<TEntity>(string propName)
    {
        var proprerties = typeof(T).GetProperties();
        foreach (var prop in proprerties)
        {
            if (prop.Name.Equals(propName))
            {
                Type viewModelType = Type.GetType($"Parking.Client.ViewModels.{propName}ViewModel");
                return (BaseViewModel<TEntity>) Activator.CreateInstance(viewModelType, _httpClient);
            }
        }
        return null;
    }

    
}