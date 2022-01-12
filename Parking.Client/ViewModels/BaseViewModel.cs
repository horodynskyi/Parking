using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public class BaseViewModel<T>:IBaseViewModel<T>
{  
    protected List<T>? _cars;
    protected HttpClient _httpClient;
    protected Routes Routes { get; set; }

    public BaseViewModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
    }
    protected int CurrentPage { get; set; } = 1;
    protected int PageSize { get; set; } = 5;
    protected IEnumerable<T> Entities { get; set; }
    public async Task LoadData()
    {
        Entities = (await _httpClient.GetFromJsonAsync<List<T>>(Routes.GetRoute("Get"))).ToList();
    }
    public async Task<IEnumerable<T>> Get()
    {
        if (Entities != null) return Entities.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
        else
        {
            await LoadData();
            return Entities.Skip((PageSize - 1) * PageSize).Take(PageSize).ToList();
        }
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