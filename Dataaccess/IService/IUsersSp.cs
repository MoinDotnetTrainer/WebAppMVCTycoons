using Dataaccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.IService
{
    public interface IUsersSp
    {
        Task<IList<Users>> GetUsers();

        Task<bool> AddUsers(Users data);
        Task<Users> GetUserByID(int id); // only the record of the given id 
        Task<bool> UpdateUsers(Users data);
        Task<bool> DeleteUsers(int id);
        Task<bool> ValidateUser(Login data);
    }
}
