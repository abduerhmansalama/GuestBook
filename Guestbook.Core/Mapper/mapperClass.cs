using AutoMapper;
using Guestbook.Core.Models;
using Guestbook.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.Mapper
{
   public class mapperClass:Profile
    {
        public mapperClass()
        {

            CreateMap<CreateCommentVM,Comment> ();
            CreateMap<LoginVM, User>();


        }
    }
}
