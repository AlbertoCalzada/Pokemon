using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Elixirs:Medicine
    {
        int ppRestore;
        public Elixirs() : base() { }
        public Elixirs(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

        }
        
        public Elixirs AsignElixir()
        {
            Elixirs E1 = new Elixirs("Elixir", 100, 100, 100, 100, 100, 100);
            E1.AddQuantity(1);
            return E1;
        }
    }
}
