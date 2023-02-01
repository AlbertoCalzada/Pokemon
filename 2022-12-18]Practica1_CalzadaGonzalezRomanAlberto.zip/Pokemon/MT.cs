using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class MT:Item
    {
        Movements mt;
        IO io = new IO();
        public MT(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints, Movements mt)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

        }
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
            io.SlowWrite("¿Qué movimiento quieres olvidar?");
            for(int i = 0; i < pokemon.GetMovements().Length; ++i)
            {
                pokemon.GetMovements()[i].GetName();
            }
            int ppMovement = io.AskNumber();

            pokemon.GetMovements()[ppMovement - 1] = mt;

        }
        public override bool Buy()
        {
            return true;
        }

        public override bool Sell()
        {
            return true;
        }
        public MT AsignMTMegaPuño()
        {
            Movements megapuño = new Movements("Special", "Megapuño", 8, 20, 40, 100, 0);
            MT P1 = new MT("Megapuño", 100, 100, 100, 100, 100, 100,megapuño);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AsignMTVientoCortante()
        {
            Movements vientoCortante = new Movements("Special", "Megapuño", 8, 20, 40, 100, 0);
            MT P1 = new MT("Viento cortante", 100, 100, 100, 100, 100, 100, vientoCortante);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AsignMTDanzaEspada()
        {
            Movements danzaEspada = new Movements("Special", "Megapuño", 8, 20, 40, 100, 0);
            MT P1 = new MT("Danza espada", 100, 100, 100, 100, 100, 100,danzaEspada);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AsignMTRemolino()
        {
            Movements remolino = new Movements("Special", "Megapuño", 8, 20, 40, 100, 0);
            MT P1 = new MT("Remolino", 100, 100, 100, 100, 100, 100, remolino);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AsignMTGolpeCuerpo()
        {
            Movements golpeCuerpo = new Movements("Special", "Megapuño", 8, 20, 40, 100, 0);
            MT P1 = new MT("Golpe cuerpo", 100, 100, 100, 100, 100, 100,golpeCuerpo);
            P1.AddQuantity(1);
            return P1;
        }
    }
}
