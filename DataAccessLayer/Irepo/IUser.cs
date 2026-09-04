using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Irepo
{
    public interface IUser
    {
        // abstrct method , multiple inheritance
        // skeleton of curd ops

        Task<bool> AddUsers(Users data);

        // async & await
    }
}
