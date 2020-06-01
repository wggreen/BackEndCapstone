using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCapstone.Data;
using BackEndCapstone.Migrations;
using BackEndCapstone.Models;
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

        public async Task<ActionResult> GetUnreadMessages()
        {
            var user = await GetCurrentUserAsync();

            var messages = await _context.Messages
                .Where(message => message.RecipientId == user.Id)
                .Where(message => message.IsRead == false)
                .ToListAsync();

            return Ok(messages);
        }

        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var messages = await _context.Messages
                .Where(message => message.RecipientId == user.Id || message.SenderId == user.Id)
                .Include(message => message.Recipient)
                .Include(message => message.Sender)
                .ToListAsync();

            return View(messages);
        }

        // GET: Messages/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Messages/Create
        [HttpPost]
        public async Task<ActionResult> Create(Messages messages)
        {
            try
            {
                var newMessages = new Messages()
                {
                    SenderId = messages.SenderId,
                    RecipientId = messages.RecipientId,
                    Dates = messages.Dates,
                    MessageText = messages.MessageText,
                    Timestamp = DateTime.Now,
                    IsRead = false
                };

                _context.Messages.Add(newMessages);
                await _context.SaveChangesAsync();

                return Ok(newMessages);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // POST: Messages/Edit/5
        [HttpPost]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            var foundMessage = await _context.Messages
                .Where(message => message.MessagesId == id)
                .FirstOrDefaultAsync();

            foundMessage.IsRead = true;

            _context.Messages.Update(foundMessage);
            await _context.SaveChangesAsync();

            return Ok(foundMessage);
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