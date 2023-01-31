﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
     abstract class Medicine : Item
    {
        Bag bag = new Bag();
        public Medicine() : base() { }
        public Medicine(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
            :base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            
        }

        public override void UseItem(IndividualPokemon pokemon)
        {
            
        }
        public override void ThrowItem(Item item)
        {
            bag.RemoveItem(item, 1);
        }

        public override void UseItemInCombat(IndividualPokemon pokemon)
        {
           
        }

       

    }
}