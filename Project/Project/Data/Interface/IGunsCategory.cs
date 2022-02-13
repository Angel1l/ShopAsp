using Project.Data.Models;
using System.Collections.Generic;

namespace Project.Data.Interface
{
    public interface IGunsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
