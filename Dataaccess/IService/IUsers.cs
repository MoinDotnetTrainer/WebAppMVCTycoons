using Dataaccess.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.IService
{
    public interface IUsers
    {
        // abstract method , multiple inheritance
        // Curd Ops and Login

        Task<bool> AddUsers(Users data);
        Task<IList<Users>> GetUsers();  // list of data(all recods)
        Task<Users> GetUserByID(int id); // only the record of the given id 
        Task UpdateUsers(Users data);
        Task DeleteUsers(int id);
        Task<bool> ValidateUser(Login data);
    }
}
