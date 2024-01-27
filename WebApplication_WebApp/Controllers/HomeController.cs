using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System.Diagnostics;
using WebApplication_WebApp.Repository.IRepository;
using WebApplication_WebApp.Models;
using WebApplication_WebApp.Models.ViewModels;


namespace WebApplication_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly ITrailRepository _trailRepository;

        public HomeController(ILogger<HomeController> logger,INationalParkRepository nationalParkRepository,ITrailRepository trailRepository)
        {
            _logger = logger;
            _nationalParkRepository = nationalParkRepository;
            _trailRepository = trailRepository;
        }

        public async Task<IActionResult> Index()
         {
            IndexVM indexVM = new IndexVM()
            {
                NationalParkList = await _nationalParkRepository.GetAllAsync(SD.NationalParkAPIPath) ,
                TrailList = await _trailRepository.GetAllAsync(SD.TrailAPIPath) 
            };
            return View(indexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public async Task<IActionResult> IndexVM()
        //{
        //    IndexVM indexVm = new IndexVM()
        //    {
        //        NationalParkList = await _nationalParkRepository.GetAllAsync(SD.NationalParkAPIPath),
        //        TrailList = await _trailRepository.GetAllAsync(SD.TrailAPIPath)
        //    };
        //    return View(indexVm);
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}