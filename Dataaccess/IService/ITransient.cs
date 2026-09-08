using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.IService
{
    public interface ITransient
    {
        Guid GetGuid();  // Unique Number
    }
    public interface Iscoped
    {
        Guid GetGuid();
    }
    public interface Isingleton
    {
        Guid GetGuid();
    }

}
