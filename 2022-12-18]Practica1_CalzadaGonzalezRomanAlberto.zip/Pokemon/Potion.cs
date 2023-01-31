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
        public Potion(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints, int amountToHeal)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.amountToHeal = amountToHeal;
        }

        public override void UseItem(IndividualPokemon pokemon)
        {
            if (name == "Pocion")
            {
                pokemon.AddCurrentHP(20);
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetHpmax(pokemon.GetHpmax());
                }
            }
            if (name == "SuperPocion")
            {
                pokemon.AddCurrentHP(60);
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetHpmax(pokemon.GetHpmax());
                }
            }
            if (name == "HiperPocion")
            {
                pokemon.AddCurrentHP(200);
                if (pokemon.GetCurrentHP() > pokemon.GetHpmax())
                {
                    pokemon.SetHpmax(pokemon.GetHpmax());
                }
            }
            if (name == "MaxPocion")
            {
                pokemon.AddCurrentHP(pokemon.GetHpmax());
            }
        }
       

        public override void UseItemInCombat(IndividualPokemon pokemon)
        {
            UseItem(pokemon);
        }
        public Potion AsignPotion()
        {
            Potion P1 = new Potion("Pocion", 100, 100, 100, 100, 100, 100, 20);
            P1.AddQuantity(1);
            return P1;
        }
        public Potion AsignSuperPotion()
        {
            Potion P1 = new Potion("SuperPocion", 100, 100, 100, 100, 100, 100, 60);
            P1.AddQuantity(1);
            return P1;
        }
        public Potion AsignHyperPotion()
        {
            Potion P1 = new Potion("HiperPocion", 100, 100, 100, 100, 100, 100, 200);
            P1.AddQuantity(1);
            return P1;
        }
        public Potion AsignMaxPotion()
        {
            Potion P1 = new Potion("MaxPocion", 100, 100, 100, 100, 100, 100, pokemon.GetHpmax());
            P1.AddQuantity(1);
            return P1;
        }

    }
}
