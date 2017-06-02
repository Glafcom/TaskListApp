using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Domain.Models
{
    public class Department : BaseModel
    {
        public Department()
        {
            this.Personal = new HashSet<User>();
        }

        public string Name { get; set; }
        public Guid? HeadId { get; set; }

        public virtual User Head { get; set; }
        public virtual ICollection<User> Personal { get; set; }
    }
}
