using Parking.BLL.Params;

namespace Parking.BLL.Helpers;

public class PageHelper<T>:List<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public PageHelper(List<T> items, int count, QueryStringParameters parameters)
    {
        TotalCount = count;
        PageSize = parameters.PageSize;
        CurrentPage = parameters.PageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)parameters.PageSize);

        AddRange(items);
    }

    public static PageHelper<T> ToPagedList(IEnumerable<T> source, QueryStringParameters parameters)
    {
        var count = source.Count();
       var items = source.Take(((parameters.PageNumber - 1) * parameters.PageSize)..parameters.PageSize).ToList();

        return new PageHelper<T>(items, count, parameters);
    }
}