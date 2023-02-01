using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    abstract class Item
    {
        protected string name;
        protected int buyPricePokedollars;
        protected int buyPricePokemillas;
        protected int buyPriceBattlePoints;
        protected int sellPricePokedollars;
        protected int sellPricePokemillas;
        protected int sellPriceBattlePoints;
        protected int quantity;

        public Item() { }
        public Item(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        {
            this.name = name;
            this.buyPricePokedollars = buyPricePokedollars;
            this.buyPricePokemillas = buyPricePokemillas;
            this.buyPriceBattlePoints = buyPriceBattlePoints;
            this.sellPricePokedollars = sellPricePokedollars;
            this.sellPricePokemillas = sellPricePokemillas;
            this.sellPriceBattlePoints = sellPriceBattlePoints;
            quantity = 0;
        }

        public int GetQuantity()
        {
            return quantity;
        }
        
        public void AddQuantity(int add)
        {
            quantity = quantity+add;
        }
        public void RemoveQuantity(int add)
        {
            quantity = quantity - add;
        }
        public string GetName()
        {
            return name;
        }

        public int GetBuyPricePokedollars()
        {
            return buyPricePokedollars;
        }

        public int GetBuyPricePokemillas()
        {
            return buyPricePokemillas;
        }

        public int GetBuyPriceBattlePoints()
        {
            return buyPriceBattlePoints;
        }

        public int GetSellPricePokedollars()
        {
            return sellPricePokedollars;
        }

        public int GetSellPricePokemillas()
        {
            return sellPricePokemillas;
        }

        public int GetSellPriceBattlePoints()
        {
            return sellPriceBattlePoints;
        }
        public abstract void UseItem(IndividualPokemon pokemon);
        public abstract void ThrowItem(Item item);

        public abstract void UseItemInCombat(IndividualPokemon pokemon);

        public abstract void Buy();

        public abstract void Sell();
    }
}
