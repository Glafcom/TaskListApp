using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Domain.Enums;

namespace TaskListApp.Web.Areas.User.Models.ToDoTasksViewModels
{
    public class ToDoTaskBlankViewModel
    {
        public Guid Id { get; set; }
        public ToDoTaskStatus? Status { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public string Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? AssigneeId { get; set; }  
        
        public IEnumerable<SelectListItem> DepartmentsList { get; set; } 
        public IEnumerable<SelectListItem> EmployeesList { get; set; }   
    }
    
}