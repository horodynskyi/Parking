﻿namespace Parking.DAL.Models;

public class Tariff:IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public float? Price { get; set; }
}