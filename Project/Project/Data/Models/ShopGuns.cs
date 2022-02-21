using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data.Models
{
    public class ShopGuns
    {
        private readonly AppDBContent appDBcontent;
        public ShopGuns(AppDBContent appDBcontent)
        {
            this.appDBcontent = appDBcontent;
        }

        public string ShopGunsId { get; set; }
        public List<ShopGunsItem> listShopItems { get; set; }

        public static ShopGuns GetGuns(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopGunsId = session.GetString("GunsId") ?? Guid.NewGuid().ToString();
            session.SetString("GunsId", shopGunsId);

            return new ShopGuns(context)
            {
                ShopGunsId = shopGunsId
            };
        }

        public void AddToGuns(Guns guns)
        {
            appDBcontent.ShopGunsItem.Add(new ShopGunsItem 
            { 
                ShopGunsId = ShopGunsId,
                guns = guns,
                price = guns.price,
            });

            appDBcontent.SaveChanges();
        }
        public List<ShopGunsItem> getShopItems()
        {
            return appDBcontent.ShopGunsItem.Where(s => s.ShopGunsId == ShopGunsId).Include(s => s.guns).ToList();
        }
    }
}
