using Microsoft.EntityFrameworkCore;
using RESTing.BusinessEntities;
using RESTing.DataAccess.DataContext;
using RESTing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTing.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RESTingContext _context;

        public UserRepository(RESTingContext context)
        {
            this._context = context;
        }

        public async Task Add(RegisteredUser registeredUser)
        {
            try
            {
                registeredUser.UserID = 0;
                await _context.RegisteredUsers.AddAsync(registeredUser);
            }catch(Exception ex)
            {
                // Log and handle error...
                throw new Exception("An error occured while registering user:", ex);
            }
        }

        public async Task<long> GetLoggedUserID(RegisteredUser registeredUser)
        {
            var userID = await _context.RegisteredUsers
                        .Where(u => u.UserName == registeredUser.UserName)
                        .Where(u => u.Password == registeredUser.Password)
                        .Select( uid => uid.UserID )
                        .FirstOrDefaultAsync();
            return userID;
        }

        public async Task<bool> IsValidEmailId(RegisteredUser registeredUser)
        {
            var userCount = await _context.RegisteredUsers
                        .Where(u => u.EmailId == registeredUser.EmailId)
                        .CountAsync();
            return userCount > 0;
        }

        public async Task<bool> IsValidUser(RegisteredUser registeredUser)
        {
            var userExists = await GetLoggedUserID(registeredUser);
            return userExists > 0;
        }
    }
}
