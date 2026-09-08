using Dataaccess.IService;
using Dataaccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Services
{
    public class ValidateService : IValidate
    {
        public readonly AppDb _db;
        public ValidateService(AppDb db) {
            _db = db;
        }

        public async Task<bool> Validate(Validate data) {
            await _db.validate.AddAsync(data);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
