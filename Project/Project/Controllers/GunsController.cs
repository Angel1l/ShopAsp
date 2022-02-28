using Microsoft.AspNetCore.Mvc;
using Project.Data.Interface;
using Project.Data.Models;
using Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [Route("Guns/List")]
        [Route("Guns/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Guns> guns = null;
            string gunsCategory = "";
            if(string.IsNullOrEmpty(category))
            {
                guns = _allGuns.Guns.OrderBy(guns => guns.id);
            }
            else
            {
                if(string.Equals("pistols",category, StringComparison.OrdinalIgnoreCase))
                {
                    guns = _allGuns.Guns.Where(g => g.Category.categoryName.Equals("Пистолеты")).OrderBy(guns => guns.id);
                    gunsCategory = "Пистолеты";
                }
                else if(string.Equals("snipers", category, StringComparison.OrdinalIgnoreCase))
                {
                    guns = _allGuns.Guns.Where(g => g.Category.categoryName.Equals("Снайперские винтовки")).OrderBy(guns => guns.id);
                    gunsCategory = "Снайперские винтовки";
                }

            }
            var gunsObj = new GunsListViewModel
            {
                allGuns = guns,
                gunsCategory = gunsCategory,
            };

            ViewBag.Title = "Страница с оружием";           
            return View(gunsObj);
        }
    }
}
