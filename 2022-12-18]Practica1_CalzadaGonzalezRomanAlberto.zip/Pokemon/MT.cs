using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class MT:Item
    {
        Movements mt;
        public MT(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

        }
        public override void UseItem(IndividualPokemon pokemon)
        {

        }
        public override void ThrowItem(Item item)
        {

        }

        public override void UseItemInCombat(IndividualPokemon pokemon)
        {

        }
    }
}
