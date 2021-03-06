﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskListApp.Contracts.BLLContracts.Domains;
using TaskListApp.Domain.Filters;
using TaskListApp.Domain.Models;
using TaskListApp.Web.Areas.Admin.Models.DepartmentsViewModels;

namespace TasklistApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        protected IAdminDomain _adminDomain;

        public DepartmentsController(IAdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }

        // GET: Admin/Departments
        public ActionResult Index(DepartmentFilter filter)
        {
            var departments = _adminDomain.GetDepartmentsByFilter(filter);
            var model = new DepartmentsViewModel
            {
                Filter = filter,
                Departments = departments.Select(d => Mapper.Map<IndexDepartmentViewModel>(d))
            };
                
            return View(model);
        }

        public ActionResult Department(Guid id)
        {
            var department = _adminDomain.GetDepartment(id);
            var model = Mapper.Map<DepartmentViewModel>(department);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DepartmentCreateViewModel());
        }

        [HttpPost]
        public ActionResult Create(DepartmentCreateViewModel model)
        {
            _adminDomain.CreateDepartment(Mapper.Map<Department>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var department = _adminDomain.GetDepartment(id);
            return View(Mapper.Map<DepartmentEditViewModel>(department));
        }

        [HttpPost]
        public ActionResult Edit(DepartmentEditViewModel model)
        {
            _adminDomain.ChangeDepartment(Mapper.Map<Department>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _adminDomain.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(Guid departmentId, Guid employeeId) 
        {
            _adminDomain.DeleteEmployeeFromDepartment(departmentId, employeeId);
            return RedirectToAction("Edit", new { id = departmentId });
        }
    }
}