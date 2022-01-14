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
    protected IEnumerable<T> Entities { get; set; }
    public async Task LoadData()
    {
        var res = (await _httpClient.GetFromJsonAsync<List<T>>(String.Format(Routes.GetRoute("Get"),CurrentPage,PageSize,OrderField))).ToList();
        if (res.Any())
        {
            Entities = res;
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
}