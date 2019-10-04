using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTrashCollector.Models;
using Microsoft.AspNet.Identity;

namespace MyTrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            
            return View(context.Customers.ToList());
        }

        
        public ActionResult Details(int id)
        {
            Customer customer = context.Customers.Where(c=>c.Id==id).SingleOrDefault();
            return View(customer);
        }

        
        public ActionResult Create()
        {
            Customer newCutsomer = new Customer();
            return View(newCutsomer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var user = User.Identity.GetUserId();
                customer.UserId = user;
                context.Customers.Add(customer);
                context.SaveChanges();

                return RedirectToAction("Details", "Customer", new { id = customer.Id });
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            Customer editCustomer = context.Customers.Where(c => c.Id == id).SingleOrDefault();
            return View(editCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                Customer editCustmer = context.Customers.Find(id);
                editCustmer.FirstName = customer.FirstName;
                editCustmer.LastName = customer.LastName;
                editCustmer.StreetAddress = customer.LastName;
                editCustmer.City = customer.City;
                editCustmer.State = customer.State;
                editCustmer.ZipCode = customer.ZipCode;
                editCustmer.Day = customer.Day;
                editCustmer.StartDay = customer.StartDay;
                editCustmer.EndDate = customer.EndDate;
                editCustmer.ExtraPick = customer.ExtraPick;
                context.SaveChanges();
                return RedirectToAction("Details", "Customer", new { id = editCustmer.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer removeCustomer = context.Customers.Where(c => c.Id == id).SingleOrDefault();

            return View(removeCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
               
                context.Customers.Remove(context.Customers.Find(id));
                context.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
