using Project.Data.Models;
using System.Collections.Generic;

namespace Project.ViewModels
{
    public class GunsListViewModel
    {
        public IEnumerable<Guns> allGuns { get; set; }
        public string gunsCategory { get; set; }
    }
}
