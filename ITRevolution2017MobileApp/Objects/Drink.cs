using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ITRevolution2017MobileApp.Interfaces;
using System.IO;

namespace ITRevolution2017MobileApp.Objects
{
    public class Drink : IProviderDB, IDrink
    {
        public static List<Drink> ListOfDrinks { get; set; }
        [JsonProperty("Amount")]
        public double Amount { get; set; }
        [JsonProperty("Strong")]
        public double Strong { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Ingredients")]
        public List<IIngredient> Ingredients { get; set; }

        private Drink()
        {

        }
        public Drink(string name, double strong, List<IIngredient> ingredients, double amount)
        {
            ListOfDrinks = ListOfDrinks == null ? new List<Drink>() : ListOfDrinks;
            Name = name != null ? name : string.Empty;
            Strong = strong != 0 ? strong : default(double);
            Ingredients = ingredients != null ? ingredients : new List<IIngredient>();
            Amount = amount;
            ListOfDrinks.Add(this);
        }

        public void SaveDataToDatabase()
        {
            var jsonContent = JsonConvert.SerializeObject(ListOfDrinks);
            StreamWriter streamWriter = new StreamWriter("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\DrinksData.json", false, Encoding.UTF8);
            streamWriter.Write(jsonContent);
            streamWriter.WriteLine();
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public void GetAllDataFromDatabase()
        {
            StreamReader streamReader = new StreamReader("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\DrinksData.json", true);
            var data = streamReader.ReadToEnd();
            ListOfDrinks = JsonConvert.DeserializeObject<List<Drink>>(data);
            streamReader.Close();
            streamReader.Dispose();
        }

        public static Drink GetDrinkByName(string name)
        {
            Drink resultDrink = new Drink();
            ListOfDrinks.ForEach(drink =>
            {
                if (drink.Name == name)
                {
                    resultDrink = drink;
                }
            });
            return resultDrink;
        }

        public void DeleteDataFromDatabase()
        {
            ListOfDrinks.Remove(this);
            var jsonContent = JsonConvert.SerializeObject(ListOfDrinks);
            StreamWriter streamWriter = new StreamWriter("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\DrinksData.json", false, Encoding.UTF8);
            streamWriter.Write(jsonContent);
            streamWriter.WriteLine();
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
