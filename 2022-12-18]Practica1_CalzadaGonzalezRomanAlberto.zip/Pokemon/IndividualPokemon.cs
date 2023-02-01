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
        bool hasEscaped;

        public IndividualPokemon(SpeciesPokemon species, Movements[] movements) //Constructor que recibe los atributos y adquiere con los valores de la clase SpeciesPokemon.
        {
            this.name = species.GetName();
            this.hp = species.GetHpMax();
            this.captureDateTime = GetCaptureDateTime();
            this.gender = species.Genderprobability();
            this.nickName=species.GetName();
            this.eo = " ";
            this.movements = Assign(movements);    
            this.hasEscaped = false;
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
        public bool GetHasEscaped()
        {
            return hasEscaped;
        }

        public void SetHasEscaped(bool value)
        {
            this.hasEscaped = value;
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
            this.captureDateTime = currentDate;
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
                              
        public Movements[] Assign(Movements[] allMoves) //Función para asignar ataques.
        {
            Movements[] randomMovements = new Movements[4];
            Random rnd = new Random();
            for (int i = 0; i < randomMovements.Length; ++i)
            {
                int randIndex = rnd.Next(0, allMoves.Length);    //Si el ataque es el mismo le asignamos otro para no tener dos ataques iguales.
                randomMovements[i] = allMoves[randIndex];
                for (int j = 0; j < i; j++)
                {
                    if (randomMovements[j] == randomMovements[i])
                    {
                        i--;
                        break;
                    }
                }
            }
            return randomMovements;
        }


    }
}
