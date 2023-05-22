using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Pokemon
{
    [Serializable]
    class PokeballItem: Item
    {
        double ratioCapture;
        public PokeballItem(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints,double ratioCapture)
             : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.ratioCapture = ratioCapture;
        }
        public PokeballItem() : base() { }

        public double GetRatioCapture()
        {
            return ratioCapture;
        }
        public override bool UseItemOutCombat()
        {
            return false;
        }
        public override bool ThrowItem()
        {
            return true;
        }

        public override bool UseItemInCombat()
        {
            return true;
        }

        public override void Utility(IndividualPokemon pokemon, IO io)
        {           
            double catchRateModified = ((3 * pokemon.GetHpmax() - 2 * pokemon.GetCurrentHP()) * pokemon.GetCaptureRatio() * ratioCapture) / (3 * pokemon.GetHpmax());
            double agitated = 65536 / Math.Pow((255 / catchRateModified), 0.1875);
            int randomNumber;
            Random rand= new Random();
            for (int i = 0; i < 4; i++)
            {
                randomNumber = rand.Next(0, 65535);
                if (randomNumber >= agitated)
                {
                    io.SlowWrite("Lanzando " + name + " sobre " + pokemon.GetNickName() + " . . .");
                    io.SlowWrite(pokemon.GetNickName()+" ha escapado.");
                    return;
                }
            }
            io.SlowWrite("Has capturado a " + pokemon.GetNickName() + " con éxito.");
            pokemon.SetIsCaptured(true);
            //Mandar a la funcion de capturado del game.
        }
        public override bool Buy()
        {
            return true;
        }

        public override bool Sell()
        {
            return true;
        }
     
        public PokeballItem AssignPokeball()
        {
            PokeballItem P1 = new PokeballItem("Pokeball", 100, 100, 100, 100, 100, 100,1);
            P1.AddQuantity(1);
            return P1;
        }
        public PokeballItem AssignSuperball()
        {
            PokeballItem P1 = new PokeballItem("Súperball", 100, 100, 100, 100, 100, 100,2.5);
            P1.AddQuantity(1);
            return P1;
        }
        public PokeballItem AssignUltraball()
        {
            PokeballItem P1 = new PokeballItem("Ultraball", 100, 100, 100, 100, 100, 100, 3);
            P1.AddQuantity(1);
            return P1;
        }
        public PokeballItem AssignMasterball()
        {
            PokeballItem P1 = new PokeballItem("Másterball", 100, 100, 100, 100, 100, 100, 255);
            P1.AddQuantity(1);
            return P1;
        }
    }
}
