using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCapstone.Data;
using BackEndCapstone.Models;
using BackEndCapstone.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndCapstone.Controllers
{
    public class MessagesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessagesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Messages
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var lastMessage = _context.Messages
                .OrderByDescending(m => m.Timestamp)
                .FirstOrDefault();

            if (lastMessage != null)
            {
                var conversations = new List<Conversation>();
                var conversation = new Conversation();

                if (lastMessage.RecipientId == user.Id)
                {
                    conversation.User = user;
                    conversation.UserTwo = lastMessage.Recipient;
                    conversation.LastMessage = lastMessage;
                    conversation.IsRead = lastMessage.IsRead;
                }
                
                if (lastMessage.SenderId == user.Id)
                {
                    conversation.User = user;
                    conversation.UserTwo = lastMessage.Sender;
                    conversation.LastMessage = lastMessage;
                    conversation.IsRead = lastMessage.IsRead;
                }

                conversations.Add(conversation);

                return View(conversations);
            }
            else
            {
                lastMessage = new Messages()
                {
                    RecipientId = null,
                    Recipient = null,
                    Sender = null,
                    SenderId = null,
                    MessageText = null
                };

                var conversations = new List<Conversation>();
                var conversation = new Conversation();
                conversation.User = null;
                conversation.UserTwo = null;
                conversation.LastMessage = lastMessage;
                conversation.IsRead = lastMessage.IsRead;

                conversations.Add(conversation);

                return View(conversations);
            }
        }

        // GET: Messages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Messages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Messages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}