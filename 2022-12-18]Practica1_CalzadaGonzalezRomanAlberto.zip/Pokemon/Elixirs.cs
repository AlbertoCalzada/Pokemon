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
        public override void Buy()
        {
            // Acciones para comprar el item
        }

        public override void Sell()
        {
            // Acciones para vender el item
        }
        public Elixirs AsignEther()
        {
            Elixirs Ether = new Elixirs("Ether", 100, 100, 100, 100, 100, 100,10);
            Ether.AddQuantity(1);
            return Ether;
        }
        public Elixirs AsignMaxEther()
        {
            Elixirs MaxEther = new Elixirs("MaxEther", 100, 100, 100, 100, 100, 100,10 );
            MaxEther.AddQuantity(1);
            return MaxEther;
        }
        public Elixirs AsignElixir()
        {
            Elixirs Elixir = new Elixirs("Elixir", 100, 100, 100, 100, 100, 100, 10);
            Elixir.AddQuantity(1);
            return Elixir;
        }
        public Elixirs AsignMaxElixir()
        {
            Elixirs MaxElixir = new Elixirs("MaxElixir", 100, 100, 100, 100, 100, 100, 10);
            MaxElixir.AddQuantity(1);
            return MaxElixir;
        }
        //public int AmountUtilityItem(Elixirs elixir)
        //{
        //    if (elixir.name == "Ether")
        //    {
               
        //    }
        //    if (elixir.name == "MaxEther")
        //    {

        //    }
        //    if (elixir.name == "Elixir")
        //    {

        //    }
        //    if (elixir.name == "MaxElixir")
        //    {

        //    }

        //}
    }
}
