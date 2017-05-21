using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp.Domain.Models.Identity
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
    }
}
