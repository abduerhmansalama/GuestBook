using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.Models
{
   public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required,MaxLength(100)]
        public String Title { get; set; }
        [Required,MaxLength(2000)]
        public String Content { get; set; }
        public User User { get; set; }
        public IEnumerable<Reply>  Replies { get; set; }



    }
}
