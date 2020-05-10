using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkTesting.Models.Repository
{
    public class StudentGroupsRepository : IRepository<StudentGroup>
    {
        private StudentGroupsContext studentGroupContext = new StudentGroupsContext();
      
        public void Add(StudentGroup item)
        {
            studentGroupContext.StudentGroups.Add(item);
            SubmitChanges();
        }

        public void Delete(StudentGroup item)
        {
            if (item != null) 
            {
                int id = item.Id;
                //Очищаем связанную с группой информацию о студентах в группе
                var query = from com in studentGroupContext.StudentsInGroups
                            where com.StudentGroupId == id
                            select com;
            
                foreach (StudentInGroup comment in query)
                    studentGroupContext.StudentsInGroups.Remove(comment);
                studentGroupContext.StudentGroups.Remove(item);
                SubmitChanges();
            }
        }

        public StudentGroup GetById(int? id)
        {
            return studentGroupContext.StudentGroups.Find(id);
        }

        public List<StudentGroup> GetList()
        {
            return studentGroupContext.StudentGroups.Include(s => s.Teacher).ToList(); 
        }

        public void SubmitChanges()
        {
            studentGroupContext.SaveChanges();
        }

        public void Update(StudentGroup item)
        {
            studentGroupContext.Entry(item).State = EntityState.Modified;
            SubmitChanges();
        }
    }
}