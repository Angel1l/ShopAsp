using Microsoft.AspNetCore.Mvc;
using Project.Data.Interface;

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
            var guns = _allGuns.Guns;
            return View(guns);
        }
    }
}
