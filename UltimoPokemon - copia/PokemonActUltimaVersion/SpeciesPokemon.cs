using System;

namespace Pokemon
{
    [Serializable]
    class SpeciesPokemon
    {
        /*atributos de la Especie Pokémon como número de especie, nombre, género, vida máxima, velocidad base, ataque, defensa, ratio de captura,  */

        int numSpecie;
        string name;
        char gender;
        int hpMax;
        int speedBase;
        int attackBase;
        int defenseBase;
        int captureRatio;
        int specialAttack;
        int specialDefense;
     
   
        public SpeciesPokemon(string name,Random r) //Constructor el cual recibe el nombre del Pokémon.
        {
            
            Generatenumspecie(r);
            this.name = name;
            gender = Genderprobability(r);
            hpMax = r.Next(40, 51);
            speedBase = r.Next(40, 90);
            attackBase = r.Next(26, 48);
            defenseBase = r.Next(26, 48);
            captureRatio = Generatecaptureratio(r);
            specialAttack = r.Next(26, 50);
            specialDefense=r.Next(26, 50);
        }
        public SpeciesPokemon(Random r) //Constructor vacío con los valores aleatorios por defecto y/o nulos que más tarde se rellenaran.
        {
            
            Generatenumspecie(r);
            name = " ";
            gender = Genderprobability(r);
            hpMax = r.Next(40, 51);
            speedBase = r.Next(40, 90);
            attackBase = r.Next(26, 48);
            defenseBase = r.Next(26, 48);
            captureRatio = Generatecaptureratio(r);
            specialAttack = r.Next(26, 50);
            specialDefense = r.Next(26, 50);
        }

        public void Generatenumspecie(Random r) //Función para generar el número aleatorio de especie Pokémon.
        {
            
            numSpecie = r.Next(0, 900);
        }

        public char Genderprobability(Random r) //Función para generar el género aleatorio del Pokémon.
        {
            int genderprobability = r.Next(0, 2);
            if (genderprobability == 1)
            {
                this.gender = 'M';
                return gender;
            }
            else
            {
                this.gender = 'F';
                return gender;
            }

        }

        //Getters y Setters de los atributos nombrados anteriormente.


        public int GetNumspecie()
        {
            return numSpecie;
        }

        public void SetNumspecie(int numspecie)
        {
            this.numSpecie = numspecie;
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public int Generatecaptureratio(Random r) //Función para generar el ratio aleatorio de captura de la especie Pokémon.
        {
            
            captureRatio = r.Next(0, 256);
            return captureRatio;
        }
        public int GetCaptureratio()
        {
            return captureRatio;
        }
        public int GetAttackBase()
        {
            return attackBase;
        }

        public void SetAttackBase(int attack)
        {
            attackBase = attack;
        }

        public int GetDefenseBase()
        {
            return defenseBase;
        }

        public void SetDefenseBase(int defense)
        {
            defenseBase = defense;
        }

        public char GetGender()
        {
            return gender;
        }

        public void SetGender(char gender)
        {
            this.gender = gender;
        }

        public int GetHpMax()
        {
            return hpMax;
        }

        public void SetHpMax(int hpmax)
        {
            this.hpMax = hpmax;
        }

        public int GetSpeedBase()
        {
            return speedBase;
        }

        public void SetSpeedBase(int speed)
        {
            this.speedBase = speed;
        }
        public int GetSpecialAttack()
        {
            return specialAttack;
        }

        public void SetSpecialAttack(int value)
        {
            specialAttack = value;
        }

        public int GetSpecialDefense()
        {
            return specialDefense;
        }

        public void SetSpecialDefense(int value)
        {
            specialDefense = value;
        }

    }
}
