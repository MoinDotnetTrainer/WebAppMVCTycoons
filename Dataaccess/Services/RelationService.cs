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
    public class RelationService : IRelation
    {
        public readonly AppDb _db;
        public RelationService(AppDb _db)
        {
            this._db = _db;
        }

        public async Task<IList<Dept>> GetAllDept()
        {
            return await _db.dept.Include("Emp").ToListAsync();
        }

        public async Task<IList<Emp>> GetAllEmp()
        {
            return await _db.emp.Include("Dept").ToListAsync();

            // joins 
        }
    }
}
