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

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
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

                return RedirectToAction("Details");
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


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
