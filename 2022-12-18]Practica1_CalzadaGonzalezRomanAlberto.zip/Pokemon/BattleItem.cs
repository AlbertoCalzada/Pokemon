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
        public BattleItem() : base() { }
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
    }
    class Pokedoll : BattleItem
    {
        public Pokedoll(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints) 
        { 
        
        
        }
        public Pokedoll() : base() { }
        public Pokedoll AssignPokedoll()
        {
            Pokedoll P1 = new Pokedoll("Pokedoll", 100, 100, 100, 100, 100, 100);
            P1.AddQuantity(1);
            return P1;
        }
        public override void Utility(IndividualPokemon pokemon)
        {
            pokemon.SetHasEscaped(true);
            
        }
    }
}
