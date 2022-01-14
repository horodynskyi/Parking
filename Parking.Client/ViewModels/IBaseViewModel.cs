using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public interface IBaseViewModel<T>
{
    int CurrentPage { get; set; }
    Task LoadData();
    Task<IEnumerable<T>> Get();
    Task Create(T entity);
    Task<IEnumerable<T>> NextPage();
    Task<IEnumerable<T>> PrevPage();
    Task Update(T entity);
}