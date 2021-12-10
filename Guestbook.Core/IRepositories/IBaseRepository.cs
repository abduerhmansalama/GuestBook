using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.IRepositories
{
   public interface IBaseRepository<T> where T:class
    {
        Task<T> GetById(Guid id);
        //Task<T> GetByUser(T formModel);
        T Find(Expression <Func<T,bool>> expression);
        public IEnumerable<T> GetAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
        
        Task<T> Write(T formModel);
        T Update (T formModel);
        Task<T> Remove(T formModel);




    }
}
