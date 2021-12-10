using Guestbook.Core.IRepositories;
using Guestbook.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T Update(T formModel)
        {
                _context.Update(formModel);
            return formModel;


        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetById(Guid id)
        {
           var entity =  await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public  T Find(Expression<Func<T, bool>> expression)
        {
           var result =  _context.Set<T>();

            return  result.SingleOrDefault(expression);
        }

        public Task<T> Remove(T formModel)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Write(T formModel)
        {
            await _context.Set<T>().AddAsync(formModel);
            return formModel;
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().Where(criteria).ToListAsync();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }
    }
}
