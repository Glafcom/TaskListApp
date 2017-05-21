using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Enums;

namespace TaskListApp.Domain.Filters
{
    public class UserFilter
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid? Department { get; set; }
        public RoleType? Role { get; set; }
        public UserStatus? Status { get; set; }
    }
}
