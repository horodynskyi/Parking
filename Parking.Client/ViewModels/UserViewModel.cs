using Parking.Client.Data;

namespace Parking.Client.ViewModels;

public class UserViewModel:BaseViewModel<User>,IUserViewModel
{
    public UserViewModel(HttpClient httpClient) : base(httpClient)
    {
        Routes = new Routes();
        Routes.AddRoute("Get","https://localhost:7164/api/user");
        Routes.AddRoute("Update","https://localhost:7164/api/user");
        Routes.AddRoute("Create","https://localhost:7164/api/user");
    }
}