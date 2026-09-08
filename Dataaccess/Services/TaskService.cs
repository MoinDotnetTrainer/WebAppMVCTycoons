using Dataaccess.IService;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.Services
{
    public class TaskService : ITransient, Iscoped, Isingleton
    {
        private readonly Guid _guid;
        public TaskService()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }

    }
}
