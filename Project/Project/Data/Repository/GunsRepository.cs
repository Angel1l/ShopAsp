using Microsoft.EntityFrameworkCore;
using Project.Data.Interface;
using Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data.Repository
{
    public class GunsRepository : IAllGuns
    {
        private readonly AppDBContent appDBcontent;
        public GunsRepository(AppDBContent appDBcontent)
        {
            this.appDBcontent = appDBcontent;
        }
        public IEnumerable<Guns> Guns => appDBcontent.Guns.Include(g => g.Category);

        public IEnumerable<Guns> getFavGuns => appDBcontent.Guns.Where(g => g.isFavorite).Include(g => g.Category);

        public Guns getObjectGuns(int gunsid) => appDBcontent.Guns.FirstOrDefault(g => g.id == gunsid);

    }
}
