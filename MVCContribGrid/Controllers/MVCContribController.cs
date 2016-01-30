using MvcContrib.Pagination;
using MvcContrib.UI.Grid;
using MVCContribGrid.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCContribGrid.Controllers
{
    public class MVCContribController : Controller
    {
        MVCContribModel db = new MVCContribModel();
        //
        // GET: /MVCContrib/
        public ActionResult Index(GridSortOptions sort, int? page)
        {
            IPagination<Employee> emp = null;
          
            if (sort.Column == null) sort.Column = "Name";
            if (sort.Direction.ToString().ToLower() == "descending")
                emp = db.Employees.AsEnumerable().OrderByDescending(i => i.GetType().GetProperty(sort.Column).GetValue(i, null)).AsPagination(page ?? 1, 2);
            else
                emp = db.Employees.AsEnumerable().OrderBy(i => i.GetType().GetProperty(sort.Column).GetValue(i, null)).AsPagination(page ?? 1, 2);

            ViewData["sort"] = sort;
            return View(emp);
        }

        //public ActionResult Index(int? page)
        //{
        //    return View(db.Employees.ToList());
        //} 




        //public ActionResult Details(int id = 0)  
        // {  
        //     Employee employee = db.Employees.Find(id);  
        //     if (employee == null)  
        //     {  
        //         return HttpNotFound();  
        //     }  
        //     return View(employee);  
        // }  

        // //  
        // // GET: /Employee/Create  

        // public ActionResult Create()  
        // {  
        //     return View();  
        // }  

        // //  
        // // POST: /Employee/Create  

        // [HttpPost]  
        // public ActionResult Create(Employee employee)  
        // {  
        //     if (ModelState.IsValid)  
        //     {  
        //         db.Employees.Add(employee);  
        //         db.SaveChanges();  
        //         return RedirectToAction("Index");  
        //     }  

        //     return View(employee);  
        // }  

        // //  
        // // GET: /Employee/Edit/5  

        // public ActionResult Edit(int id = 0)  
        // {  
        //     Employee employee = db.Employees.Find(id);  
        //     if (employee == null)  
        //     {  
        //         return HttpNotFound();  
        //     }  
        //     return View(employee);  
        // }  

        // //  
        // // POST: /Employee/Edit/5  

        // [HttpPost]  
        // public ActionResult Edit(Employee employee)  
        // {  
        //     if (ModelState.IsValid)  
        //     {  
        //         db.Entry(employee).State = EntityState.Modified;  
        //         db.SaveChanges();  
        //         return RedirectToAction("Index");  
        //     }  
        //     return View(employee);  
        // }  

        // //  
        // // GET: /Employee/Delete/5  

        // public ActionResult Delete(int id = 0)  
        // {  
        //     Employee employee = db.Employees.Find(id);  
        //     if (employee == null)  
        //     {  
        //         return HttpNotFound();  
        //     }  
        //     return View(employee);  
        // }  

        // //  
        // // POST: /Employee/Delete/5  

        // [HttpPost, ActionName("Delete")]  
        // public ActionResult DeleteConfirmed(int id)  
        // {  
        //     Employee employee = db.Employees.Find(id);  
        //     db.Employees.Remove(employee);  
        //     db.SaveChanges();  
        //     return RedirectToAction("Index");  
        // }  

        // protected override void Dispose(bool disposing)  
        // {  
        //     db.Dispose();  
        //     base.Dispose(disposing);  
        // }  
    }

}