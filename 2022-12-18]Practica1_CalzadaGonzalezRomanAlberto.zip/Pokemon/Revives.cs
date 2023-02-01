using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Revives:Medicine
    {
        IndividualPokemon pokemon;
        int amountToHeal;
        public Revives(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints, int amountToHeal)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.amountToHeal = amountToHeal;
        }
        public override void Utility(IndividualPokemon pokemon)
        {
            if (name == "Revivir")
            {
                if (pokemon.GetCurrentHP() == 0)
                {
                    pokemon.SetHpmax(pokemon.GetHpmax()/2);
                }                                                 
            }
            if (name == "MaxRevivir")
            {
                if (pokemon.GetCurrentHP() == 0)
                {
                    pokemon.SetHpmax(pokemon.GetHpmax());
                }
            }          
        }
       
        
        public Revives AsignRevive()
        {
            Revives P1 = new Revives("Revivir", 100, 100, 100, 100, 100, 100,pokemon.GetHpmax()/2);
            P1.AddQuantity(1);
            return P1;
        }
        public Revives AsignMaxRevive()
        {
            Revives P1 = new Revives("MaxRevivir", 100, 100, 100, 100, 100, 100,pokemon.GetHpmax());
            P1.AddQuantity(1);
            return P1;
        }
    }
}
