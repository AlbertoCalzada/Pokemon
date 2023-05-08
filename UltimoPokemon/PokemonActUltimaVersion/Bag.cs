using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Bag  //Creamos un conjunto de bolsillos donde cada uno almacenará un tipo de item diferente
    {
        Item[][] item;
        IO io;
        public Bag()
        {
            item = GiveDefaultItems();
        }
        public Bag(Item items)
        {
            item = GiveDefaultItems();
        }
        public Item[][] GiveDefaultItems() //Método para asignar por defecto algunos items a la mochila del entrenador.
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
            Potion potion = new Potion();
            item[0][0] = potion.AssignHyperPotion();
            Elixirs elixir = new Elixirs();
            item[0][1] = elixir.AssignEther();
            PokeballItem pokeball = new PokeballItem();
            item[1][0] = pokeball.AssignPokeball();
            item[1][1]=pokeball.AssignSuperball();
            Pokedoll pokedoll = new Pokedoll();
            item[2][0] = pokedoll.AssignPokedoll();
            MT mt= new MT();
            item[3][0] = mt.AssignMTMegaPuño();
            item[3][1] = mt.AssignMTGolpeCuerpo();
            Treasures treasures = new Treasures();
            item[4][0] = treasures.AssignBigMushroom();
            item[4][1] = treasures.AssignPerl();
            EvolutionStone evolutionStone = new EvolutionStone();
            item[5][0] = evolutionStone.AssignFireStone();
            return item;
        }
        public void AddItem(Item item, int add) //Función para añadir una cantidad determinada de un objeto.
        {
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
