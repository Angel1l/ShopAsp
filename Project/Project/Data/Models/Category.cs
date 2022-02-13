using System.Collections.Generic;

namespace Project.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string desc { get; set; }
        public List<Guns> guns { get; set; }
    }
}
