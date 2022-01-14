using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public class ArrivalViewModel:BaseViewModel<Arrival>,IArrivalViewModel
{
    public ArrivalViewModel(HttpClient httpClient) : base(httpClient)
    {
        Routes = new Routes();
        Routes.AddRoute("Get","https://localhost:7164/api/arrival");
        Routes.AddRoute("Post","https://localhost:7164/api/arrival");
        Routes.AddRoute("Update","https://localhost:7164/api/arrival");
        Routes.AddRoute("Delete","https://localhost:7164/api/arrival");
        Routes.AddRoute("Put","https://localhost:7164/api/arrival");
    }
}