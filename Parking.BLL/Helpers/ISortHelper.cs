﻿namespace Parking.BLL.Helpers;

public interface ISortHelper<T>
{
    IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString,bool ascending);
}