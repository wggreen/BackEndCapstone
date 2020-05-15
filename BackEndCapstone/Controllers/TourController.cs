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
    public class TourController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TourController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Tour
        public async Task<ActionResult> GetTours()
        {
            var tours = await _context.Tours
                .ToListAsync();
            return Ok(tours);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tour/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Tour/Create
        [HttpPost]
        public async Task<ActionResult> Create(Tour tour)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var newTour = new Tour()
                {
                    Name = tour.Name,
                    UserId = tour.UserId,
                    Saved = tour.Saved
                };

                _context.Tours.Add(newTour);
                await _context.SaveChangesAsync();

                return Ok(newTour);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tour/Edit/5
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

        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tour/Delete/5
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