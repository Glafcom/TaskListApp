using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;

namespace Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskDetailViewModel
    {
        public ToDoTaskStatus Status { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public DateTime CreateDate { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        
        public virtual ToDoTaskDetailUserViewModel Author { get; set; }
        public virtual ToDoTaskDetailUserViewModel Assignee { get; set; }
    }

    public class ToDoTaskDetailUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}