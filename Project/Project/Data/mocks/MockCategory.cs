using Project.Data.Interface;
using Project.Data.Models;
using System.Collections.Generic;

namespace Project.Data.mocks
{
    public class MockCategory : IGunsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {                   
                    new Category { categoryName = "Пистолеты", desc = "123"},
                    new Category { categoryName = "Снайперские винтовки", desc = "123"},                    
                };
            }
        }
    }
}
