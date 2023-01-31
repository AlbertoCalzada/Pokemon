using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class PokeballItem: Item
    {
        int ratioCapture;
        public PokeballItem(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints, int ratioCapture)
             : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.ratioCapture = ratioCapture;
        }
        public override bool UseItem()
        {
            return false;
        }
        public override bool ThrowItem()
        {
            return true;
        }
        public override bool UseItemInCombat()
        {
            return true;
        }

        public int GetRatioCapture()
        {
            return ratioCapture;
        }
    }
}
