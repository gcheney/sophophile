using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sophophile.Data;
using Sophophile.Models;
using Sophophile.ViewModels.HomeViewModels;

namespace Sophophile.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationRepository _repository;
        private ILogger<HomeController> _logger;

        public HomeController(IApplicationRepository repository, 
            ILogger<HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomePageViewModel()
            {
                Questions = await _repository.GetAllQuestionsAsync()
            };
            
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
