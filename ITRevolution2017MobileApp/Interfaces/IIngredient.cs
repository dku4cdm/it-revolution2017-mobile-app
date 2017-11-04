using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRevolution2017MobileApp.Interfaces
{
    public interface IIngredient
    {
        string Name { get; set; }
        string Description { get; set; }
        double StrongModificator { get; set; }
    }
}
