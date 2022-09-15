using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MULTI.Models;
using MULTI.Util;
using System.Diagnostics;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MULTI.Areas.Identity.Data;
using MULTI.Services;

namespace MULTI.Controllers
{

   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TenantSettings tenantSettings;
        private TenantService tenantService;
        private  readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public HomeController(ILogger<HomeController> logger, IOptions<TenantSettings> options, 
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> rolemanager,
                     TenantService tenantService)
        {

            _logger = logger;
            tenantSettings = options.Value;
            this.tenantService = tenantService;
            _userManager = userManager;
            _rolemanager = rolemanager;
        }
        

        public IActionResult Index()
        {
            IEnumerable<TenantSiteModel>? sites;
            //SI esta autenticado muestrele las empresad creadas  para que determine con cual quiere trabajar
            if (User.Identity.IsAuthenticated)
            {
                //SELECT * FROM EMPRESA

            }

            //Muestre siempre los tipos de empresa que  se pueden crear (Post,ferreteria,drogueria...)
            var site = tenantService.GetTenant();
            if (site != null)
            {
                ViewBag.SelectedSite = new TenantSiteModel
                {
                    Key = tenantService.GetTenantCode(),
                    Logo = ".logo",
                    Name = "site.name"
                };
            }

           
           


            sites = tenantSettings.Sites.Select(s => new TenantSiteModel
            {
                Key = s.Key,
                Logo = "Ruta del logo", //   s.Value.logo,
                Name = s.Value.connectionString // "Nombre empresa",// s.Value.name
            }).ToList();


            return View(sites);
        }


        public IActionResult SelectSite(string site)
        {
            if (tenantSettings.Sites.ContainsKey(site))
            {
                Response.Cookies.Append("tenant-code", site);
            }

            return RedirectToAction("Index");
        }

        public IActionResult UnselectSite(string site)
        {
            if (tenantSettings.Sites.ContainsKey(site))
            {
                Response.Cookies.Delete("tenant-code");
            }

            return RedirectToAction("Index");
        }


        [Authorize(Roles ="Mod")]
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