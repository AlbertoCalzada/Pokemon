using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Elixirs : Medicine
    {
        int ppRestore;
        public Elixirs() : base() { }
        public Elixirs(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints, int ppRestore)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.ppRestore = ppRestore;
        }
        public override void UseItem(IndividualPokemon pokemon)
        {
            if (name == "Revivir")
            {
                if (pokemon.GetCurrentHP() == 0)
                {
                    pokemon.SetHpmax(pokemon.GetHpmax() / 2);
                }
            }
            if (name == "MaxRevivir")
            {
                if (pokemon.GetCurrentHP() == 0)
                {
                    pokemon.SetHpmax(pokemon.GetHpmax());
                }
            }
        }
        public Elixirs AsignElixir()
        {
            Elixirs E1 = new Elixirs("Elixir", 100, 100, 100, 100, 100, 100,20);
            E1.AddQuantity(1);
            return E1;
        }
    }
}
