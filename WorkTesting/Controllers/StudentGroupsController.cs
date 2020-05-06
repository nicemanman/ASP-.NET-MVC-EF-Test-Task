using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkTesting.Models;

namespace WorkTesting.Controllers
{
    public class StudentGroupsController : Controller
    {
        private StudentGroupsContext db = new StudentGroupsContext();

        // GET: StudentGroups
        public ActionResult Index()
        {
            var studentGroups = db.StudentGroups.Include(s => s.Teachers);
            return View(studentGroups.ToList());
        }

        // GET: StudentGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroups = db.StudentGroups.Find(id);
            if (studentGroups == null)
            {
                return HttpNotFound();
            }
            return View(studentGroups);
        }

        // GET: StudentGroups/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: StudentGroups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TeacherId")] StudentGroup studentGroups)
        {
            if (ModelState.IsValid)
            {
                db.StudentGroups.Add(studentGroups);
                db.SaveChanges();
                return RedirectToAction("Edit/"+studentGroups.Id);
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", studentGroups.TeacherId);
            return View(studentGroups);
        }

        // GET: StudentGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroups = db.StudentGroups.Find(id);
            if (studentGroups == null)
            {
                return HttpNotFound();
            }   
            ViewBag.TeacherName = db.Teachers.Find(studentGroups.TeacherId).Name;
            return View(studentGroups);
        }

        // POST: StudentGroups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TeacherId")] StudentGroup studentGroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentGroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", studentGroups.TeacherId);
            return View(studentGroups);
        }

        // GET: StudentGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroups = db.StudentGroups.Find(id);
            if (studentGroups == null)
            {
                return HttpNotFound();
            }
            return View(studentGroups);
        }

        // POST: StudentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Очищаем связанную с группой информацию о студентах в группе
            var query = from com in db.StudentsInGroups
                        where com.StudentGroupId == id
                        select com;

            foreach (StudentInGroup comment in query)
            { 
                // тут будет 1 запрос на выборку из бд
                db.StudentsInGroups.Remove(comment);
            }
            StudentGroup studentGroups = db.StudentGroups.Find(id);
            db.StudentGroups.Remove(studentGroups);
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
