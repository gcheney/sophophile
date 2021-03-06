using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft​.AspNetCore​.Diagnostics;
using Thoughtwave.Data;
using Thoughtwave.Models;
using Thoughtwave.ViewModels.ThoughtViewModels;
using AutoMapper;

namespace Thoughtwave.Controllers
{
    public class HomeController : Controller
    {
        private readonly IThoughtwaveRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public HomeController(IThoughtwaveRepository repository, 
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var thoughts = await _repository.GetRecentThoughtsAsync();

            if (thoughts == null)
            {
                _logger.LogError("Unable to get recent thoughts from repository");
                return View("Error");
            }

            if (!thoughts.Any())
            {
                ViewBag.Message = "No recent thoughts were found";
            }

            var model = _mapper.Map<IEnumerable<ThoughtViewModel>>(thoughts);
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Exception()
        {
            // show generic error page
            return View("Error");
        }

        [HttpGet]
        [Route("/home/error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                var statusFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                if (statusFeature != null)
                {
                    _logger.LogWarning($"Handled 404 for url: {statusFeature.OriginalPath}");
                }
            }

            return View("Error", statusCode);
        }
    }
}
