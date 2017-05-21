﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Domain.Enums;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskBlankViewModel
    {
        public ToDoTaskStatus Status { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Guid AssigneeId { get; set; }
        public AssigneeViewModel Assignee { get; set; }
    }

    public class AssigneeViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}