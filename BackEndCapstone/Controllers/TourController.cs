﻿using System;
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

        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var tours = await _context.Tours
                .Where(tour => tour.UserId == user.Id)
                .Include(tour => tour.Destinations)
                .ToListAsync();

            return View(tours);
        }

        // GET: Tour
        public async Task<ActionResult> GetTours()
        {
            var tours = await _context.Tours
                .ToListAsync();
            return Ok(tours);
        }

        public async Task<ActionResult> GetTourByName(string name)
        {
            var user = await GetCurrentUserAsync();

            var foundTour = await _context.Tours
                .Where(tour => tour.Name == name)
                .Where(tour => tour.UserId == user.Id)
                .Where(tour => tour.Saved == true)
                .FirstOrDefaultAsync();

            return Ok(foundTour);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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

        // POST: Tour/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Tour tour)
        {
            var tourInstance = new Tour()
            {
                TourId = tour.TourId,
                Name = tour.Name,
                UserId = tour.UserId,
                Saved = tour.Saved
            };

            _context.Tours.Update(tourInstance);
            await _context.SaveChangesAsync();

            return Ok(tourInstance);
        }

        public async Task<ActionResult> EditMap(int id)
        {
            var user = await GetCurrentUserAsync();

            var viewModel = new MapEditViewModel();

             viewModel.ApplicationUsers = await _context.ApplicationUsers
                .Where(user => user.UserType == "venue")
                .ToListAsync();

            viewModel.ApplicationUserId = user.Id;

            var foundTour = await _context.Tours
                .Where(tour => tour.TourId == id)
                .FirstOrDefaultAsync();

            viewModel.TourToEdit = foundTour;

            viewModel.Destinations = await _context.Destinations
                .Where(destination => destination.TourId == foundTour.TourId)
                .ToListAsync();

            return View(viewModel);
        }

        // POST: Tour/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var foundTour = await _context.Tours
                .Where(tour => tour.TourId == id)
                .FirstOrDefaultAsync();
            
            _context.Remove(foundTour);
            await _context.SaveChangesAsync();

            return Ok(foundTour);
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}