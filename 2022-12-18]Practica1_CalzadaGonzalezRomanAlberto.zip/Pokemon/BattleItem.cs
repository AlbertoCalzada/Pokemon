using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    abstract class BattleItem:Item
    {
        public BattleItem(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
            : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

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
    }
    class Pokedoll : BattleItem
    {
        public Pokedoll(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints) 
        { 
        
        
        }
        
    }
}
