using RESTing.BusinessEntities;
using RESTing.Common.DTOs;
using RESTing.Common.Encryption;
using RESTing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RESTing.BusinessComponents
{
    public class UserComponent
    {
        private readonly IUserRepository _usrRepo;

        public UserComponent(IUserRepository userRepository)
        {
            this._usrRepo = userRepository;
        }

        public async Task<ComponentResponse> RegisterNewUser(RegisteredUser newUser)
        {
            var emailAlreadyExists = await _usrRepo.IsValidEmailId(newUser);
            var response = new ComponentResponse();
            if(emailAlreadyExists)
            {
                response.TransactionSuccess = false;
                response.Message = "Email Already Exists";
            }
            else
            {
                newUser.CreateDate = DateTime.Now;
                newUser.Password = Encryptor.Encrypt(newUser.Password);
                try
                {
                    await _usrRepo.Add(newUser);
                    response.TransactionSuccess = true;
                    response.Message = "User Successfully Created";
                }
                catch (Exception)
                {

                    response.TransactionSuccess = false;
                    response.Message = "User was not successfully Created";
                    throw;
                }
            }
            return response;
        }
    }
}
