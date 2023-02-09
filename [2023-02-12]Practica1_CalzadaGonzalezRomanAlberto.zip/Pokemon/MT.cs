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
            this.mt = mt;
        }
        public MT() : base() { }
        public override bool UseItemOutCombat()
        {
            return true;
        }
        public override bool ThrowItem()
        {
            return false;
        }

        public override bool UseItemInCombat()
        {
            return false;
        }

        public override void Utility(IndividualPokemon pokemon)
        {
            io.SlowWrite("¿Qué movimiento quieres olvidar?");
            for(int i = 0; i < pokemon.GetMovements().Length; ++i)
            {
                io.SlowWrite(pokemon.GetMovements()[i].GetName());
            }
            int ppMovement = 0;
            ppMovement = io.OptionCorrect(1,4, ppMovement);

            pokemon.GetMovements()[ppMovement - 1] = mt;

        }
        public override bool Buy()
        {
            return false;
        }

        public override bool Sell()
        {
            return false;
        }
        public MT AssignMTMegaPuño()
        {
            Movements megapuño = new Movements("Special", "Megapuño", 8, 20, 40, 100, 0);
            MT P1 = new MT("Megapuño", 100, 100, 100, 100, 100, 100,megapuño);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AssignMTVientoCortante()
        {
            Movements vientoCortante = new Movements("Special", "Viento cortante", 8, 20, 40, 100, 0);
            MT P1 = new MT("Viento cortante", 100, 100, 100, 100, 100, 100, vientoCortante);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AssignMTDanzaEspada()
        {
            Movements danzaEspada = new Movements("Special", "Danza espada", 8, 20, 40, 100, 0);
            MT P1 = new MT("Danza espada", 100, 100, 100, 100, 100, 100,danzaEspada);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AssignMTRemolino()
        {
            Movements remolino = new Movements("Special", "Remolino", 8, 20, 40, 100, 0);
            MT P1 = new MT("Remolino", 100, 100, 100, 100, 100, 100, remolino);
            P1.AddQuantity(1);
            return P1;
        }
        public MT AssignMTGolpeCuerpo()
        {
            Movements golpeCuerpo = new Movements("Special", "Golpe cuerpo", 8, 20, 40, 100, 0);
            MT P1 = new MT("Golpe cuerpo", 100, 100, 100, 100, 100, 100,golpeCuerpo);
            P1.AddQuantity(1);
            return P1;
        }
    }
}
