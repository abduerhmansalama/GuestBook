using AutoMapper;
using Guestbook.Core.Models;
using Guestbook.Core.UnitOfWork;
using Guestbook.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GuestbookApp.Controllers
{
    [Route("Comment")]
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly UserManager<User> _userManager; 

        public CommentController(IMapper mapper , IUnitOfWork unit,UserManager<User> userManager)
        {
            _mapper = mapper;
            _unit = unit;
            _userManager = userManager;
        }
        public IActionResult CommentblusReplies(Guid id) 
        {
            
            return View("CommentblusReplies", _unit.comment.FindAll(a => a.Id == id, new[] {"Replies"}));

        }

        [Route("GetAll")]
        public IActionResult GetAll()
        {
               IEnumerable<Comment> comments =  _unit.comment.GetAll();
            return View(comments); 
        }


        [Route("GetByUser")]
        public async Task<IActionResult> GetByUser()
        {
           var user = await _userManager.GetUserAsync(HttpContext.User);
          IEnumerable<Comment> comments =await  _unit.comment.FindAllAsync(c => c.User.Id.Equals(user.Id));
            return View("GetAll",comments);
        }

        [Authorize(Roles = "User")]
        [Route("Comment")]
        public IActionResult Comment()
        {
            return View("Comment", new Comment());

        }
        [Authorize(Roles = "User")]
        [Route("PostComment")]
        [HttpPost]
        public async Task<IActionResult> PostComment(Comment model)
        {
            if (!ModelState.IsValid) { return View(); }
            if (model == null) { return BadRequest();}

            var comment = new Comment();            
            comment= _mapper.Map<Comment>(model);
            comment.User =await _userManager.GetUserAsync(HttpContext.User);
            await _unit.comment.Write(comment);
            _unit.complete();
            return Ok("Submit Success");
        }
        [Authorize(Roles = "User")]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var comment = await _unit.comment.GetById(id);
            if (comment == null)
            {
                return NotFound("This comment not Available");
            }
            else { 
            
                return View("Edit", comment);
            }

        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("SubmitEdit")]
        public  IActionResult PostEdit(Comment model) {

            if (!ModelState.IsValid) { return View(); }
            if (model == null) { return BadRequest(); }
             _unit.comment.Update(model);
            _unit.complete();
             return RedirectToAction(nameof(GetByUser));           
            
        }


    }
}
