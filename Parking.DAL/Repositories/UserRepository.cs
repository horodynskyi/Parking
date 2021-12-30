using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.DAL.Repositories;

public class UserRepository:GenericRepository<User,long>,IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
        
    }
    
}