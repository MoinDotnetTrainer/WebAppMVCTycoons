using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Services
{
    public class UsersServiceSp : IUsersSp
    {
        public readonly AppDb _db;
        public UsersServiceSp(AppDb db)
        {
            _db = db;
        }

        public async Task<IList<Users>> GetUsers()
        {
            var res = new List<Users>();
            try
            {
                // raw sql

                //string Query = "Select * from UsersTbl";
                string Sp = "Exec Sp_GetUsers";
                res = await _db.users.FromSqlRaw(Sp).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public async Task<bool> AddUsers(Users data)
        {
            string sp = "exec Sp_InsertUsers @Name,@Email,@Password,@Dob,@Age,@gender";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter("@Name",data.Name),
            new SqlParameter("@Email",data.Email),
            new SqlParameter("@Password",data.Password),
            new SqlParameter("@Dob",data.Dob),
            new SqlParameter("@Age",data.Age),
            new SqlParameter("@gender",data.Gender)
            };

            var res = await _db.Database.ExecuteSqlRawAsync(sp, para.ToArray());
            if (res > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<Users> GetUserByID(int id)
        {
            string sp = "exec Sp_GetUsersByID @id";
            var res =  _db.users.FromSqlRaw(sp, new SqlParameter("@ID", id)).AsEnumerable().FirstOrDefault();
            return res;
        }

        public async Task<bool> UpdateUsers(Users data)
        {
            string sp = "exec Sp_UpdaeUsers @Name,@Email,@Password,@Dob,@Age,@gender,@ID";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter("@Name",data.Name),
            new SqlParameter("@Email",data.Email),
            new SqlParameter("@Password",data.Password),
            new SqlParameter("@Dob",data.Dob),
            new SqlParameter("@Age",data.Age),
            new SqlParameter("@gender",data.Gender),
             new SqlParameter("@ID",data.ID)
            };

            var res = await _db.Database.ExecuteSqlRawAsync(sp, para.ToArray());
            if (res > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> DeleteUsers(int id)
        {
            string sp = "exec Sp_DeleteUsersByID @ID";
            var res = await _db.Database.ExecuteSqlRawAsync(sp, new SqlParameter("@ID", id));

            if (res > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> ValidateUser(Login data) { 
        string sp = "exec Sp_ValidateUser @Email,@Password";
            List<SqlParameter> para = new List<SqlParameter>() {
            new SqlParameter("@Email",data.Email),
            new SqlParameter("@Password",data.Password)
            };
            var res = await _db.Database.ExecuteSqlRawAsync(sp, para.ToArray());
            if (res > 0)
            {
                return true;
            }
            else return false;  
        }
    }
}
