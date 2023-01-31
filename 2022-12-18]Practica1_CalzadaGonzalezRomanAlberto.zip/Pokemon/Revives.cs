using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Revives:Medicine
    {
        IndividualPokemon pokemon;
        public Revives(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            
        }
        public override void UseItem(IndividualPokemon pokemon)
        {

        }
       
        public override void UseItemInCombat(IndividualPokemon pokemon)
        {

        }
        public Revives AsignRevive()
        {
            Revives P1 = new Revives("Revivir", 100, 100, 100, 100, 100, 100);
            P1.AddQuantity(1);
            return P1;
        }
        public Revives AsignMaxRevive()
        {
            Revives P1 = new Revives("MaxRevivir", 100, 100, 100, 100, 100, 100);
            P1.AddQuantity(1);
            return P1;
        }
    }
}
