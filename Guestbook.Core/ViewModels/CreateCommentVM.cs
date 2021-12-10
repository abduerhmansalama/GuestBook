using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.ViewModels
{
  public  class CreateCommentVM
    {
        [Required,MaxLength(100)]
        public String Title { get; set; }

        [Required,MaxLength(2000)]
        public String Content { get; set; }

    }
}
