using Dataaccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.IService
{
    public interface IValidate
    {
        Task<bool> Validate(Validate data);
    }
}
