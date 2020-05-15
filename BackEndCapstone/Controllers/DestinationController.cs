using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndCapstone.Data;
using BackEndCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndCapstone.Controllers
{
    public class DestinationController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DestinationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Destination
        public async Task<ActionResult> GetDestinations()
        {
            var destinations = await _context.Destinations
                .ToListAsync();
            return Ok(destinations);
        }

        // GET: Destination/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Destination/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Destination/Create
        [HttpPost]
        public async Task<ActionResult> Create(Destination destination)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var newDestination = new Destination()
                {
                    Name = destination.Name,
                    UserId = destination.UserId,
                };

                _context.Destinations.Add(newDestination);
                await _context.SaveChangesAsync();

                return Ok(newDestination);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // GET: Destination/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Destination/Edit/5
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

        // GET: Destination/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Destination/Delete/5
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