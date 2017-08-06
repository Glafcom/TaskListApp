using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp.Domain.Models.Identity
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
