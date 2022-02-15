using Microsoft.AspNetCore.Mvc;
using Project.Data.Interface;
using Project.ViewModels;

namespace Project.Controllers
{
    public class GunsController : Controller
    {
        private readonly IAllGuns _allGuns;       
        private readonly IGunsCategory _gunsCategory;

        public GunsController(IAllGuns iAllGuns, IGunsCategory iGunsCategory)
        {
            _allGuns = iAllGuns;
            _gunsCategory = iGunsCategory;
        }
     
        public ViewResult List()
        {
            ViewBag.Title = "Страница с оружием";
            GunsListViewModel obj = new GunsListViewModel();
            obj.allGuns = _allGuns.Guns;
            obj.gunsCategory = "Pistols";
            return View(obj);
        }
    }
}
