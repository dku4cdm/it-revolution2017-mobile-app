using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ITRevolution2017MobileApp.Interfaces;

namespace ITRevolution2017MobileApp.Objects
{
    public class Ingredient : IProviderDB, IIngredient
    {
        public static List<Ingredient> ListOfIngredients { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("StrongModificator")]
        public double StrongModificator { get; set; }
        private Ingredient()
        {

        }
        public Ingredient(string name, string description, double strongModificator)
        {
            ListOfIngredients = ListOfIngredients == null ? new List<Ingredient>() : ListOfIngredients;
            Name = name != null ? name : string.Empty;
            Description = description != null ? description : string.Empty;
            StrongModificator = strongModificator != 0 ? strongModificator : default(double);
            ListOfIngredients.Add(this);
        }
        public void SaveDataToDatabase()
        {
            var jsonContent = JsonConvert.SerializeObject(ListOfIngredients);
            StreamWriter streamWriter = new StreamWriter("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\IngredientsData.json", append: false, encoding: Encoding.UTF8);
            streamWriter.Write(jsonContent);
            streamWriter.WriteLine();
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public void GetAllDataFromDatabase()
        {
            StreamReader streamReader = new StreamReader("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\IngredientsData.json", true);
            var data = streamReader.ReadToEnd();
            ListOfIngredients = JsonConvert.DeserializeObject<List<Ingredient>>(data);
            streamReader.Close();
            streamReader.Dispose();
        }

        public static Ingredient GetIngredientByName(string name)
        {
            Ingredient resultIngredient = new Ingredient();
            ListOfIngredients.ForEach(ingredient =>
            {
                if (ingredient.Name == name)
                {
                    resultIngredient = ingredient;
                }
            });
            return resultIngredient;
        }
        public void DeleteDataFromDatabase()
        {
            ListOfIngredients.Remove(this);
            var jsonContent = JsonConvert.SerializeObject(ListOfIngredients);
            StreamWriter streamWriter = new StreamWriter("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\IngredientsData.json", append: false, encoding: Encoding.UTF8);
            streamWriter.Write(jsonContent);
            streamWriter.WriteLine();
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
