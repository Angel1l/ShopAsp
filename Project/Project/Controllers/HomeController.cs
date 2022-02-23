using Microsoft.AspNetCore.Mvc;
using Project.Data.Interface;
using Project.ViewModels;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllGuns _gunsRep;
        
        public HomeController(IAllGuns gunRep)
        {
            _gunsRep = gunRep;
           
        }
        public ViewResult Index()
        {
            var homeGuns = new HomeViewModel
            {
                favGuns = _gunsRep.getFavGuns
            };
            return View(homeGuns);
        }
    }
}
