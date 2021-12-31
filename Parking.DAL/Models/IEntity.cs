namespace Parking.DAL.Models;

public interface IEntity<TId>
{
    TId Id { get; set; }
}