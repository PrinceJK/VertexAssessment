using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VertexAssessmentApp.Interface;
using VertexAssessmentApp.Models;
using VertexAssessmentApp.Models.Context;
using VertexAssessmentApp.ViewModel;

namespace VertexAssessmentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserDetailRepository _userDetailRepository;

        public HomeController(ILogger<HomeController> logger, IUserDetailRepository userDetailRepository)
        {
            _logger = logger;
            _userDetailRepository = userDetailRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(UserDetailsViewModel model)
        {
            var userId = await _userDetailRepository.AddUserDetailsAsync(model);
            return RedirectToAction("HelloUser", new {id = userId});
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> HelloUser(Guid id)
        {
            var user = await _userDetailRepository.GetUserDetails(id);
            if (user == null) return NotFound();
            return View(user);
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
