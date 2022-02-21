using Microsoft.AspNetCore.Mvc;
using Project.Data.Interface;
using Project.Data.Models;
using Project.Data.Repository;
using Project.ViewModels;
using System.Linq;

namespace Project.Controllers
{
    public class ShopGunsController : Controller
    {
        private readonly IAllGuns _gunsRep;
        private readonly ShopGuns _shopGuns;

        public ShopGunsController(IAllGuns gunRep, ShopGuns shopGuns)
        {
            _gunsRep = gunRep;
            _shopGuns = shopGuns;
        }
        public ViewResult Index()
        {
            var items = _shopGuns.getShopItems();
            _shopGuns.listShopItems = items;

            var obj = new ShopGunsViewModel
            {
                shopGuns = _shopGuns
            };

            return View(obj);
        }
        public RedirectToActionResult addToGuns(int id)
        {
            var item = _gunsRep.Guns.FirstOrDefault(i => i.id == id);
            if (item == null)
            {
                _shopGuns.AddToGuns(item);
            }
            return RedirectToAction("Index");
        }
    }
}
