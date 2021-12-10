/*using AutoMapper;
using Guestbook.Core.Helper;
using Guestbook.Core.Models;
using Guestbook.Core.UnitOfWork;
using Guestbook.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GuestbookApp.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUnitOfWork unit , IMapper mapper, SignInManager<User> signInManager,
            UserManager<User> userManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unit = unit;
            _mapper = mapper;
        }

        [Route("Login")]
        public IActionResult Login() {
            return View("Login",new LoginVM());
        }

        [Route("Register")]

        public IActionResult Register()
        {
            return View("Register", new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> PostLogin(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }
          // var PasswordHash = HelperMethods.EncryPasswor(model.Password);
            var UserName = new MailAddress(model.Email).User;
            var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password, false, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                return RedirectToAction("Write", "Comment");
            }
            else
            {          
                ModelState.AddModelError(string.Empty, "Password Or Email is not Correct");
                return View("Login", model);
            }
            
                        
        }

        [HttpPost]
        [Route("PostRegister")]
        public async Task<IActionResult> PostRegister(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                 return View("Register", model);
            }

            var user = new User
            {
                //PasswordHash= HelperMethods.EncryPasswor(model.Password),
                UserName = new MailAddress(model.Email).User,
                 Email=model.Email,                                  
            };
            var result = await _userManager.CreateAsync(user,model.Password);

           await _unit.user.Write(user);
            _unit.complete();
            return RedirectToAction(nameof(Login));
        }
    }
}
*/
