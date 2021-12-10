using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestbook.Core.ViewModels
{
   public class RegisterVM
    {

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required , Compare("Password",ErrorMessage ="Confirm Password Doesn't match , try Again ^^")]
        public string ConfirmPassword { get; set; }


    }
}
