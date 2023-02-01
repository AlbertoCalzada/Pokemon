using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Elixirs : Medicine
    {
        int ppRestore;
        IO io= new IO();
        public Elixirs() : base() { }
        public Elixirs(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            
        }
        public override void Utility(IndividualPokemon pokemon)
        {
            io.SlowWrite("¿De qué movimiento quieres recuperar sus PP?");
            int ppMovement=io.AskNumber();
            if (name == "Ether")
            {
                pokemon.GetMovements()[ppMovement].AddPp(10);
                if (pokemon.GetMovements()[ppMovement].GetPp()>=pokemon.GetMovements()[ppMovement].GetPpMax())
                {
                    pokemon.GetMovements()[ppMovement].SetPp(pokemon.GetMovements()[ppMovement].GetPpMax());
                }
            }
            if (name == "MaxEther")
            {
                pokemon.GetMovements()[ppMovement].AddPp(10);
                if (pokemon.GetMovements()[ppMovement].GetPp() >= pokemon.GetMovements()[ppMovement].GetPpMax())
                {
                    pokemon.GetMovements()[ppMovement].SetPp(pokemon.GetMovements()[ppMovement].GetPpMax());
                }
            }
            if (name == "Elixir")
            {
                pokemon.GetMovements()[ppMovement].AddPp(10);
                if (pokemon.GetMovements()[ppMovement].GetPp() >= pokemon.GetMovements()[ppMovement].GetPpMax())
                {
                    pokemon.GetMovements()[ppMovement].SetPp(pokemon.GetMovements()[ppMovement].GetPpMax());
                }
            }
            if (name == "MaxElixir")
            {
                pokemon.GetMovements()[ppMovement].AddPp(10);
                if (pokemon.GetMovements()[ppMovement].GetPp() >= pokemon.GetMovements()[ppMovement].GetPpMax())
                {
                    pokemon.GetMovements()[ppMovement].SetPp(pokemon.GetMovements()[ppMovement].GetPpMax());
                }
            }
        }
       
        public Elixirs AsignEther()
        {
            Elixirs Ether = new Elixirs("Ether", 100, 100, 100, 100, 100, 100);
            Ether.AddQuantity(1);
            return Ether;
        }
        public Elixirs AsignMaxEther()
        {
            Elixirs MaxEther = new Elixirs("MaxEther", 100, 100, 100, 100, 100, 100);
            MaxEther.AddQuantity(1);
            return MaxEther;
        }
        public Elixirs AsignElixir()
        {
            Elixirs Elixir = new Elixirs("Elixir", 100, 100, 100, 100, 100, 100);
            Elixir.AddQuantity(1);
            return Elixir;
        }
        public Elixirs AsignMaxElixir()
        {
            Elixirs MaxElixir = new Elixirs("MaxElixir", 100, 100, 100, 100, 100, 100);
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
