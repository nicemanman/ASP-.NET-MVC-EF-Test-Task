using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkTesting.Models;

namespace WorkTesting.Controllers
{
    public class StudentsController : Controller
    {
        private StudentGroupsContext db = new StudentGroupsContext();
        
        // GET: StudentGroupStaff
        public ActionResult Index(StudentGroup studentGroups)
        {
            TempData["studentGroupId"] = studentGroups.Id;
            TempData["studentGroupName"] = studentGroups.Name;
            TempData["studentGroupTeacher"] = db.Teachers.Find(studentGroups.TeacherId).Name;
            TempData["studentGroupTeacherId"] = db.Teachers.Find(studentGroups.TeacherId).Id;

            return PartialView(db.StudentsInGroups.ToList().Where(x => x.StudentGroupId == studentGroups.Id));
        }

        
        public ActionResult Create()
        {
            
            StudentInGroup studentGroupsStaff = new StudentInGroup();
            if (TempData["studentGroupId"] != null) 
            {
            studentGroupsStaff.StudentGroupId = Convert.ToInt32(TempData["studentGroupId"]);
            int studentGroupTeacherId = Convert.ToInt32(TempData["studentGroupTeacherId"]);
                //Организации, привязанные к преподу
                ViewBag.Organisations = new SelectList(db.Organisations.Where(x => x.TeacherID == studentGroupTeacherId), "Id", "Name");
                //Сотрудники, которые есть в организации
                ViewBag.studentGroupId = Convert.ToInt32(TempData["studentGroupId"]);
            }
            
            return View(studentGroupsStaff);
        }

        public ActionResult GetStaffByOrganisation(int organisationId, int studentGroupId) 
        {  
            List<StudentInGroup> students = db.StudentsInGroups.Where(x => x.StudentGroupId == studentGroupId).ToList();
          
            List<Student> staff = db.Students.Where(x => x.OrganisationId == organisationId).ToList();
            List<Student> result = new List<Student>();
            for (int j = 0; j < staff.Count(); j++) 
            {
                for (int i = 0; i < students.Count(); i++) 
                {
                    if (students[i].EmployeeId == staff[j].Id)
                    {
                        staff.RemoveAt(j);
                        j--; 
                        break;
                    }   
                }
            }
            ViewBag.Staff = staff;
            return PartialView();
        }


        // POST: StudentGroupsStaffs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId, StudentGroupId, OrganisationId")] StudentInGroup studentGroupsStaff)
        {
            if (ModelState.IsValid)
            {
                db.StudentsInGroups.Add(studentGroupsStaff);
                db.SaveChanges();
                return RedirectToAction("Edit/"+ studentGroupsStaff.StudentGroupId, "StudentGroups");
            }
            
     
            return View(studentGroupsStaff);
        }


        // GET: StudentGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            StudentInGroup studentGroupsStaff = db.StudentsInGroups.Find(id);

            if (studentGroupsStaff == null)
            {
                return HttpNotFound();
            }
            return View(studentGroupsStaff);
        }

        // POST: StudentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            
            StudentInGroup studentGroupsStaff = db.StudentsInGroups.Find(id);
            int? studentGroupId = studentGroupsStaff.StudentGroupId;
            db.StudentsInGroups.Remove(studentGroupsStaff);
            db.SaveChanges();
            return RedirectToAction("Edit/"+studentGroupId,"StudentGroups");
        }
    }
}