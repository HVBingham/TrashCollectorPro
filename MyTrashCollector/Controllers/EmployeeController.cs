﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTrashCollector.Models;
using Microsoft.AspNet.Identity;

namespace MyTrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
             
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee newEmpolyee = new Employee();
            return View(newEmpolyee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var user = User.Identity.GetUserId();
                employee.UserId = user;
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Details", "Employee", new { id = employee.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee editEmployee = context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(editEmployee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                Employee editEmployee = context.Employees.Find(id);
                editEmployee.FirstName = employee.FirstName;
                editEmployee.LastName = employee.LastName;
                editEmployee.ZipCode = employee.ZipCode;
                context.SaveChanges();

                return RedirectToAction("Details","Employee",new { id = employee.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee removeEmployee = context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(removeEmployee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                context.Employees.Remove(context.Employees.Find(id));
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
