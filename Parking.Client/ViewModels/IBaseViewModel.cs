using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public interface IBaseViewModel<T>
{
    Task LoadData();
    Task<IEnumerable<T>> Get();
    Task Create(T entity);
    Task Update(T entity);
}