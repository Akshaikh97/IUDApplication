using IUDApplication.Models;
using IUDApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IUDApplication.Controllers
{
    public class HomeController : Controller
    {
        
        //private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            //_logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            return View();
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
