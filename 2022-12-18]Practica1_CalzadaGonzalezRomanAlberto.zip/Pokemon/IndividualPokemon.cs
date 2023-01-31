using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Pokemon
{
    class IndividualPokemon
    {
        //Creación de la instancia SpeciesPokemon para poder utilizarla en esta clase y atributos como
        //velocidad actual, ataque, defensa, vida maxima, vida actual, genero, ratio de captura, vida actual, fecha de captura  nombre, mote , movimientos y eo(Entrenador Original).
        SpeciesPokemon species = new SpeciesPokemon();
        char gender;
        int hp;
        DateTime? captureDateTime;
        string nickName;
        Movements[] movements;
        string eo;
        string name;

        public IndividualPokemon(SpeciesPokemon species, Movements[] movements) //Constructor que recibe los atributos y adquiere con los valores de la clase SpeciesPokemon.
        {
            this.name = species.GetName();
            this.hp = species.GetHpMax();
            this.captureDateTime = GetCaptureDateTime();
            this.gender = species.Genderprobability();
            this.nickName=species.GetName();
            this.eo = " ";
            this.movements = Assign(movements);
        }
        //Métodos Getters y Setters de cada atributo.
        public string GetNickName()
        {
            return nickName;
        }
        public void SetNickName(string nickName)
        {
            this.nickName = nickName;
        }

        public int GetSpeed()
        {
            return species.GetSpeedBase();
        }

        public void SetSpeed(int speed)
        {
            species.SetSpeedBase(speed);
        }

        public string GetName()
        {
            return name;
        }

        public int GetCurrentHP()
        {
            return hp;
        }

        public void SetCurrentHP(int hp)
        {
            this.hp = hp;
        }

        public void AddCurrentHP(int hp)
        {
            this.hp = this.hp+hp;
        }

        public DateTime? GetCaptureDateTime()
        {
            return captureDateTime;
        }

        public void SetCaptureDateTime(DateTime? currentDate)
        {
            currentDate = DateTime.Now;
            captureDateTime = currentDate;
        }

        public int GetCaptureRatio()
        {
            return species.GetCaptureratio();
        }

        public int GetHpmax()
        {
            return species.GetHpMax();
        }

        public void SetHpmax(int hpMax)
        {
            species.SetHpMax(hpMax);
        }

        public char GetGender()
        {
            return gender;
        }

        public void SetGender(char gender)
        {
            this.gender = gender;
        }

        public int GetAttack()
        {
            return species.GetAttackBase();
        }

        public void SetAttack(int attack)
        {
            species.SetAttackBase(attack);
        }

        public int GetSpecialAttack()
        {
            return species.GetSpecialAttack();
        }

        public void SetSpecialAttack(int attack)
        {
            species.SetSpecialAttack(attack);
        }

        public int GetDefense()
        {
            return species.GetDefenseBase();
        }

        public void SetDefense(int defense)
        {
            species.SetDefenseBase(defense);
        }
        public int GetSpecialDefense()
        {
            return species.GetSpecialDefense();
        }

        public void SetSpecialDefense(int defense)
        {
            species.SetSpecialDefense(defense);
        }
        public string GetEo()
        {
            return eo;
        }
        public void SetEo(string eo)
        {
            this.eo = eo;
        }
        public Movements[] GetMovements()
        {
            return movements;
        }
        public void SetMovements(Movements[] value)
        {
            movements = value;
        }
        public  IndividualPokemon[] StartPokemon(Movements[] allMoves)   // Función que contiene un array de los 3 Pokémon iniciales
        {
            IndividualPokemon[] startpokemon = new IndividualPokemon[3];
            startpokemon[0] = new IndividualPokemon(new SpeciesPokemon("Bulbasaur"), allMoves);
            startpokemon[1] = new IndividualPokemon(new SpeciesPokemon("Charmander"), allMoves);
            startpokemon[2] = new IndividualPokemon(new SpeciesPokemon("Squirtle"), allMoves);
            return startpokemon;
        }


        public  IndividualPokemon[] RivalPokemon(Movements[] allMoves) // Función que contiene un array de los posibles rivales del jugador
        {
            IndividualPokemon[] rivalpokemon = new IndividualPokemon[6];
            rivalpokemon[0] = new IndividualPokemon(new SpeciesPokemon("Rattata"), allMoves);
            rivalpokemon[1] = new IndividualPokemon(new SpeciesPokemon("Spearow"), allMoves);
            rivalpokemon[2] = new IndividualPokemon(new SpeciesPokemon("Ekans"), allMoves);
            rivalpokemon[3] = new IndividualPokemon(new SpeciesPokemon("Vulpix"), allMoves);
            rivalpokemon[4] = new IndividualPokemon(new SpeciesPokemon("Paras"), allMoves);
            rivalpokemon[5] = new IndividualPokemon(new SpeciesPokemon("Diglett"), allMoves);
            return rivalpokemon;
        }

        public void Healpokemon(IndividualPokemon[] packpokemon) //Función para la opción del Centro Pokémon, para restablecer su vida actual a la vida máxima correspondiente.
        {
            // restaurar vida
            for (int i = 0; i < packpokemon.Length; ++i)
            {
                if (packpokemon[i] != null)
                {
                    packpokemon[i].SetCurrentHP(packpokemon[i].GetHpmax());
                }

            }
        }
        //public double DmgFight(IndividualPokemon mypokemon, IndividualPokemon rivalpokemon) //Función que devuelve el cálculo del daño del combate.
        //{
        //    double dmgnumerator = (mypokemon.GetAttack() / rivalpokemon.GetDefense());
        //    Random r = new Random();
        //    double random = r.Next(85, 101);
        //    double rand = random / 100;

        //    double dmg = (dmgnumerator * 2) + 2 * rand * CriticDmg();

        //    rivalpokemon.hp = (rivalpokemon.hp - (int)dmg); //Quitamos la vida al pokémon rival según el daño causado.
        //    return (int)dmg;
        //}
        //public double CriticDmg() //Función que nos devuelve si el ataque ha sido crítico o no.
        //{
        //    Random r = new Random();
        //    double crit = r.Next(1, 25);
        //    if (crit == 1)
        //    {
        //        return 1.5;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}
        //public int Escape(IndividualPokemon mypokemon, IndividualPokemon rivalpokemon) //Función para la opción escapar dentro del combate pokémon.
        //{
        //    if (mypokemon.GetSpeed() >= rivalpokemon.GetSpeed())
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        bool exit = false;
        //        int attempts = 1;
        //        Random r = new Random();
        //        int probabilityescape = r.Next(0, 256);
        //        while (exit == false)
        //        {
        //            double oddsescape = (((mypokemon.GetSpeed() * 128) / rivalpokemon.GetSpeed()) + 30 * attempts) % 256;
        //            ++attempts;
        //            if (probabilityescape < oddsescape)
        //            {
        //                exit = true;

        //            }
        //            else
        //            {
        //                mypokemon.DmgFight(rivalpokemon, mypokemon, rivalpokemon.GetMovements()[0]);
        //                return 0;
        //            }
        //        }
        //        return 1;
        //    }
        //}

        public Movements[] Assign(Movements[] allMoves) //Función para asegurarnos que los ataques son diferentes.
        {
            Movements[] randomMovements = new Movements[4];
            Random rnd = new Random();
            for (int i = 0; i < randomMovements.Length; ++i)
            {
               
                randomMovements[i] = allMoves[rnd.Next(0, allMoves.Length)];
                
            }
            return randomMovements;
        }
        //public double DmgFight(IndividualPokemon mypokemon, IndividualPokemon rivalpokemon, Movements movement) //Función que devuelve el cálculo del daño del combate.
        //{
        //    Random r = new Random();
        //    double random = r.Next(85, 101);
        //    double rand = random / 100;          
        //    if (movement.GetCategory() == "Physical")
        //    {
        //        double dmg = (2 * movement.GetPower() * (mypokemon.GetAttack() / rivalpokemon.GetDefense()) / 50 + 2) * rand * CriticDmg();
        //        rivalpokemon.hp = (rivalpokemon.hp - (int)dmg); //Quitamos la vida al pokémon rival según el daño causado.
        //        return (int)dmg;
        //    } else if (movement.GetCategory() == "Special")
        //    {
        //        double dmg = (2 * movement.GetPower() * (mypokemon.GetSpecialAttack() / rivalpokemon.GetSpecialDefense()) / 50 + 2) * rand * CriticDmg();
        //        rivalpokemon.hp = (rivalpokemon.hp - (int)dmg); //Quitamos la vida al pokémon rival según el daño causado.
        //        return (int)dmg;
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}

        //public bool checkSameMovements(Movements movement, Movements[] randomMovements)
        //{
        //    int counter = 0;
        //    for (int i = 0; i < randomMovements.Length; ++i)
        //    {
        //        if (randomMovements[i] == movement)
        //        {
        //            ++counter;
        //        }
        //    }

        //    if (counter == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
