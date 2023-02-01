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
        public override void UseItem(IndividualPokemon pokemon)
        {

        }
        public override void ThrowItem(Item item)
        {
            
        }

        public override void UseItemInCombat(IndividualPokemon pokemon)
        {

        }
        public override void Buy()
        {
            // Acciones para comprar el item
        }

        public override void Sell()
        {
            // Acciones para vender el item
        }
    }
    class Pokedoll : BattleItem
    {
        public Pokedoll(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints) 
        { 
        
        
        }
        public override void Buy()
        {
            // Acciones para comprar el item
        }

        public override void Sell()
        {
            // Acciones para vender el item
        }

    }
}
