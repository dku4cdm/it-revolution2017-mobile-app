using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITRevolution2017MobileApp.Interfaces;
using ITRevolution2017MobileApp.Objects;
using ITRevolution2017MobileApp.Enums;
using StructureMap;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container(_ =>
            {
                _.Scan(x => 
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });


            for (int i = 1; i <= 10; i++)
            {
                var user = new User("user" + i, i, i, Gender.Female, i + 2 * i, 1 + i * 7);
                user.GetAllDataFromDatabase();
            }
            var userMain = User.Users.FirstOrDefault();
            userMain.SaveDataToDatabase();
            User.Users.Clear();
            userMain.GetAllDataFromDatabase();
            Console.ReadKey();
        }
    }
}
