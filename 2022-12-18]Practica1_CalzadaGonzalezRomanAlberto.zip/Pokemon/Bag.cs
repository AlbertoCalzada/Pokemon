using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Bag
    {
        Potion potion = new Potion();
        Elixirs elixir = new Elixirs();
        Item[][] item;
        IO io = new IO();
        public Bag()
        {
            item= new Item[20][];
            item[0] = new Medicine[999];
            item[1] = new PokeballItem[999];
            item[2] = new BattleItem[999];
            item[3] = new MT[999];
            item[4] = new Treasures[999];
            item[5] = new EvolutionStone[999];
            item[6] = new Item[999];
            for (int i = 0; i < item.Length; ++i)
            {
                item[i] = new Item[999];
            }                             
        }
        public Bag(Item items)
        {
            item = new Item[20][];
            item[0] = new Medicine[999];
            item[1] = new PokeballItem[999];
            item[2] = new BattleItem[999];
            item[3] = new MT[999];
            item[4] = new Treasures[999];
            item[5] = new EvolutionStone[999];
            item[6] = new Item[999];
            for (int i = 0; i < item.Length; ++i)
            {
                item[i] = new Item[999];
            }
        }
        //public Item AddItem(Item item,int add) //Función para añadir una cantidad determinada de un objeto.
        //{          
        //    add = io.AskNumber();
        //    item.AddQuantity(add);
        //    return item;
        //}
        public void AddItem(Item item, int add) //Función para añadir una cantidad determinada de un objeto.
        {
            add = io.AskNumber();
            item.AddQuantity(add);

        }
        public void RemoveItem(Item item, int add) //Función para eliminar una cantidad determinada de un objeto.
        {
            add = io.AskNumber();
            item.RemoveQuantity(add);
        }

        public bool CheckItem(Item itemX) //Función para comprobar si tenemos un Item determinado en nuestra bolsa.
        {
            for(int i = 0; i < item.Length; ++i)
            {              
                for(int j=0; j < item.Length; ++j)
                {
                    if (item[i][j] == itemX)
                    {
                        return true;
                    }                   
                }            
            }
            return false;
        }
        public Item[][] GetItems()
        {
            return item;
        }

    }
}
