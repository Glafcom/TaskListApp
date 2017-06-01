using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskListApp.Domain.Enums;
using TaskListApp.Domain.Models.Identity;

namespace TaskListApp.Domain.Models
{
    public class ToDoTask : BaseModel
    {
        public ToDoTaskStatus Status { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public DateTime CreateDate { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid AssigneeId { get; set; }

        public virtual User Author { get; set; }
        public virtual User Assignee { get; set; }
    }
}
