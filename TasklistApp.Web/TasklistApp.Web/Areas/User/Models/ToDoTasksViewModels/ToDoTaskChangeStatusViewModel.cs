using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;

namespace Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskChangeStatusViewModel
    {
        public Guid Id { get; set; }
        public ToDoTaskStatus Status { get; set; }
        public string Information { get; set; }
    }
}