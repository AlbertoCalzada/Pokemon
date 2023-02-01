using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class PokeballItem: Item
    {
        double ratioCapture;
        public PokeballItem(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints,double ratioCapture)
             : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {
            this.ratioCapture = ratioCapture;
        }

        public double GetRatioCapture()
        {
            return ratioCapture;
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
            
        }
        public override bool Buy()
        {
            return true;
        }

        public override bool Sell()
        {
            return true;
        }
     
        public PokeballItem AsignPokeball()
        {
            PokeballItem P1 = new PokeballItem("Pokeball", 100, 100, 100, 100, 100, 100,1);
            P1.AddQuantity(1);
            return P1;
        }
        public PokeballItem AsignSuperball()
        {
            PokeballItem P1 = new PokeballItem("Súperball", 100, 100, 100, 100, 100, 100,2.5);
            P1.AddQuantity(1);
            return P1;
        }
        public PokeballItem AsignUltraball()
        {
            PokeballItem P1 = new PokeballItem("Ultraball", 100, 100, 100, 100, 100, 100,3);
            P1.AddQuantity(1);
            return P1;
        }
        public PokeballItem AsignMasterball()
        {
            PokeballItem P1 = new PokeballItem("Másterball", 100, 100, 100, 100, 100, 100, 255);
            P1.AddQuantity(1);
            return P1;
        }
    }
}
