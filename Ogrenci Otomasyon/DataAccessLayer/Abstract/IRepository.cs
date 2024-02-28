using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        int Insert(T p);
        int Update(T p);
        int Delete(T p);
        T GetById(int id);
    }
}