using Guestbook.Core.IRepositories;
using Guestbook.Core.Models;
using Guestbook.Core.UnitOfWork;
using Guestbook.EF.Data;
using Guestbook.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.EF.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Comment> comment { get;private set; }

        public IBaseRepository <User> user{ get; private set; }

        public IBaseRepository<Reply> reply { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            comment = new BaseRepository<Comment>(_context);
            user = new BaseRepository<User>(_context);
            reply = new BaseRepository<Reply>(_context);

        }
        public int complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
