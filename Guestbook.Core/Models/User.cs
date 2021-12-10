using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Guestbook.Core.Models
{
   public class User:IdentityUser
    {
        IEnumerable<Comment> Comments { get; set; }
        IEnumerable<Reply> Replies { get; set;}
    }
}
