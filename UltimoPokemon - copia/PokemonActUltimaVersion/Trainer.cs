using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    [Serializable]
    class Trainer
    {
        IO io;
        //Atributos del jugador, el nombre, género, número de ID, número secreto, dinero(pokedólares, puntos de batalla y pokemillas),fecha de creación del jugador, equipo Pokémon y cajas Pokémon.
        string name;
        string gender;
        string id;
        int secretNumber;
        int pokeDollars;
        int battlePoints;
        int pokeMiles;
        DateTime startDate;
        IndividualPokemon[] myteam;
        IndividualPokemon[] pokemonBox;
        Bag bag;
        


        public Trainer(string name, string gender, Bag bag, IO io, Random r) //Constructor para el inicio del juego, dónde elegiremos el nombre y el género de nuestro jugador.
        {
            this.name = name;
            this.gender = "Chico";
            this.id = GenerateID(r);
            this.secretNumber = GenerateSecretNumber(r);
            this.pokeDollars = 5000;
            this.battlePoints = 0;
            this.pokeMiles = 0;
            startDate = DateTime.Now;
            this.bag = bag;
            this.io = io;
            myteam = new IndividualPokemon[6];
        }
        public Trainer(Bag bag, IO io, Random r) //Constructor para el inicio del juego, dónde elegiremos el nombre y el género de nuestro jugador.
        {
            this.name = "Alberto";
            this.gender = "Chico";
            this.id = GenerateID(r);
            this.secretNumber = GenerateSecretNumber(r);
            this.pokeDollars = 5000;
            this.battlePoints = 0;
            this.pokeMiles = 0;
            startDate = DateTime.Now;
            this.bag = bag;
            this.io = io;
            myteam = new IndividualPokemon[6];

        }
        //Getters y Setters de los atributos correspondientes:
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetGender()
        {
            return gender;
        }
        public void SetGender(string gender)
        {
            this.gender = gender;
        }
        public string GenerateGender(int num) //Asociar el número que elige el jugador a un Género en concreto.
        {
            if (num == 1)
            {
                return "Chico";
            }
            if (num == 2)
            {
                return "Chica";
            }
            else
            {
                return "Chique";
            }
        }
        public string GenerateID(Random random) //Función para generar el ID del jugador.
        {
            int region = random.Next(0, 5); //Le asignamos un número de región al jugador de forma aleatoria. Europa (0), Norte América (1), Asia-Australia (2), África (3), Sur América (4).
            int randomNumber = 0;
            for (int i = 0; i < 9; ++i) //Para generar los 9 números siguientes de la cifra de la región correspondiente.
            {
                randomNumber = randomNumber * 10 + random.Next(0, 10);
            }

            return region + randomNumber.ToString();
        }
        public string GetID()
        {
            return id;
        }
        public int GenerateSecretNumber(Random random)  //Función para generar el número secreto del jugador.
        {
            int randomNumber = 0;
            for (int i = 0; i < 9; ++i) //Para generar los 9 números 
            {
                randomNumber = randomNumber * 10 + random.Next(0, 10);
            }
            return randomNumber;
        }

        public int GetSecretNumber()
        {
            return secretNumber;
        }

        public Bag GetBag()
        {
            return bag;
        }

        public int GetPokeDollars()
        {
            return pokeDollars;
        }
        public int GetBattlePoints()
        {
            return battlePoints;
        }
        public int GetPokeMiles()
        {
            return pokeMiles;
        }
        public void SetPokeDollars(int pokeDollars)
        {
            this.pokeDollars = pokeDollars;
        }
        public void SetBattlePoints(int battlePoints)
        {
            this.battlePoints = battlePoints;
        }
        public void SetPokeMiles(int pokeMiles)
        {
            this.pokeMiles = pokeMiles;
        }
        public DateTime GetStartDate()
        {
            return startDate;
        }

        public IndividualPokemon[] GetMyTeam()
        {
            return myteam;
        }

        

        public string GenerateTimePlayed() //Función para calcular el tiempo jugado por el jugador.
        {
            DateTime dateActual = DateTime.Now;
            TimeSpan timePlayed = dateActual - startDate;
            int hours = timePlayed.Hours;
            int minutes = timePlayed.Minutes;
            int seconds = timePlayed.Seconds;
            if (hours == 0)
            {
                return minutes + " minutos y " + seconds + " segundos";
            }
            else
            {
                return hours + " horas, " + minutes + " minutos y " + seconds + " segundos";
            }

        }
        public IndividualPokemon[] PackPokemon() // Función que contiene un array del equipo Pokémon del jugador
        {
            IndividualPokemon[] packpokemon = new IndividualPokemon[6];
            return packpokemon;
        }

        public IndividualPokemon[] BoxPokemon() //Función para almacenar los Pokémon que capturamos  y no vamos a llevar encima.
        {
            IndividualPokemon[] boxPokemon = new IndividualPokemon[32];
            //for(int i = 0; i < boxPokemon.Length; ++i)
            //{
            //    boxPokemon[i] = new IndividualPokemon[30];
            //}
            return boxPokemon;
        }
    }
}
