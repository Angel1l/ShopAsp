using Project.Data.Models;
using System.Collections.Generic;

namespace Project.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Guns> favGuns { get; set; }
    }
}
