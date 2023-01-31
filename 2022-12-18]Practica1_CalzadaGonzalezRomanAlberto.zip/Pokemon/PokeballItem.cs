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
        public override void UseItem(IndividualPokemon pokemon)
        {

        }
        public override void ThrowItem(Item item)
        {

        }

        public override void UseItemInCombat(IndividualPokemon pokemon)
        {

        }

        public int GetRatioCapture()
        {
            return ratioCapture;
        }
    }
}
