using Project.Data.Interface;
using Project.Data.Models;
using System;

namespace Project.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopGuns shopGuns;
        public OrdersRepository(AppDBContent appDBContent, ShopGuns shopGuns)
        {
            this.appDBContent = appDBContent;
            this.shopGuns = shopGuns;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now; 
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = shopGuns.listShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    GunsID = el.guns.id,
                    orderID = order.id,
                    price = el.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
                
            }
            appDBContent.SaveChanges();
        }
    }
}
