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
        public EvolutionStone() : base() { }
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
            return false;
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
        public EvolutionStone AssignWaterStone()
        {
            EvolutionStone WaterStone = new EvolutionStone("WaterStone", 6000, 0, 0, 0, 0, 0);
            WaterStone.AddQuantity(1);
            return WaterStone;
        }
    }
}
