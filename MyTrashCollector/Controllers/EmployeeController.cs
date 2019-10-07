using System;
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
            var employeeId = User.Identity.GetUserId();
            Employee employee = context.Employees.Where(e => e.UserId == employeeId).SingleOrDefault();
            var listOfDayCustomers = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.Day == DateTime.Today.DayOfWeek.ToString());
             return View(listOfDayCustomers);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Where(e => e.Id == id).SingleOrDefault();
            return View(employee);
        }

        public ActionResult Confimation(int id)
        {
            var customer = context.Customers.Find(id);
           return View(customer);
        }
        [HttpPost]
        public ActionResult Confirmation(Customer customer)
        {
            var updateCustomer = context.Customers.Find(customer.Id);
            updateCustomer.Balance += 75;
            updateCustomer.PickConfirmed = true;
            context.SaveChanges();
            return RedirectToAction("Index", "Employee");

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
