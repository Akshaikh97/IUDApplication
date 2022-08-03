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
        private readonly IEmailService _emailService;

        public HomeController(IUserService userService, IEmailService emailService)
        {
            //_logger = logger;
            _userService = userService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com" },
            //    PlaceHolders= new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}", "Kasim")
            //    }
            //};
            //await _emailService.SendTestEmail(options);

            //var userId = _userService.GetUserId();
            //var isLoggedIn = _userService.IsAuthenticated();
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
