using Microsoft.AspNetCore.Mvc;
using Project.Data.Interface;
using Project.Data.Models;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allorders;
        private readonly ShopGuns shopGuns;
        public OrderController(IAllOrders allorders, ShopGuns shopGuns)
        {
            this.allorders = allorders;
            this.shopGuns = shopGuns;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopGuns.listShopItems = shopGuns.getShopItems();
            if (shopGuns.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","Нету товаров");
            }
            if (ModelState.IsValid)
            {
                allorders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
