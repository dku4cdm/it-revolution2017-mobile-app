using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITRevolution2017MobileApp.Interfaces;
using ITRevolution2017MobileApp.Enums;

namespace ITRevolution2017MobileApp.Objects
{
    public class Meter : IMeter
    {
        private double Strong { get; set; }
        private double Amount { get; set; }
        private Gender Gender { get; set; }
        private double Weight { get; set; }
        private double StrongModificator { get; set; }
        private double Promile { get; set; }
        private void ConvertStrongToPromileByVidmark()
        {
            const double coeficientEtanol = 0.79;
            const double bloodResistance = 0.9;
            double genderCorrection = Gender == Gender.Male ? 0.7 : 0.6;
            double realWeight = Weight * genderCorrection;
            double realAmount = Amount * (Strong / 100) * coeficientEtanol * bloodResistance;
            Promile = Math.Round(realAmount / realWeight, 4);
        }
        public void GetDrinkCharacteristics(IDrink drink)
        {
            Strong = drink.Strong;
            Amount = drink.Amount;
            drink.Ingredients.ForEach(ing =>
            {
                StrongModificator += ing.StrongModificator;
            });
        }
        public void GetUserCharacteristics(IUser user)
        {
            Gender = user.Gender;
            Weight = user.Weight;
        }
        public double GetPromile()
        {
            ConvertStrongToPromileByVidmark();
            return Promile;
        }
    }
}
