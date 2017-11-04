using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ITRevolution2017MobileApp.Interfaces;
using ITRevolution2017MobileApp.Enums;

namespace ITRevolution2017MobileApp.Objects
{
    public abstract class Person
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("Weight")]
        public double Weight { get; set; }
        [JsonProperty("Avatar")]
        public Photo Avatar { get; set; }
        [JsonProperty("Gender")]
        public Gender Gender { get; set; }
        [JsonProperty("FingerScanner")]
        public bool FingerScanner { get; set; }
        public Person()
        {

        }
        public Person(string name, int age, double weight, Gender gender)
        {
            Name = name;
            Age = age;
            FingerScanner = false;
            Weight = weight;
            Gender = gender;
        }
        public Person(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            FingerScanner = false;
            Weight = weight;
        }
        public void EnableScanner()
        {
            FingerScanner = true;
        }
        public void DisableScanner()
        {
            FingerScanner = false;
        }

    }
    
    public class User : Person, IProviderDB, IUser
    {
        public static List<User> Users { get; set; }
        [JsonProperty("Telephone_Friend")]
        public int? Telephone_Friend { get; set; }
        [JsonProperty("Telephone_Taxi")]
        public int? Telephone_Taxi { get; set; }
        [JsonProperty("Profession")]
        public string Profession { get; set; }
        private User() : base()
        {
            
        }
        public User(string name, int age, double weight, Gender gender, int? telephoneFriend, int? telephoneTaxi) : base(name, age, weight, gender)
        {
            Users = Users == null ? new List<User>() : Users;
            Telephone_Friend = telephoneFriend;
            Telephone_Taxi = telephoneTaxi;
            Users.Add(this);
        }
        public User(string name, int age, double weight, string profession) : base(name, age, weight)
        {
            Profession = profession;
            Users.Add(this);
        }
        public void SaveDataToDatabase()
        {
            var jsonContent = JsonConvert.SerializeObject(Users);
            StreamWriter streamWriter = new StreamWriter("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\UsersData.json", append: false, encoding: Encoding.UTF8);
            streamWriter.Write(jsonContent);
            streamWriter.WriteLine();
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public void GetAllDataFromDatabase()
        {
            StreamReader streamReader = new StreamReader("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\UsersData.json", true);
            var data = streamReader.ReadToEnd();
            Users = JsonConvert.DeserializeObject<List<User>>(data);
            streamReader.Close();
            streamReader.Dispose();
        }

        public static User GetUserByName(string name)
        {
            User resultUser = new User();
            Users.ForEach(user =>
            {
                if (user.Name == name)
                {
                    resultUser = user;
                }
            });
            return resultUser;
        }

        public void DeleteDataFromDatabase()
        {
            Users.Remove(this);
            var jsonContent = JsonConvert.SerializeObject(Users);
            StreamWriter streamWriter = new StreamWriter("D:\\data\\it-revolution2017-mobile-app-logic\\ITRevolution2017MobileApp\\content\\UsersData.json", append: false, encoding: Encoding.UTF8);
            streamWriter.Write(jsonContent);
            streamWriter.WriteLine();
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
