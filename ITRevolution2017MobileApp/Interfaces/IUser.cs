using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITRevolution2017MobileApp.Enums;

namespace ITRevolution2017MobileApp.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        int Age { get; set; }
        double Weight { get; set; }
        Gender Gender { get; set; }
        bool FingerScanner { get; set; }
        int? Telephone_Taxi { get; set; }
        int? Telephone_Friend { get; set; }
    }
}
