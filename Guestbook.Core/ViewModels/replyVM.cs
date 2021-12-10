using Guestbook.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.ViewModels
{
   public class replyVM
    {
        public Guid commentId { get; set; }
        public Reply reply { get; set; }



    }
}
