using AutoMapper;
using Guestbook.Core.Models;
using Guestbook.Core.UnitOfWork;
using Guestbook.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestbookApp.Controllers
{
    public class ReplyController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        private readonly UserManager<User> _userManager;

        public ReplyController(IMapper mapper, IUnitOfWork unit, UserManager<User> userManager)
        {
            _mapper = mapper;
            _unit = unit;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult reply(Guid id)
        {
            var _comment = _unit.comment.Find(a=>a.Id.Equals(id));

            if (_comment == null)
            {
                return NotFound();
            }
            
            else
            {

                return View("reply",new replyVM { commentId  = id});
            }
        }
        [HttpPost]
        [Route("postReply")]
        public IActionResult postReply(replyVM model)
        {
          var _comment =  _unit.comment.GetById(model.commentId).Result;
            var id = model.commentId;

             var reply = new Reply
            {
                User = _userManager.GetUserAsync(HttpContext.User).Result,
                Comment = _comment,
                Content = model.reply.Content
            };
            _unit.reply.Write(reply);
            _unit.complete();
            return RedirectToAction("CommentblusReplies", "Comment",id);
        }

    }
}
