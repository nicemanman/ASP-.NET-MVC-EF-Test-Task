using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTesting.Models.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int? id);
        List<T> GetList();
        void SubmitChanges();

    }
}
