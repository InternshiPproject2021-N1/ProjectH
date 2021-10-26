using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoApplication.Models;

namespace DemoApplication.Controllers
{
    public class ProjectDetailsController : Controller
    {
        private DemoApplicationDbContext db = new DemoApplicationDbContext();

        // GET: ProjectDetails
        public ActionResult Index()
        {
            var projectDetails = db.ProjectDetails.Include(p => p.Employeess).Include(p => p.Projects);
            return View(projectDetails.ToList());
        }

        // GET: ProjectDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDetail projectDetail = db.ProjectDetails.Find(id);
            if (projectDetail == null)
            {
                return HttpNotFound();
            }
            return View(projectDetail);
        }

        // GET: ProjectDetails/Create
        public ActionResult Create()
        {
            ViewBag.EmpId = new SelectList(db.Employeess, "EmpId", "Name");
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name");
            return View();
        }

        // POST: ProjectDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,ProjectId,StartDate,EndDate")] ProjectDetail projectDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProjectDetails.Add(projectDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpId = new SelectList(db.Employeess, "EmpId", "Name", projectDetail.EmpId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", projectDetail.ProjectId);
            return View(projectDetail);
        }

        // GET: ProjectDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDetail projectDetail = db.ProjectDetails.Find(id);
            if (projectDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpId = new SelectList(db.Employeess, "EmpId", "Name", projectDetail.EmpId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", projectDetail.ProjectId);
            return View(projectDetail);
        }

        // POST: ProjectDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,ProjectId,StartDate,EndDate")] ProjectDetail projectDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpId = new SelectList(db.Employeess, "EmpId", "Name", projectDetail.EmpId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", projectDetail.ProjectId);
            return View(projectDetail);
        }

        // GET: ProjectDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDetail projectDetail = db.ProjectDetails.Find(id);
            if (projectDetail == null)
            {
                return HttpNotFound();
            }
            return View(projectDetail);
        }

        // POST: ProjectDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectDetail projectDetail = db.ProjectDetails.Find(id);
            db.ProjectDetails.Remove(projectDetail);
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
}
