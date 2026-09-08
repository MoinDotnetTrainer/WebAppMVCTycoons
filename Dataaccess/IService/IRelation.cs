using Dataaccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.IService
{
    public interface IRelation
    {
        Task<IList<Dept>> GetAllDept();
        Task<IList<Emp>> GetAllEmp();
    }
}
