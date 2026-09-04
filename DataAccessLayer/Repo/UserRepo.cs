using DataAccessLayer.Irepo;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repo
{
    public class UserRepo : IUser
    {
        public readonly Appdb _db;
        public UserRepo(Appdb db)
        {
            _db = db;
        }
        public async Task<bool> AddUsers(Users data)
        {
            await _db.users.AddAsync(data);
            int res = await _db.SaveChangesAsync();
            // insert and saving
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}
