using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MULTI.Models;
using MULTI.Util;
using System.Diagnostics;

using Microsoft.Extensions.Configuration;

namespace MULTI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TenantSettings tenantSettings;
        public HomeController(ILogger<HomeController> logger, IOptions<TenantSettings> options)
        {
            tenantSettings = options.Value;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var sites = tenantSettings.Sites.Select(s => new TenantSiteModel
            {
                Key = s.Key,
                Logo = "Ruta del logo", //   s.Value.logo,
                Name =  s.Value.connectionString // "Nombre empresa",// s.Value.name
            }).ToList();

            return View(sites);
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