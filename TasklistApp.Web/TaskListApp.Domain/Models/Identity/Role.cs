using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp.Domain.Models.Identity
{
    public class Role : IdentityRole<Guid, UserRole>
    {
        public Role() 
        {
            this.Id = Guid.NewGuid();
        }   
    }
}
