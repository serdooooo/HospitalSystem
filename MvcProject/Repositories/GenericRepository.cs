using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcProject.Repositories
{
    public class GenericRepository<T> where T: class , new()
    {
        HospitalEntities hospital = new HospitalEntities(); 
        public List<T> List()
        {
            return hospital.Set<T>().ToList();
        }
        public void TAdd(T t)
        {
            hospital.Set<T>().Add(t);
            hospital.SaveChanges();
        }
        public void TDelete(T t)
        {
            hospital.Set<T>().Remove(t);
            hospital.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return hospital.Set<T>().FirstOrDefault(where);
        }
    }
}