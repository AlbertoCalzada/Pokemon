using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Revives:Medicine
    {
        IndividualPokemon pokemon;
        int amountToHeal;
        public Revives(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
        }
        public Revives() : base() { }

        public override void Utility(IndividualPokemon pokemon)
        {
            if (name == "Revivir")
            {
                if (pokemon.GetCurrentHP() == 0)
                {
                    pokemon.SetCurrentHP(pokemon.GetHpmax()/2);
                }                                                 
            }
            if (name == "MaxRevivir")
            {
                if (pokemon.GetCurrentHP() == 0)
                {
                    pokemon.SetCurrentHP(pokemon.GetHpmax());
                }
            }          
        }

        //A continuaciñon tenemos las instancias de los objetos pertenicientes a esta clase.
        public Revives AssignRevive()
        {
            Revives P1 = new Revives("Revivir", 100, 100, 100, 100, 100, 100);
            P1.AddQuantity(1);
            return P1;
        }
        public Revives AssignMaxRevive()
        {
            Revives P1 = new Revives("MaxRevivir", 100, 100, 100, 100, 100, 100);
            P1.AddQuantity(1);
            return P1;
        }
    }
}
