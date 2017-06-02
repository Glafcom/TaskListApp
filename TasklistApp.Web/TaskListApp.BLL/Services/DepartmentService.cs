using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Contracts.BLLContracts.Services;
using TaskListApp.Contracts.DALContracts;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;

namespace TaskListApp.BLL.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        public DepartmentService(IGenericRepository<Department> itemRepository)
            : base(itemRepository)
        {
        }

        public IEnumerable<Department> GetDeparmentsByFilter(DepartmentFilter filter)
        {
            var departments = GetItems();

            if (!string.IsNullOrEmpty(filter.Name))
                departments = departments.Where(d => d.Name.Contains(filter.Name));

            return departments;
        }
    }
}
