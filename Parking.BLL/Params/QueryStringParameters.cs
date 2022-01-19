﻿namespace Parking.BLL.Params;

public abstract class QueryStringParameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 50;
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }

    public string OrderBy { get; set; } = "id";
    public bool Asending { get; set; }
}