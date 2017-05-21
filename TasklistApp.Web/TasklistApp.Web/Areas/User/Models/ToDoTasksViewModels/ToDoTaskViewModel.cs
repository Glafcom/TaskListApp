using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskViewModel
    {
        public Guid Id { get; set; }
        public ToDoTaskStatus Status { get; set; }
        public string Caption { get; set; }
        public ToDoTaskUserViewModel Author { get; set; }
        public ToDoTaskUserViewModel Assignee { get; set; }
    }

    public class ToDoTaskUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}