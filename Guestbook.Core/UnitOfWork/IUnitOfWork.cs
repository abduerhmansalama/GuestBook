using Guestbook.Core.IRepositories;
using Guestbook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.UnitOfWork
{
   public interface IUnitOfWork:IDisposable
    {
        public IBaseRepository<Comment> comment { get;}
        public IBaseRepository<User> user { get; }
        public IBaseRepository<Reply> reply { get; }
        int complete();
    }
}
