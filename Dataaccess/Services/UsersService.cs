using Dataaccess.IService;
using Dataaccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Services
{
    public class UsersService : IUsers
    {
        public readonly AppDb _db;
        public UsersService(AppDb db)
        {
            _db = db;
        }

        public async Task<bool> AddUsers(Users data)
        {
            try
            {
                // 1. Validate input
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                if (string.IsNullOrWhiteSpace(data.Name))
                    throw new ArgumentException("Name is required.");

                if (string.IsNullOrWhiteSpace(data.Email))
                    throw new ArgumentException("Email is required.");

                if (string.IsNullOrWhiteSpace(data.Password))
                    throw new ArgumentException("Password is required.");

                // 2. Clean input data
                string name = data.Name.Trim();
                string email = data.Email.Trim().ToLower();

                // 3. Check duplicate email
                bool emailExists = await _db.users
                    .AnyAsync(x => x.Email.ToLower() == email);

                if (emailExists)
                {
                    throw new Exception("Email already exists.");
                }

                // 4. Create entity
                var mydata = new Users
                {
                    Name = name.ToUpper(),
                    Email = email,

                    // Don't store plain-text passwords
                    Password = data.Password,

                    Dob = data.Dob,
                    Age = data.Age,
                    Gender = data.Gender,
                    Role = data.Role
                };

                // 5. Add to database
                await _db.users.AddAsync(mydata);

                // 6. Save changes
                int result = await _db.SaveChangesAsync();

                // 7. Return result
                return result > 0;
            }
            catch (DbUpdateException ex)
            {
                // Database-related error
                throw new Exception(
                    "Unable to create user because of a database error.",
                    ex);
            }
            catch (Exception ex)
            {
                // General error
                throw new Exception(
                    "An error occurred while creating the user.",
                    ex);
            }

        }

        public async Task<IList<Users>> GetUsers()
        {
            try
            {
                var users = await _db.users.AsNoTracking().ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting users: " + ex.Message, ex);
            }
        }

        public async Task<Users> GetUserByID(int id)
        {
            //     var res = await _db.users
            //.AsNoTracking()
            //.FirstOrDefaultAsync(x => x.ID == id);

            var res = await _db.users.FirstOrDefaultAsync(x=>x.ID==id);

            if (res == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return res;
        }

        public async Task UpdateUsers(Users data)
        {
            var existingUser = await _db.users.FindAsync(data.ID);

          //  var existingUser = await _db.users.AsNoTracking().FirstOrDefaultAsync(c => c.ID == data.ID);
            if (existingUser == null)
            {
                throw new Exception($"User with ID {data.ID} not found.");
            }
            existingUser.Name = data.Name;
            existingUser.Email = data.Email;
            existingUser.Dob = data.Dob;
            existingUser.Age = data.Age;
            existingUser.Gender = data.Gender;
            existingUser.Role = data.Role;

            // update fun
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUsers(int id)
        {
            var existingUser = await _db.users.FindAsync(id);
            if (existingUser == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            if (existingUser != null)
            {
                _db.users.Remove(existingUser);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> ValidateUser(Login data)
        {
            var user = await _db.users
                .AnyAsync(u => u.Email == data.Email && u.Password == data.Password);
            return user; // T F
        }

        public async Task<Users> GetUserByEmail(string Email)
        {
            return await _db.users.FirstOrDefaultAsync(u => u.Email == Email);
        }
    }
}
