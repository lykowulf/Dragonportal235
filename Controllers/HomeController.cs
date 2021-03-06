﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dragonportal235.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Dragonportal235.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<FPUser> _userManager;

        //private readonly SignInManager

        public HomeController(ILogger<HomeController> logger, UserManager<FPUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
            return View();
        }
       
        public async Task<IActionResult> Lobby()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.HouseholdId != null)
            {
                return RedirectToAction("Details", "Households", new { id = user.HouseholdId });
            }
            else
            {

                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
