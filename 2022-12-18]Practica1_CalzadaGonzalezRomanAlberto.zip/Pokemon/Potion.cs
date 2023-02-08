using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Potion : Medicine
    {
        int amountToHeal;
        IndividualPokemon pokemon;
        public Potion() : base() { }
        public Potion(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            
        }

        public override void Utility(IndividualPokemon pokemon)
        {
            if (name == "Pocion")
            {
                pokemon.AddCurrentHP(20);
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetCurrentHP(pokemon.GetHpmax());
                }
            }
            if (name == "SuperPocion")
            {
                pokemon.AddCurrentHP(60);
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetCurrentHP(pokemon.GetHpmax());
                }
            }
            if (name == "HiperPocion")
            {
                pokemon.AddCurrentHP(200);
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetCurrentHP(pokemon.GetHpmax());
                }
            }
            if (name == "MaxPocion")
            {
                pokemon.AddCurrentHP(pokemon.GetHpmax());
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetCurrentHP(pokemon.GetHpmax());
                }
            }
        }  
        public Potion AssignPotion()
        {
            Potion Pocion = new Potion("Pocion", 100, 100, 100, 100, 100, 100);
            Pocion.AddQuantity(1);
            return Pocion;
        }
        public Potion AssignSuperPotion()
        {
            Potion SuperPocion = new Potion("SuperPocion", 100, 100, 100, 100, 100, 100);
            SuperPocion.AddQuantity(1);
            return SuperPocion;
        }
        public Potion AssignHyperPotion()
        {
            Potion HiperPocion = new Potion("HiperPocion", 100, 100, 100, 100, 100, 100);
            HiperPocion.AddQuantity(1);
            return HiperPocion;
        }
        public Potion AssignMaxPotion()
        {
            Potion MaxPocion = new Potion("MaxPocion", 100, 100, 100, 100, 100, 100);
            MaxPocion.AddQuantity(1);
            return MaxPocion;
        }

    }
}
