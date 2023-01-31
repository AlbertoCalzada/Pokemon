using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class EvolutionStone:Item
    {
        public EvolutionStone(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
            : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

        }
        public override bool UseItem()
        {
            return true;
        }
        public override bool ThrowItem()
        {
            return true;
        }
        public override bool UseItemInCombat()
        {
            return false; ;
        }
    }
}
