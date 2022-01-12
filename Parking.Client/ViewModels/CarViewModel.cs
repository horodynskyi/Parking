using System.Diagnostics;
using System.Text.Json.Serialization;
using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public class CarViewModel:BaseViewModel<Car>,ICarViewModel
{
    public CarViewModel(HttpClient httpClient) : base(httpClient)
    {
        Routes = new Routes();
        Routes.AddRoute("Get","https://localhost:7164/api/car");
        Routes.AddRoute("Update","https://localhost:7164/api/car");
        Routes.AddRoute("Create","https://localhost:7164/api/car");
    }
}