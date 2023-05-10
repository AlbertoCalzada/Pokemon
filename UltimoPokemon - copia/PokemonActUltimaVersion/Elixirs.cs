using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Elixirs : Medicine
    {

        IO io;
        public Elixirs() : base() { }
        public Elixirs(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            
        }
        public override void Utility(IndividualPokemon pokemon)
        {
            
            if (name == "Ether")
            {
                io.SlowWrite("¿De qué movimiento quieres recuperar sus PP?");
                for (int i = 0; i < 4; ++i)
                {
                    io.SlowWrite("\t" + (i + 1) + ". " + (pokemon.GetMovements()[i]).GetName() + " " + (pokemon.GetMovements()[i]).GetPp() + "/" + (pokemon.GetMovements()[i]).GetPpMax()
                        + " PS");
                }
                int ppMovement = io.AskNumber();
                pokemon.GetMovements()[ppMovement-1].AddPp(10);
                if (pokemon.GetMovements()[ppMovement - 1].GetPp()>=pokemon.GetMovements()[ppMovement - 1].GetPpMax())
                {
                    pokemon.GetMovements()[ppMovement - 1].SetPp(pokemon.GetMovements()[ppMovement - 1].GetPpMax());
                }
                io.SlowWrite("Has recuperado 10PP en el movimiento: " + pokemon.GetMovements()[ppMovement - 1].GetName()+ " de tu Pokémon: "+pokemon.GetNickName());
            }
            if (name == "MaxEther")
            {
                io.SlowWrite("¿De qué movimiento quieres recuperar sus PP?");
                int ppMovement = io.AskNumber();
                pokemon.GetMovements()[ppMovement - 1].AddPp(pokemon.GetMovements()[ppMovement - 1].GetPpMax());
                if (pokemon.GetMovements()[ppMovement - 1].GetPp() >= pokemon.GetMovements()[ppMovement - 1].GetPpMax())
                {
                    pokemon.GetMovements()[ppMovement - 1].SetPp(pokemon.GetMovements()[ppMovement - 1].GetPpMax());
                }
            }
            if (name == "Elixir")
            {
                for (int i = 0; i < pokemon.GetMovements().Length; ++i)
                {
                    pokemon.GetMovements()[i].AddPp(10);
                    if (pokemon.GetMovements()[i].GetPp() >= pokemon.GetMovements()[i].GetPpMax())
                    {
                        pokemon.GetMovements()[i].SetPp(pokemon.GetMovements()[i].GetPpMax());
                    }
                }
            }
            if (name == "MaxElixir")
            {
                for (int i = 0; i < pokemon.GetMovements().Length; ++i)
                {
                    pokemon.GetMovements()[i].AddPp(pokemon.GetMovements()[i].GetPpMax());
                    if (pokemon.GetMovements()[i].GetPp() >= pokemon.GetMovements()[i].GetPpMax())
                    {
                        pokemon.GetMovements()[i].SetPp(pokemon.GetMovements()[i].GetPpMax());
                    }
                }
            }
        }
       //A continuaciñon tenemos las instancias de los objetos pertenicientes a esta clase.
        public Elixirs AssignEther()
        {
            Elixirs Ether = new Elixirs("Ether", 100, 100, 100, 100, 100, 100);
            Ether.AddQuantity(1);
            return Ether;
        }
        public Elixirs AssignMaxEther()
        {
            Elixirs MaxEther = new Elixirs("MaxEther", 100, 100, 100, 100, 100, 100);
            MaxEther.AddQuantity(1);
            return MaxEther;
        }
        public Elixirs AssignElixir()
        {
            Elixirs Elixir = new Elixirs("Elixir", 100, 100, 100, 100, 100, 100);
            Elixir.AddQuantity(1);
            return Elixir;
        }
        public Elixirs AssignMaxElixir()
        {
            Elixirs MaxElixir = new Elixirs("MaxElixir", 100, 100, 100, 100, 100, 100);
            MaxElixir.AddQuantity(1);
            return MaxElixir;
        }
       
    }
}
