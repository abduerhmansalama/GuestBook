using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.Models
{
   public class Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        [Required,MaxLength(1000)]
        public String Content { get; set; }
        public Comment Comment { get; set; }
        public User  User { get; set; }

    }
}
