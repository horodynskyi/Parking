using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
namespace Parking.BLL.Helpers;

public class SortHelper<T>:ISortHelper<T>
{
    public IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString,bool ascending)
    {
        if (!entities.Any())
            return entities;

        if (string.IsNullOrWhiteSpace(orderByQueryString))
        {
            return entities;
        }

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;
            var sortingOrder = ascending ? "ascending" : "descending";
            orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        return entities.OrderBy(orderQuery);
    }
}