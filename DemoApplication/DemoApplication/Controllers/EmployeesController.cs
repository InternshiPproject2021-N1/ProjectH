using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DemoApplication.Models;

/*namespace DemoApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private DemoApplicationDbContext db = new DemoApplicationDbContext();

        // GET: Employees
        public ActionResult Index(string search)
        {
            List<Employees> listemp = db.Employeess.ToList();
            return View(db.Employeess.Where(x=>x.Name.Contains(search) || x.Address.Contains(search) || x.Email.Contains(search) || x.Description.Contains(search) || x.CreatedBy.Contains(search) || search==null).ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employeess.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,Name,Address,Email,Age,Status,IsActive,Rank,Description,Create,CreatedBy")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Employeess.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employeess.Find(id);

            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,Name,Address,Email,Age,Status,IsActive,Rank,Description,Create,CreatedBy")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employeess.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employeess.Find(id);
            db.Employeess.Remove(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}*/

namespace DemoApplication.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee  
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        ///   
        /// Get All Employee  
        /// </summary>  
        /// <returns></returns>  
        public JsonResult Get_AllEmployee()
        {
            using (DemoApplicationDbContext Obj = new DemoApplicationDbContext())
            {
                List<Employees> Emp = Obj.Employeess.ToList();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Get Employee With Id  
        /// </summary>  
        /// <param name="Id"></param>  
        /// <returns></returns>  
        public JsonResult Get_EmployeeById(string Id)
        {
            using (DemoApplicationDbContext Obj = new DemoApplicationDbContext())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employeess.Find(EmpId), JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>  
        /// Insert New Employee  
        /// </summary>  
        /// <param name="Employe"></param>  
        /// <returns></returns>  
        public string Insert_Employee(Employees Employes)
        {
            if (Employes != null)
            {
                using (DemoApplicationDbContext Obj = new DemoApplicationDbContext())
                {
                    Obj.Employeess.Add(Employes);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }
        /// <summary>  
        /// Delete Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Delete_Employee(Employees Emp)
        {
            if (Emp != null)
            {
                using (DemoApplicationDbContext Obj = new DemoApplicationDbContext())
                {
                    var Emp_ = Obj.Entry(Emp);
                    if (Emp_.State == System.Data.Entity.EntityState.Detached)
                    {
                        Obj.Employeess.Attach(Emp);
                        Obj.Employeess.Remove(Emp);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            }
            else
            {
                return "Employee Not Deleted! Try Again";
            }
        }
        /// <summary>  
        /// Update Employee Information  
        /// </summary>  
        /// <param name="Emp"></param>  
        /// <returns></returns>  
        public string Update_Employee(Employees Emp)
        {
            if (Emp != null)
            {
                using (DemoApplicationDbContext Obj = new DemoApplicationDbContext())
                {
                    var Emp_ = Obj.Entry(Emp);
                    Employees EmpObj = Obj.Employeess.Where(x => x.EmpId == Emp.EmpId).FirstOrDefault();
                    EmpObj.Name = Emp.Name;
                    EmpObj.Address = Emp.Address;
                    EmpObj.Email = Emp.Email;
                    EmpObj.Age = Emp.Age;
                    EmpObj.Status = Emp.Status;
                    EmpObj.IsActive = Emp.IsActive;
                    EmpObj.Rank = Emp.Rank;
                    EmpObj.Description = Emp.Description;
                    EmpObj.Create = Emp.Create;
                    EmpObj.CreatedBy = Emp.CreatedBy;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            }
            else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}