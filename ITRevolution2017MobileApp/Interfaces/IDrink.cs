﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRevolution2017MobileApp.Interfaces
{
    public interface IDrink
    {
        double Amount { get; set; }
        double Strong { get; set; }
        string Name { get; set; }
        List<IIngredient> Ingredients { get; set; }
    }
}
