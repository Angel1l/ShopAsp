using Project.Data.Models;
using System.Collections.Generic;

namespace Project.Data.Interface
{
    public interface IAllGuns
    {
        IEnumerable<Guns> Guns { get; }
        IEnumerable<Guns> getFavGuns { get; set; }
        Guns getObjectGuns(int gunsid);
    }
}
