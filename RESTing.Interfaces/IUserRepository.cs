using RESTing.BusinessEntities;
using System;
using System.Threading.Tasks;

namespace RESTing.Interfaces
{
    public interface IUserRepository
    {
        Task Add(RegisteredUser registeredUser);
        Task<bool> IsValidUser(RegisteredUser registeredUser);
        Task<bool> IsValidEmailId(RegisteredUser registeredUser);
        Task<long> GetLoggedUserID(RegisteredUser registeredUser);
    }
}
