using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Treasures : Item
    {
        public Treasures(string name, int buyPricePokedollars, int buyPricePokemillas, int buyPriceBattlePoints, int sellPricePokedollars, int sellPricePokemillas, int sellPriceBattlePoints)
        : base(name, buyPricePokedollars, buyPricePokemillas, buyPriceBattlePoints, sellPricePokedollars, sellPricePokemillas, sellPriceBattlePoints)
        {

        }
        public Treasures() : base() { }
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
            return false;
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
        public Treasures AssignPerl()
        {
            Treasures Perl = new Treasures("Perl", 1000, 0, 0, 0, 0, 0);
            Perl.AddQuantity(1);
            return Perl;
        }
        public Treasures AssignStardust()
        {
            Treasures Stardust = new Treasures("Stardust", 1500, 0, 0, 0, 0, 0);
            Stardust.AddQuantity(1);
            return Stardust;
        }
        public Treasures AssignBigMushroom()
        {
            Treasures BigMushroom = new Treasures("Big Mushroom", 2500, 0, 0, 0, 0, 0);
            BigMushroom.AddQuantity(1);
            return BigMushroom;
        }
        public Treasures AssignBigPearl()
        {
            Treasures BigPearl = new Treasures("Big Pearl", 4000, 0, 0, 0, 0, 0);
            BigPearl.AddQuantity(1);
            return BigPearl;
        }
        public Treasures AssignNugget()
        {
            Treasures Nugget = new Treasures("Nugget", 5000, 0, 0, 0, 0, 0);
            Nugget.AddQuantity(1);
            return Nugget;
        }
        public Treasures AssignStarPiece()
        {
            Treasures StarPiece = new Treasures("Star Piece", 6000, 0, 0, 0, 0, 0);
            StarPiece.AddQuantity(1);
            return StarPiece;
        }
        public Treasures AssignCometShard()
        {
            Treasures CometShard = new Treasures("Comet Shard", 12500, 0, 0, 0, 0, 0);
            CometShard.AddQuantity(1);
            return CometShard;
        }
        public Treasures AssignBigNugget()
        {
            Treasures BigNugget = new Treasures("Big Nugget", 20000, 0, 0, 0, 0, 0);
            BigNugget.AddQuantity(1);
            return BigNugget;



        }
    }
}
