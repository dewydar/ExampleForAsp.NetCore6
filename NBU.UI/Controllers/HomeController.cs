using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using NBU.DAL.Common;
using NBU.UI.Models;
using System.Diagnostics;

namespace NBU.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpContextAccessor _httpContextAccessor;
        
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor as HttpContextAccessor;
            AppSetting.CurrentLanguage = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
            //string CurrentLang = HttpContext.Request.Cookies["CurrentLang"];
            //string currentLang = HttpContext.Features.Get<Microsoft.AspNetCore.Localization.IRequestCultureFeature>().RequestCulture.Culture.Name;
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        [HttpPost]
        public IActionResult SetAppLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) });

            AppSetting.CurrentLanguage = culture;
            return LocalRedirect(returnUrl);
        }
    }
}