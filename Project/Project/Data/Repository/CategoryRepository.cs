using Microsoft.EntityFrameworkCore;
using Project.Data.Interface;
using Project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data.Repository
{
    public class CategoryRepository : IGunsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
