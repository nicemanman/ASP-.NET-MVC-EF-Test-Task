using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkTesting.Models;
using WorkTesting.Models.Repository;

namespace WorkTesting.Controllers
{
    public class StudentGroupsController : Controller
    {
        
        private IRepository<StudentGroup> studentGroupsRepository { get; set; }
        private IRepository<Teacher> teachersRepository { get; set; }
        public StudentGroupsController(IRepository<StudentGroup> studentGroupsRepository, IRepository<Teacher> teachersRepository)
        {
            this.studentGroupsRepository = studentGroupsRepository;
            this.teachersRepository = teachersRepository;
        }
        // GET: StudentGroups
        public ActionResult Index()
        {
            return View(studentGroupsRepository.GetList());
        }

        // GET: StudentGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroup = studentGroupsRepository.GetById(id);
            if (studentGroup == null)
            {
                return HttpNotFound();
            }
            return View(studentGroup);
        }

        // GET: StudentGroups/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(teachersRepository.GetList(), "Id", "Name");
            return View();
        }

        // POST: StudentGroups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,TeacherId")] StudentGroup studentGroup)
        {
            if (ModelState.IsValid)
            {
                studentGroupsRepository.Add(studentGroup);
                return RedirectToAction("Edit/"+studentGroup.Id);
            }

            ViewBag.TeacherId = new SelectList(teachersRepository.GetList(), "Id", "Name", studentGroup.TeacherId);
            return View(studentGroup);
        }

        // GET: StudentGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroup = studentGroupsRepository.GetById(id);
            if (studentGroup == null)
            {
                return HttpNotFound();
            }   
            ViewBag.TeacherName = studentGroup.TeacherName;
            return View(studentGroup);
        }

        // POST: StudentGroups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TeacherId")] StudentGroup studentGroup)
        {
            if (ModelState.IsValid)
            {
                studentGroupsRepository.Update(studentGroup);
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(teachersRepository.GetList(), "Id", "Name", studentGroup.TeacherId);
            return View(studentGroup);
        }

        // GET: StudentGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroup = studentGroupsRepository.GetById(id);
            if (studentGroup == null)
            {
                return HttpNotFound();
            }
            return View(studentGroup);
        }

        // POST: StudentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentGroup studentGroup = studentGroupsRepository.GetById(id);
            studentGroupsRepository.Delete(studentGroup);
            return RedirectToAction("Index");
        }

    }
}
