using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;

namespace TaskListApp.Contracts.BLLContracts.Services
{
    public interface IDepartmentService : IBaseService<Department>
    {
        IEnumerable<Department> GetDeparmentsByFilter(DepartmentFilter filter);
    }
}
