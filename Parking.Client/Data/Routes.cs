namespace Parking.Client.Data;

public class Routes
{
    private Dictionary<string, string> DictRoutes { get; set; } = new();

    public void AddRoute(string key,string route)
    {
        DictRoutes.Add(key,route);
    }

    public string GetRoute(string key)
    {
        string route="";
        if (DictRoutes.TryGetValue(key, out route))
        {
            return route;
        };
        return route;
    }
    
}