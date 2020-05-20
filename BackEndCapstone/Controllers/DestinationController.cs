using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var destinations = await _context.Destinations
                .Where(destination => destination.UserId == user.Id)
                .ToListAsync();

            return View(destinations);
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

        [HttpPost]
        public async Task<ActionResult> Create(IEnumerable<Destination> destinations)
        {
            try
            {
                var user = await GetCurrentUserAsync();

                foreach (var destination in destinations)
                {
                    var newDestination = new Destination()
                    {
                        Name = destination.Name,
                        UserId = destination.UserId,
                        TourId = destination.TourId,
                        City = destination.City,
                        State = destination.State
                    };

                    _context.Destinations.Add(newDestination);
                    await _context.SaveChangesAsync();
                }

                var updatedDestinations = await _context.Destinations
                    .ToListAsync();

                return Ok(destinations);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        // POST: Destination/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Destination destination)
        {
            var destinationInstance = new Destination()
            {
                DestinationId = destination.DestinationId,
                Name = destination.Name,
                UserId = destination.UserId,
                TourId = destination.TourId,
                City = destination.City,
                State = destination.State
            };

            _context.Destinations.Update(destinationInstance);
            await _context.SaveChangesAsync();

            return Ok(destinationInstance);
        }

        // POST: Destination/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
                var foundDestination = await _context.Destinations.FirstOrDefaultAsync(d => d.DestinationId == id);
                _context.Remove(foundDestination);
                await _context.SaveChangesAsync();
                return Ok(foundDestination);
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}