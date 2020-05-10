using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkTesting.Models.Repository
{
    public class TeachersRepository : IRepository<Teacher>
    {
        private StudentGroupsContext context;
        public TeachersRepository()
        {
            context = new StudentGroupsContext();
        }
        public void Add(Teacher item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Teacher item)
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetList()
        {
            return context.Teachers.ToList();
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher item)
        {
            throw new NotImplementedException();
        }
    }
}