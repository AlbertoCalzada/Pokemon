using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class EvolutionStone:Item
    {
        public EvolutionStone(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
            : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

        }
        public EvolutionStone() : base() { }
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
            return false;
        }

        public override void Utility(IndividualPokemon pokemon)
        {
            switch (name)
            {
                case "WaterStone":
                    if(pokemon.GetName()== "Squirtle")
                    {
                        pokemon.SetName("Wartortle");
                        pokemon.SetNickName(pokemon.GetName());
                        pokemon.SetAttack(pokemon.GetAttack()+20);
                        pokemon.SetDefense(pokemon.GetDefense()+20);
                        pokemon.SetHpmax(pokemon.GetHpmax()+20);
                        pokemon.SetSpeed(pokemon.GetSpeed()+20);
                        pokemon.SetSpecialAttack(pokemon.GetSpecialAttack()+20);
                        pokemon.SetSpecialDefense(pokemon.GetSpecialDefense()+20);
                    }
                    break;
                case "FireStone":
                    if (pokemon.GetName() == "Charmander")
                    {
                        pokemon.SetName("Charmeleon");
                        pokemon.SetNickName(pokemon.GetName());
                        pokemon.SetAttack(pokemon.GetAttack() + 20);
                        pokemon.SetDefense(pokemon.GetDefense() + 20);
                        pokemon.SetHpmax(pokemon.GetHpmax() + 20);
                        pokemon.SetSpeed(pokemon.GetSpeed() + 20);
                        pokemon.SetSpecialAttack(pokemon.GetSpecialAttack() + 20);
                        pokemon.SetSpecialDefense(pokemon.GetSpecialDefense() + 20);

                    }
                    break;
                case "PlantStone":
                    if (pokemon.GetName() == "Bulbasaur")
                    {
                        pokemon.SetName("Ivysaur");
                        pokemon.SetNickName(pokemon.GetName());
                        pokemon.SetAttack(pokemon.GetAttack() + 20);
                        pokemon.SetDefense(pokemon.GetDefense() + 20);
                        pokemon.SetHpmax(pokemon.GetHpmax() + 20);
                        pokemon.SetSpeed(pokemon.GetSpeed() + 20);
                        pokemon.SetSpecialAttack(pokemon.GetSpecialAttack() + 20);
                        pokemon.SetSpecialDefense(pokemon.GetSpecialDefense() + 20);
                    }
                    break;

            }
        }
        public override bool Buy()
        {
            return true;
        }

        public override bool Sell()
        {
            return true;
        }
        public EvolutionStone AssignWaterStone()
        {
            EvolutionStone WaterStone = new EvolutionStone("WaterStone", 6000, 0, 0, 6000, 0, 0);
            WaterStone.AddQuantity(1);
            return WaterStone;
        }
        public EvolutionStone AssignFireStone()
        {
            EvolutionStone FireStone = new EvolutionStone("FireStone", 6000, 0, 0, 6000, 0, 0);
            FireStone.AddQuantity(1);
            return FireStone;
        }

        public EvolutionStone AssignPlantStone()
        {
            EvolutionStone PlantStone = new EvolutionStone("PlantStone", 6000, 0, 0, 6000, 0, 0);
            PlantStone.AddQuantity(1);
            return PlantStone;
        }
    }
}
