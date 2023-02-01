using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class PokeballItem: Item
    {
        double ratioCapture;
        public PokeballItem(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints, double ratioCapture)
             : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.ratioCapture = ratioCapture;
        }
        public override bool UseItemOutCombat()
        {
            return true;
        }
        public override bool ThrowItem()
        {
            return true;
        }

        public override bool UseItemInCombat()
        {
            return true;
        }

        public override void Utility(IndividualPokemon pokemon)
        {

        }
        public override bool Buy()
        {
            return true;
        }

        public override bool Sell()
        {
            return true;
        }

        public double GetRatioCapture()
        {
            return ratioCapture;
        }
    }
}
