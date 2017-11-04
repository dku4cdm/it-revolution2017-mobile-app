using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRevolution2017MobileApp.Interfaces
{
    public interface IMeter
    {
        void GetDrinkCharacteristics(IDrink drink);
        void GetUserCharacteristics(IUser user);
    }
}
