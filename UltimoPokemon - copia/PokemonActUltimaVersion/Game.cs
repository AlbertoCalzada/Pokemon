using MySqlConnector;
using PokemonAct;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Linq;
using WpfApp2;

namespace Pokemon
{
    class Game
    {
        //Creación de instancias de la clase Io, Random  SpeciesPokemon  IndividialPokemon , Trainer, movimientos, mochila y item. para poder utilizar funciones de clases anteriores.
        IO io;
        Random r;
        SpeciesPokemon pokemon;
        Trainer trainer;
        IndividualPokemon[] startPokemon; 
        IndividualPokemon[] rivalPokemon;
        IndividualPokemon[] boxPokemon;
        Movements[] movements;
        Bag bag; 
        Item[] listItem;

        public Game(IO io) //Constructor que inicia el juego de forma lenta.
        {
            r = new Random();
            this.io = io;
            bag = new Bag();
            trainer = new Trainer(bag, io, r);
            pokemon = new SpeciesPokemon(r);
            movements = LoadMovementsList();
            startPokemon = StartPokemon(movements);
            rivalPokemon = RivalPokemon(movements);
            boxPokemon = trainer.BoxPokemon();
            listItem= GiveItemShop();
            /*SlowStart();*/
        }
        /*public Game() //Constructor que inicia el juego de forma rápida.
        {
            io = new CLI();
            pokemon = new SpeciesPokemon();
            movements = LoadMovementsList();
            myPokemon = new IndividualPokemon(pokemon, movements);
            bag = new Bag();
            trainer = new Trainer(bag,io);
            startPokemon = StartPokemon(movements);
            packPokemon = trainer.PackPokemon();
            rivalPokemon = RivalPokemon(movements);
            boxPokemon = trainer.BoxPokemon();
            listItem = GiveItemShop();
            FastStart();
        }*/
        
        public void Run() //Función con el Menú principal del juego.
        {
            io.SlowWrite("Elige la opción correspondiente:");
            io.SlowWrite("\t 1. Cargar partida.");
            io.SlowWrite("\t 2. Empezar una nueva.");
            int option = 0;
            option = io.OptionCorrect(1, 2, option);
            if (option == 1)
            {
                FastStart();
            }
            else
            {
            
                SlowStart();
            }
            Menu();
        }

       
       
        public void SlowStart() //Función para el inicio lento, para elegir el Pokémon inicial.
        {
            io.SlowWrite("Profesor OAK: Hola a todos! ¡Bienvenidos al mundo de POKÉMON! ¡Me llamo OAK! ¡Pero la gente me llama el PROFESOR POKÉMON! ¡Este mundo está habitado por unas criaturas llamadas POKÉMON! Para algunos, los POKÉMON son mascotas. " +
                "Pero otros los usan para pelear. En cuanto a mí... Estudio a los POKÉMON como profesión. Pero primero, dime ¿como te llamas? ");
            io.Space();
            string user = io.ReadLine();
            trainer.SetName(user);
            io.Space();
            io.SlowWrite("Profesor OAK: ¡Bien!, encantado " + user + " !!, aunque aún no me has dicho que género eres: ");
            io.ColorGreen("\t 1. Chico.");
            io.ColorRed("\t 2. Chica.");
            io.ColorBlue("\t 3. Chique.");
            int chooseGender=0;
            chooseGender = io.OptionCorrect(1, 3, chooseGender);
            trainer.SetGender(trainer.GenerateGender(chooseGender));
            io.SlowWrite("Profesor OAK: ¡Perfecto " + user + " !! ¡Aquí hay 3 POKÉMON! ¡Están dentro de las POKÉ BALL! ¡Cuando yo era joven, era un buen entrenador de POKÉMON! " +
                "Pero ahora sólo me quedan 3... Te daré uno. ¿Cuál quieres?");
            io.ColorGreen("\t 1. Bulbasaur.");
            io.ColorRed("\t 2. Charmander.");
            io.ColorBlue("\t 3. Squirtle.");
            int chosenPokemon = 0;
            chosenPokemon = io.OptionCorrect(1, 3, chosenPokemon); //modificar
            bool exit = false;
            while (exit == false)
            {
                switch (chosenPokemon)
                {
                    case 1:
                        io.SlowWrite("Así que Bulbasaur! Resulta muy fácil criarlo.");
                        trainer.GetMyTeam()[0] = startPokemon[0];            //revisar      
                        trainer.GetMyTeam()[0].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber()); //llevar a trainer para usarlo, no en game.
                        exit = true;
                        break;
                    case 2:
                        io.SlowWrite("Así que Charmander! Pues ten paciencia con él.");
                        trainer.GetMyTeam()[0] = startPokemon[1];                   
                        trainer.GetMyTeam()[0].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber());
                        exit = true;
                        break;
                    case 3:
                        io.SlowWrite("¡Así que Squirtle! Merece la pena, sí, sí. ");
                        trainer.GetMyTeam()[0] = startPokemon[2];
                        trainer.GetMyTeam()[0].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber());
                        exit = true;
                        break;
                }
            }
            PutNickName(0); 
            io.SlowWrite("Enhorabuena, este será el Pokémon que te acompañe a partir de ahora, no dudes en cuidarlo y visitarme de vez en cuando.");
            io.Space();
        }

        public void FastStart() //Función para el inicio rápido, nos da un Pokémon sin elegirlo nosotros.
        {
            LoadGame(); 
        }
       
        public void Menu() //Función para el menú principal del juego con sus opciones.
        {          
            int menuoption = 0;
            bool exit = false;
            while (exit == false)
            {              
                io.SlowWrite("¿Qué deseas hacer?");
                io.ColorYellow("\t 1. Mis Pokémon.");
                io.ColorRed("\t 2. Combatir.");
                io.ColorGreen("\t 3. Centro Pokémon.");
                io.ColorCyan("\t 4. Datos del jugador.");
                io.ColorMagenta("\t 5. Cajas Pokémon.");
                io.ColorYellow("\t 6. Mochila.");
                io.ColorRed("\t 7. Tienda.");
                io.ColorBlue("\t 8. Salir.");
                io.ColorCyan("\t 9. Guardar partida.");
                menuoption = io.OptionCorrect(1, 9, menuoption);
                switch (menuoption)
                {
                    case 1:
                        io.SlowWrite("Estos son tus Pokémon: ");
                        ShowPokemonInfo();
                        io.ColorYellow("\t 1. Ver más información acerca de tus Pokémon.");
                        io.ColorRed("\t 2. Cambiar de posición alguno de tus Pokémon.");
                        io.ColorBlue("\t 3. Salir del menú.");
                        int option = 0;
                        option = io.OptionCorrect(1, 3, option);
                        io.Space();
                        if (option == 1)
                        {
                            ShowMorePokemonInfo();
                        }
                        else if (option == 2)
                        {
                            ChangePositionMenu();
                        }
                        break;
                    case 2:
                        io.SlowWrite("¡Un Pokemón salvaje apareció!");
                        Fight();
                        io.Space();
                        break;
                    case 3:
                        io.SlowWrite("Bienvenido al Centro Pokémon.");
                        io.SlowWrite("¿Quieres curar a tus Pokémon?");
                        io.ColorGreen(" 1. Si.");
                        io.ColorRed(" 2. No.");
                        int answer = 0;
                        answer = io.OptionCorrect(1, 2, answer);
                        if (answer == 1)
                        {
                             Healpokemon(trainer.GetMyTeam());
                            io.SlowWrite("Esta bien, espera un momento..");
                            io.SlowWrite("...... .... .... ..... ........ ...");
                            io.SlowWrite("Tus Pokémon han sido curados, esperamos volver a verte pronto.");
                        }
                        else
                        {
                            io.SlowWrite("Esta bien, vuelve cuando quieras curarles, hasta pronto.");
                        }
                        break;
                    case 4:
                        ShowTrainerInfo();
                        break;
                    case 5:
                        ShowBoxPokemon();
                        break;
                    case 6:
                        ShowBagInfo();
                        break;
                    case 7:
                        io.SlowWrite("¿Qué quieres hacer?");
                        io.ColorGreen("\t 1. Comprar.");
                        io.ColorRed("\t 2. Vender.");
                        io.ColorBlue("\t 3. Salir.");
                        int answerShop = 0;
                        answerShop = io.OptionCorrect(1, 3, answerShop);
                        if(answerShop == 1)
                        {
                            io.SlowWrite("Estos son los objetos que puedes comprar: ");
                            ShowShopItem();
                            io.SlowWrite("¿Qué objeto quieres comprar?");
                            int itemOption = 0;
                            itemOption = io.OptionCorrect(1, listItem.Length, itemOption); //cambiar esto
                            io.SlowWrite("¿Cuantas unidades quieres comprar?");
                            int numberOption = 0;
                            numberOption = io.OptionCorrect(1, 10, numberOption);
                            BuyItem(itemOption, numberOption);
                            break;
                        }
                        else if(answerShop==2)
                        {
                            io.SlowWrite("Estos son los objetos que puedes vender: ");
                            SellItem();
                            break;
                        }
                        else
                        {
                            io.SlowWrite("Has salido de la tienda");
                            break;
                        }                     
                    case 8:
                        io.SlowWrite("¿Estás seguro de que quieres salir del juego? Se perderán todos los datos hasta ahora. ");
                        io.ColorGreen(" 1. Si.");
                        io.ColorRed(" 2. No.");
                        int optionCorrect = 0;
                        optionCorrect = io.OptionCorrect(1, 2, optionCorrect);
                        if (optionCorrect == 1)
                        {
                            io.SlowWrite("Has salido del juego, hasta pronto.");
                            exit = true;
                        }
                        else
                        {
                            io.SlowWrite("Perfecto, ya decía yo...");
                        }
                        break;
                       case 9:
                        io.SlowWrite("¿Deseas guardar la partida?");
                        io.ColorGreen(" 1. Si.");
                        io.ColorRed(" 2. No.");
                        int optionCorrectt = 0;
                        optionCorrectt = io.OptionCorrect(1, 2, optionCorrectt);
                        if (optionCorrectt == 1)
                        {
                            SaveGame();
                            exit = true;
                        }
                        else
                        {
                            io.SlowWrite("Has vuelto al menu principal.");
                        }
                        break;
                    default:
                        io.SlowWrite("Elige una opción correcta.");
                        break;
                }
            }
        }
      

        public void LoadGame()
        {
            string rutaPartidas = Path.Combine("PartidasGuardadas");
            string[] archivos = Directory.GetFiles(rutaPartidas, "*.bin");

            if (archivos.Length == 0)
            {
                io.SlowWrite("No hay partidas guardadas disponibles.");
                return;
            }

            io.SlowWrite("Partidas guardadas disponibles:");
            for (int i = 0; i < archivos.Length; i++)
            {
                string nombrePartida = Path.GetFileNameWithoutExtension(archivos[i]);
                io.SlowWrite((i + 1) + ". " + nombrePartida + "\n");
            }

            io.SlowWrite("Ingresa el número de la partida que quieres cargar:");
            int opcion = 0;
            bool opcionValida = false;

            while (!opcionValida)
            {
                if (!int.TryParse(io.ReadLine(), out opcion) || opcion < 1 || opcion > archivos.Length)
                {
                    io.SlowWrite("Opción inválida. Por favor, introduce un número válido: ");
                }
                else
                {
                    io.SlowWrite("Has iniciado la partida guardada.\n");
                    opcionValida = true;
                }
            }

            string rutaPartidaSeleccionada = archivos[opcion - 1];
            FileStream file = File.OpenRead(rutaPartidaSeleccionada);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object tr = binaryFormatter.Deserialize(file);
            trainer = (Trainer)tr;
            file.Close();
        }

        public void SaveGame()
        {
            io.SlowWrite("¿Cómo quieres llamar a tu partida?");
            string nombrePartida = io.ReadLine();
            string rutaPartidaBinaria = Path.Combine("PartidasGuardadas", nombrePartida + ".bin");
            string rutaPartidaTexto = Path.Combine("PartidasGuardadas", nombrePartida + ".txt");

            string directorioActual = Directory.GetCurrentDirectory();
            string rutaCompletaBinaria = Path.Combine(directorioActual, rutaPartidaBinaria);
            string rutaCompletaTexto = Path.Combine(directorioActual, rutaPartidaTexto);

            
            FileStream fileBinario = File.OpenWrite(rutaCompletaBinaria);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileBinario, trainer);
            fileBinario.Close();

            
            StreamWriter writer = new StreamWriter(rutaCompletaTexto);
            writer.WriteLine("Información de la partida:");
            writer.WriteLine("Nombre:" + nombrePartida);
            writer.WriteLine("Entrenador: " + trainer.GetName());
            writer.WriteLine("Género: " + trainer.GetGender());
            writer.WriteLine("ID: " + trainer.GetID());
            writer.WriteLine("Número secreto: " + trainer.GetSecretNumber());
            writer.WriteLine("PokeDólares: " + trainer.GetPokeDollars());
            writer.WriteLine("Puntos de batalla: " + trainer.GetBattlePoints());
            writer.WriteLine("PokeMillas: " + trainer.GetPokeMiles());
            writer.WriteLine("Fecha de inicio: " + trainer.GetStartDate());
            writer.WriteLine("Equipo Pokémon:");


            writer.Close();

            io.SlowWrite("Partida guardada correctamente.\n");
        }


        /*public void SaveGame()
        {
            io.SlowWrite("¿Cómo quieres llamar a tu partida?");
            string nombrePartida = io.ReadLine();
            string rutaPartida = Path.Combine("PartidasGuardadas", nombrePartida + ".bin");

            string directorioActual = Directory.GetCurrentDirectory();
            string rutaCompleta = Path.Combine(directorioActual, rutaPartida);

            FileStream file = File.OpenWrite(rutaCompleta);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(file, trainer);
            file.Close();
        }*/
        public void Fight() //Función para el combate Pokémon.
        {
            
            int randomenemy = RandomEnemy(0,5); //Generamos un enemigo aleatorio dentro de lista de array enemigos.
            bool exit = false;
            while (exit == false)
            {
                io.SlowWrite("¿Qué deseas hacer?");
                io.Space();
                if (trainer.GetMyTeam()[0].GetCurrentHP()>0 && rivalPokemon[randomenemy].GetCurrentHP() > 0)
                {
                    io.SlowWrite("Datos: " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida de mi Pokémon " + trainer.GetMyTeam()[0].GetName() + ",  " + rivalPokemon[randomenemy].GetCurrentHP() +
                    " puntos de vida de mi adversario " + rivalPokemon[randomenemy].GetName() + ". ");
                }              
                io.Space();
                io.ColorRed("\t 1.Atacar.");
                io.ColorCyan("\t 2.Cambiar de Pokémon.");
                io.ColorYellow("\t 3.Mochila.");
                io.ColorGreen("\t 4.Escapar.");
                io.Space();
                int combatOption = 0;
                combatOption = io.OptionCorrect(1, 4, combatOption);
                switch (combatOption)
                {
                    case 1:
                        /*io.SlowWrite("¿Qué ataque deseas realizar?");
                        ShowMovements();
                        int movementOption = 0;
                        movementOption = io.OptionCorrect(1, 4, movementOption);
                        int enemymovementOption = RandomEnemy(0, 3);
                        io.Space();
                        if (trainer.GetMyTeam()[0].GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Tu Pokémon no puede luchar porque esta debilitado. ");
                            int change2 = io.AskNumber();
                            ChangePosition(change2, randomenemy);
                        }

                        if (trainer.GetMyTeam()[0].GetMovements()[movementOption-1].GetPriority() > rivalPokemon[randomenemy].GetMovements()[enemymovementOption].GetPriority())
                        {
                            if (trainer.GetMyTeam()[0].GetSpeed() > rivalPokemon[randomenemy].GetSpeed())
                            {
                                while(CheckUseMovement(trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(trainer.GetMyTeam()[0], rivalPokemon[randomenemy], trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]);
                                CheckLife(rivalPokemon[randomenemy]);
                                io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() +" usando "+ trainer.GetMyTeam()[0].GetMovements()[movementOption-1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                if (rivalPokemon[randomenemy].GetCurrentHP() > 0)
                                {
                                    DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                    CheckLife(trainer.GetMyTeam()[0]);
                                    io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " usando " + rivalPokemon[enemymovementOption].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                            else
                            {
                                while (CheckUseMovement(trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                CheckLife(trainer.GetMyTeam()[0]);
                                io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " usando " + rivalPokemon[enemymovementOption].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
                                if (trainer.GetMyTeam()[0].GetCurrentHP() > 0)
                                {
                                    DmgFight(trainer.GetMyTeam()[0], rivalPokemon[randomenemy], trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]);
                                    CheckLife(rivalPokemon[randomenemy]);
                                    io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() + " usando " + trainer.GetMyTeam()[0].GetMovements()[movementOption-1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                        }

                        if (trainer.GetMyTeam()[0].GetMovements()[movementOption-1].GetPriority() == rivalPokemon[randomenemy].GetMovements()[enemymovementOption].GetPriority())
                        {
                            if (trainer.GetMyTeam()[0].GetSpeed() > rivalPokemon[randomenemy].GetSpeed())
                            {
                                while (CheckUseMovement(trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(trainer.GetMyTeam()[0], rivalPokemon[randomenemy], trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]);
                                CheckLife(rivalPokemon[randomenemy]);
                                io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() + " usando " + trainer.GetMyTeam()[0].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                if (rivalPokemon[randomenemy].GetCurrentHP() > 0)
                                {
                                    DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                    CheckLife(trainer.GetMyTeam()[0]);
                                    io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " usando " + rivalPokemon[randomenemy ].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                            else
                            {
                                while (CheckUseMovement(trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                CheckLife(trainer.GetMyTeam()[0]);
                                io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " usando " + rivalPokemon[randomenemy].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
                                if (trainer.GetMyTeam()[0].GetCurrentHP() > 0)
                                {
                                    DmgFight(trainer.GetMyTeam()[0], rivalPokemon[randomenemy], trainer.GetMyTeam()[0].GetMovements()[movementOption - 1]);
                                    CheckLife(rivalPokemon[randomenemy]);
                                    io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() + " usando " + trainer.GetMyTeam()[0].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                        }
                        trainer.GetMyTeam()[0].GetMovements()[movementOption - 1].PpRemoveAttack(1); //Le quitamos un pp al ataque usado.
                        if (trainer.GetMyTeam()[0].GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Oh.... Tu Pokémon ha sido debilitado... Has perdido el combate.");
                            exit = true;
                        }
                        else if (rivalPokemon[randomenemy].GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Enhorabuena, ¡has ganado el combate!");
                            exit = true;
                        }*/
                        io.SlowWrite("¿Qué ataque deseas realizar?");
                        ShowMovements();
                        int movementOption = io.OptionCorrect(1, 4, 0);
                        int enemymovementOption = RandomEnemy(0, 3);
                        io.Space();

                        IndividualPokemon myPokemon = trainer.GetMyTeam()[0];
                        IndividualPokemon enemyPokemon = rivalPokemon[randomenemy];

                        bool myPokemonFirst = myPokemon.GetMovements()[movementOption - 1].GetPriority() > enemyPokemon.GetMovements()[enemymovementOption].GetPriority();
                        bool samePriority = myPokemon.GetMovements()[movementOption - 1].GetPriority() == enemyPokemon.GetMovements()[enemymovementOption].GetPriority();
                        bool myPokemonFaster = myPokemon.GetSpeed() > enemyPokemon.GetSpeed();

                        while (CheckUseMovement(myPokemon.GetMovements()[movementOption - 1]))
                        {
                            ShowMovements();
                            movementOption = io.OptionCorrect(1, 4, 0);
                        }

                        if (myPokemonFirst || (samePriority && myPokemonFaster))
                        {
                            DmgFight(myPokemon, enemyPokemon, myPokemon.GetMovements()[movementOption - 1]);
                            CheckLife(enemyPokemon);
                            io.SlowWrite("Has atacado a " + enemyPokemon.GetName() + " usando " + myPokemon.GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + enemyPokemon.GetCurrentHP() + " puntos de vida.");
                        }

                        if (!myPokemonFirst || (samePriority && !myPokemonFaster))
                        {
                            DmgFight(enemyPokemon, myPokemon, enemyPokemon.GetMovements()[enemymovementOption]);
                            CheckLife(myPokemon);
                            io.SlowWrite(enemyPokemon.GetName() + " ha atacado a " + myPokemon.GetName() + " usando " + enemyPokemon.GetMovements()[enemymovementOption].GetName() + ", y ahora tiene " + myPokemon.GetCurrentHP() + " puntos de vida.");
                        }

                        myPokemon.GetMovements()[movementOption - 1].PpRemoveAttack(1); //Le quitamos un pp al ataque usado.

                        if (myPokemon.GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Oh.... Tu Pokémon ha sido debilitado... Has perdido el combate.");
                            exit = true;
                        }
                        else if (enemyPokemon.GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Enhorabuena, ¡has ganado el combate!");
                            exit = true;
                        }

                        break;
                    case 2:
                        io.SlowWrite("¿Qué Pokémon deseas cambiar por " + trainer.GetMyTeam()[0].GetName() + "? ");
                        ShowPokemonInfo();
                        int change = 0;
                        change = io.OptionCorrect(1, 6, change);
                        ChangePosition(change, randomenemy);
                        break;
                    case 3:
                        ShowBagInfoInCombat(rivalPokemon[randomenemy], randomenemy);
                        //Capture(rivalPokemon[randomenemy], randomenemy);
                        //AddPokemon(randomenemy);
                        if (rivalPokemon[randomenemy].GetIsCaptured() == true)
                        {
                            AddPokemon(randomenemy);
                            exit = true;
                        }
                        if (trainer.GetMyTeam()[0].GetHasEscaped() == true)
                        {
                            exit = true;
                            trainer.GetMyTeam()[0].SetHasEscaped(false);
                        }
                        break;
                    case 4:
                        int numberescape = Escape(trainer.GetMyTeam()[0], rivalPokemon[randomenemy]);
                        if (numberescape == 1)
                        {
                            io.SlowWrite("Has huido del combate con éxito.");
                            exit = true;
                        }
                        else
                        {
                            io.SlowWrite("No has podido huir del combate.");
                            DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[0]);
                            io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
                            exit = false;
                        }
                        break;
                    default:
                        io.SlowWrite("Elige una opción correcta:");
                        exit = false;
                        break;
                }
            }
        }

        public void ShowTrainerInfo() //Mostrar la información básica del jugador.
        {
            
            io.Space();
            io.ColorYellow("\t Datos del jugador: ");
            io.ColorBlue("\t Nombre: " + trainer.GetName()+". ");
            io.ColorMagenta("\t Género: " + trainer.GetGender() + ". ");
            io.ColorGreen("\t Número de ID: " + trainer.GetID() + ". ");
            io.ColorCyan("\t Tiempo jugado: " + trainer.GenerateTimePlayed() + ". ");
            io.ColorRed("\t Dinero: " + trainer.GetPokeDollars() + " pokedólares, " + trainer.GetBattlePoints() + " puntos de batalla y " + trainer.GetPokeMiles() + " pokemillas.");
            io.Space();

        }
        public void ShowBagInfoInCombat(IndividualPokemon Pokemon, int randomenemy)
        {
            io.SlowWrite("¿Qué tipo de objeto quieres ver?");
            string[] options = { "Botiquín", "Pokéballs", "Objetos de Combate", "Movimientos", "Tesoros", "Objetos Clave", "Otros", "Salir" };

            for (int i = 0; i < options.Length; i++)
            {
                io.SlowWrite(i + 1 + ". " + options[i]);
            }

            int pocketOption = io.OptionCorrect(1, options.Length, 0);

            if (pocketOption != options.Length)
            {
                ShowPocketBagInfo(pocketOption - 1);
                MenuBagUsesInCombat(pocketOption - 1, Pokemon, randomenemy);
            }
            else
            {
                io.SlowWrite("Has salido de la Mochila.");
            }
        }


        public void ShowBagInfo()
        {
            io.SlowWrite("¿Qué tipo de objeto quieres ver?");
            string[] options = { "Botiquín", "Pokéballs", "Objetos de Combate", "Movimientos", "Tesoros", "Objetos Clave", "Otros", "Salir" };

            for (int i = 0; i < options.Length; i++)
            {
                io.SlowWrite(i + 1+". "+ options[i]);
            }

            int pocketOption = io.OptionCorrect(1, options.Length, 0);

            if (pocketOption != options.Length)
            {
                ShowPocketBagInfo(pocketOption - 1);
                MenuBagUses(pocketOption - 1);
            }
            else
            {
                io.SlowWrite("Has salido de la Mochila.");
            }
        }

        public void ShowPocketBagInfo(int numPocket) //Función para mostrar los bolsillos en la mochila fuera del combate.
        {
            bool isEmpty = true;
            for (int i = 0; i < trainer.GetBag().GetItems()[numPocket].Length; ++i)
            {
                if (trainer.GetBag().GetItems()[numPocket][i] != null)
                {
                    isEmpty = false;
                    io.Space();
                    io.ColorYellow("\t" + (i + 1) + ". " + trainer.GetBag().GetItems()[numPocket][i].GetName() + " x " + trainer.GetBag().GetItems()[numPocket][i].GetQuantity());
                }
            }

            if (isEmpty)
            {
                io.Space();
                io.SlowWrite("No tienes ningún objeto en este bolsillo.");
            }
        }
        public void ShowPocketBagInfoWithPrice(int numPocket) //Función para mostrar los bolsillos en la mochila fuera del combate con el precio
        {
            bool isEmpty = true;
            for (int i = 0; i < trainer.GetBag().GetItems()[numPocket].Length; ++i)
            {
                if (trainer.GetBag().GetItems()[numPocket][i] != null)
                {
                    isEmpty = false;
                    io.Space();
                    io.ColorYellow("\t" + (i + 1) + ". " + trainer.GetBag().GetItems()[numPocket][i].GetName() + " x " + trainer.GetBag().GetItems()[numPocket][i].GetQuantity()
                        + " - Coste de venta: " + trainer.GetBag().GetItems()[numPocket][i].GetSellPricePokedollars() + " Pokedolláres.");
                }
            }

            if (isEmpty)
            {
                io.Space();
                io.SlowWrite("No tienes ningún objeto en este bolsillo.");
            }
            
        }

        public void CheckLife(IndividualPokemon pokemon) //Si la vida del Pokémon va a bajar de 0 en algún momento se la setteamos a 0 para que no se quede en negativo.
        {
            if (pokemon.GetCurrentHP() < 0) //controlarlo en los setters de los individuals.
            {
                pokemon.SetCurrentHP(0);
            }
        }      
        public void MenuBagUsesInCombat(int numPocket, IndividualPokemon rivalPokemon, int randomenemy) //Menu para usar en el combate
        {
            for (int i = 0; i < trainer.GetBag().GetItems()[numPocket].Length; ++i)
            {
                if (trainer.GetBag().GetItems()[numPocket][i] != null)
                {
                    if (trainer.GetBag().GetItems()[numPocket][i].UseItemInCombat() == true)
                    {
                        io.Space();
                        io.SlowWrite("¿Qué quieres hacer con los objetos?");
                        io.ColorYellow("\t 1. Usar.");
                        io.ColorBlue("\t 2. Salir.");
                        int pocketOption = 0;
                        pocketOption = io.OptionCorrect(1, 4, pocketOption);
                        switch (pocketOption)
                        {
                            case 1:                              
                                io.SlowWrite("Elija el item que desea usar: ");
                                ShowPocketBagInfo(numPocket);
                                int chosenItem = 0;
                                int max = 0;
                                for (int j = 0; j < trainer.GetBag().GetItems()[numPocket].Length; ++j) //Para que me de opción a elegir unicamente entre los Items que tengo
                                {
                                    if (trainer.GetBag().GetItems()[numPocket][j] != null)
                                    {
                                        max = j + 1;
                                    }
                                }
                                chosenItem = io.OptionCorrect(1, max, chosenItem);
                                if(numPocket == 1)
                                {
                                    io.SlowWrite("¿Estás seguro de utilizar " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + rivalPokemon.GetName()+ " ?");
                                    int areUSure = 0;
                                    io.ColorGreen(" 1. Si.");
                                    io.ColorRed(" 2. No.");
                                    areUSure = io.OptionCorrect(1, 2, areUSure);
                                    if (areUSure == 1)
                                    {
                                        trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(rivalPokemon,io);
                                        if (rivalPokemon.GetIsCaptured() == false)
                                        {
                                            DmgFight(rivalPokemon, trainer.GetMyTeam()[0], rivalPokemon.GetMovements()[0]);
                                        }
                                    }
                                    else
                                    {
                                        io.SlowWrite("Has salido del menu.");
                                        break;
                                    }
                                }else if (numPocket == 2) 
                                {
                                    io.SlowWrite("Has escapado del combate.");
                                    trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(trainer.GetMyTeam()[0],io);
                                }
                                else
                                {
                                    ShowPokemonInfo();
                                    io.SlowWrite("Elija el Pokémon sobre el que desea usar el objeto: ");
                                    max = 0;
                                    for (int j = 0; j < trainer.GetMyTeam().Length; ++j) //Para que me de opción a elegir unicamente entre los Pokémon que tengo
                                    {
                                        if (trainer.GetMyTeam()[j] != null) 
                                        {
                                            max = j + 1;
                                        }
                                    }
                                    int chosenPokemon = 0;
                                    chosenPokemon = io.OptionCorrect(1, max, chosenPokemon);
                                    io.SlowWrite("¿Estás seguro de utilizar " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + trainer.GetMyTeam()[chosenPokemon - 1].GetNickName() + " ?");
                                    int areUSure = 0; 
                                    io.ColorGreen(" 1. Si.");
                                    io.ColorRed(" 2. No.");
                                    areUSure = io.OptionCorrect(1, 2, areUSure);
                                    if(areUSure== 1)
                                    {
                                        trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(trainer.GetMyTeam()[chosenPokemon - 1],io);
                                        io.SlowWrite("Has usado " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + trainer.GetMyTeam()[chosenPokemon - 1].GetNickName() + " con éxito. ");
                                    }
                                    else
                                    {
                                        io.SlowWrite("Has salido del menu.");
                                        break;
                                    }                                   
                                }
                                if (trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetQuantity() > 1)
                                {
                                    trainer.GetBag().GetItems()[numPocket][chosenItem - 1].RemoveQuantity(1);
                                }
                                else
                                {
                                    for (int j = chosenItem - 1; j < trainer.GetBag().GetItems()[numPocket].Length - 1; ++j) //Esto es para mover los null a la derecha dejando los items a la izquierda del array.
                                    {
                                        trainer.GetBag().GetItems()[numPocket][j] = trainer.GetBag().GetItems()[numPocket][j + 1];
                                    }
                                    trainer.GetBag().GetItems()[numPocket][trainer.GetBag().GetItems()[numPocket].Length - 1] = null;
                                }
                                break;
                            
                            case 2:
                                io.SlowWrite("Has salido del menu.");
                                break;

                        }
                        io.Space();
                        break;
                    }
                    else
                    {
                        io.SlowWrite("Este tipo de objetos no se pueden usar en combate.");
                        break;
                    }
                }
            }
        }
        public void MenuBagUses(int numPocket) //Menu para usar los items fuera de combate.
        {
            for (int i = 0; i < trainer.GetBag().GetItems()[numPocket].Length; ++i)
            {
                if (trainer.GetBag().GetItems()[numPocket][i] != null)
                {
                    io.Space();
                    io.SlowWrite("¿Qué quieres hacer con los objetos?");
                    io.ColorYellow("\t 1. Usar.");
                    io.ColorRed("\t 2. Organizar.");
                    io.ColorGreen("\t 3. Tirar.");
                    io.ColorBlue("\t 4. Salir.");
                    int pocketOption = 0;
                    pocketOption = io.OptionCorrect(1, 4, pocketOption);
                    switch (pocketOption)
                    {
                        case 1:
                            if (trainer.GetBag().GetItems()[numPocket][i].UseItemOutCombat() == true)
                            {
                                ShowPocketBagInfo(numPocket);
                                io.SlowWrite("Elija el item que desea usar : ");
                                int chosenItem = 0;
                                int max = 0;
                                for (int j = 0; j < trainer.GetBag().GetItems()[numPocket].Length; ++j) //Para que me de opción a elegir unicamente entre los Items que tengo
                                {
                                    if (trainer.GetBag().GetItems()[numPocket][j] != null)
                                    {
                                        max = j + 1;
                                    }
                                }
                                chosenItem = io.OptionCorrect(1, max, chosenItem);
                                ShowPokemonInfo();
                                io.SlowWrite("Elija el Pokémon sobre el que desea usar el objeto: ");
                                max = 0;
                                for (int j = 0; j < trainer.GetMyTeam().Length; ++j) //Para que me de opción a elegir unicamente entre los Pokémon que tengo
                                {
                                    if (trainer.GetMyTeam()[j] != null)
                                    {
                                        max = j + 1;
                                    }
                                }
                                int chosenPokemon = 0;
                                chosenPokemon = io.OptionCorrect(1, max, chosenPokemon);
                                trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(trainer.GetMyTeam()[chosenPokemon - 1],io);
                                io.SlowWrite("Has usado " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + trainer.GetMyTeam()[chosenPokemon - 1].GetNickName() + " con éxito. ");
                                if (trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetQuantity() > 1)
                                {
                                    trainer.GetBag().GetItems()[numPocket][chosenItem - 1].RemoveQuantity(1);
                                }
                                else
                                {
                                    for (int j = chosenItem - 1; j < trainer.GetBag().GetItems()[numPocket].Length - 1; ++j) //Mover los null a la derecha dejando los items a la izquierda del array.
                                    {
                                        trainer.GetBag().GetItems()[numPocket][j] = trainer.GetBag().GetItems()[numPocket][j + 1];
                                    }
                                    trainer.GetBag().GetItems()[numPocket][trainer.GetBag().GetItems()[numPocket].Length - 1] = null;
                                }
                            }
                            else
                            {
                                io.SlowWrite("No puedes utilizar esta funcionalidad en este tipo de objetos");
                                break;
                            }

                            break;
                        case 2:
                            ShowPocketBagInfo(numPocket);
                            io.SlowWrite("Elija el item que desea mover : ");
                            int chosenItemm = 0;
                            int maxx = 0;
                            for (int j = 0; j < trainer.GetBag().GetItems()[numPocket].Length; ++j) //Para que me de opción a elegir unicamente entre los Items que tengo
                            {
                                if (trainer.GetBag().GetItems()[numPocket][j] != null)
                                {
                                    maxx = j + 1;
                                }
                            }
                            chosenItemm = io.OptionCorrect(1, maxx, chosenItemm);
                            io.SlowWrite("Elija la nueva posición del item : ");
                            int newPos = 0;
                            newPos = io.OptionCorrect(1, trainer.GetBag().GetItems()[numPocket].Length, newPos);
                            Item temp = trainer.GetBag().GetItems()[numPocket][chosenItemm - 1];
                            trainer.GetBag().GetItems()[numPocket][chosenItemm - 1] = trainer.GetBag().GetItems()[numPocket][newPos - 1];
                            trainer.GetBag().GetItems()[numPocket][newPos - 1] = temp;
                            break;
                        case 3:
                            if (trainer.GetBag().GetItems()[numPocket][i].ThrowItem())
                            {
                                io.SlowWrite("Elija el item que desea tirar : ");
                                chosenItemm = 0;
                                maxx = 0;
                                for (int j = 0; j < trainer.GetBag().GetItems()[numPocket].Length; ++j) //Para que me de opción a elegir unicamente entre los Items que tengo
                                {
                                    if (trainer.GetBag().GetItems()[numPocket][j] != null)
                                    {
                                        maxx = j + 1;
                                    }
                                }
                                chosenItemm = io.OptionCorrect(1, maxx, chosenItemm);
                                if (trainer.GetBag().GetItems()[numPocket][chosenItemm - 1].GetQuantity() > 1)
                                {
                                    trainer.GetBag().GetItems()[numPocket][chosenItemm - 1].RemoveQuantity(1);
                                }
                                else
                                {
                                    for (int j = chosenItemm - 1; j < trainer.GetBag().GetItems()[numPocket].Length - 1; ++j) //Mover los null a la derecha dejando los items a la izquierda del array.
                                    {
                                        trainer.GetBag().GetItems()[numPocket][j] = trainer.GetBag().GetItems()[numPocket][j + 1];
                                    }
                                    trainer.GetBag().GetItems()[numPocket][trainer.GetBag().GetItems()[numPocket].Length - 1] = null;
                                }
                            }
                            else
                            {
                                io.SlowWrite("No puedes utilizar esta funcionalidad en este tipo de objetos");
                                break;
                            }

                            break;
                        case 4:
                            io.SlowWrite("Has salido del Menu");
                            break;

                    }
                    io.Space();
                    break;

                }
            }
        }


        public void ShowBoxPokemon() //Mostrar las cajas Pokémon.
        {
            bool boxEmpty = true;
            for (int i = 0; i < boxPokemon.Length; ++i)
            {
                if (boxPokemon[i] != null)
                {
                    boxEmpty = false;
                    io.Space();
                    io.ColorYellow("\t Pokémon " + (i + 1));
                    io.ColorBlue("\t Especie: " + boxPokemon[i].GetName() + ". ");
                    io.Space();
                }
            }
            if (boxEmpty)
            {
                io.SlowWrite("No tienes ningún Pokémon en tus cajas correspondientes.");
                io.Space();
            }
        }

        public void ShowPokemonInfo() //Mostrar la información básica de mis Pokémon.
        {

            for (int i = 0; i < trainer.GetMyTeam().Length; ++i)
            {
                if (trainer.GetMyTeam()[i] != null)
                {
                    io.Space();
                    io.ColorYellow("\t Pokémon " + (i + 1));
                    io.ColorBlue("\t Especie: " + trainer.GetMyTeam()[i].GetName() + ". ");
                    io.ColorGreen("\t Vida: " + trainer.GetMyTeam()[i].GetCurrentHP() + ". ");
                    io.ColorRed("\t Vida máxima: " + trainer.GetMyTeam()[i].GetHpmax() + ". ");
                    io.ColorCyan("\t Mote: " + trainer.GetMyTeam()[i].GetNickName() + ". ");
                    io.Space();
                }    
            }
        }
        public void ShowMovements() //Mostrar información sobre los movimientos.
        {
            io.Space();
            const int maxmoves = 4;
            for (int i = 0; i < maxmoves; ++i) //usar constantes
            {
                io.SlowWrite("\t"+(i+1)+". "+(trainer.GetMyTeam()[0].GetMovements()[i]).GetName()+" " +(trainer.GetMyTeam()[0].GetMovements()[i]).GetPp() + "/" +(trainer.GetMyTeam()[0].GetMovements()[i]).GetPpMax() 
                    + " PS");
            }
        }

        public bool CheckUseMovement(Movements move) //Para no poder usar un movimiento si sus pp estan a 0. mover a movementes 
        {
            if (move.GetPp() == 0)
            {
                io.SlowWrite("No tienes los PP suficientes para usar este movimiento");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowMorePokemonInfo()
        {
            io.SlowWrite("Elige un Pokémon para saber más:");
            int option = io.OptionCorrect(1, 6, 0);
            ShowCaptureTime(option - 1);
        }

        public void ChangePositionMenu() //Función para cambiar de Pokémon en el menú.
        {          
            io.SlowWrite("Elige un Pokémon que quieras cambiar de posición: ");
            int option = 0;
            option = io.OptionCorrect(1, 6, option);
            io.Space();
            io.SlowWrite("Perfecto, vas a cambiar de posición a " + trainer.GetMyTeam()[option - 1].GetNickName() + ". Ahora elige que Pokémon ocupara su lugar:");
            int option2 = 0;
            option2 = io.OptionCorrect(1, 6, option2);
            io.Space();
            if (trainer.GetMyTeam()[option2-1] != null)
            {
                io.SlowWrite(trainer.GetMyTeam()[option-1].GetNickName() + " y " + trainer.GetMyTeam()[option2-1].GetNickName() + " han cambiado sus posiciones.");
                IndividualPokemon aux = trainer.GetMyTeam()[option - 1];
                trainer.GetMyTeam()[option - 1] = trainer.GetMyTeam()[option2 - 1];
                trainer.GetMyTeam()[option2 - 1] = aux;
            }
            else
            {
                io.SlowWrite("Vaya parece el último cambio no se ha podido realizar de la forma correcta..Inténtalo de nuevo. ");
            }

        }
        public void ShowCaptureTime(int i) //Función que nos mostrara la información de los Pokémon y si tiene fecha de captura.
        {
            if (trainer.GetMyTeam()[i] != null)
            {
                io.Space();
                io.ColorBlue("\t " + trainer.GetMyTeam()[i].GetNickName());
                io.ColorRed("\t Ataque: " + trainer.GetMyTeam()[i].GetAttack());
                io.ColorGreen("\t Defensa: " + trainer.GetMyTeam()[i].GetDefense());
                if (trainer.GetMyTeam()[i].GetCaptureDateTime() != null) //Si la fecha de captura esta vacia no se mostrará.
                {
                    io.ColorMagenta("\t Fecha de Captura: " + trainer.GetMyTeam()[i].GetCaptureDateTime());
                }
                io.ColorYellow("\t Velocidad: " + trainer.GetMyTeam()[i].GetSpeed());
                io.ColorCyan("\t Género: " + trainer.GetMyTeam()[i].GetGender());
                io.Space();
            }          
        }
        public void AddPokemon(int randomenemy) //Función para añadir los Pokémon capturados a mi equipo
        {
            for (int i = 0; i < trainer.GetMyTeam().Length; ++i)
            {
                if (trainer.GetMyTeam()[i] == null)
                {
                    rivalPokemon[randomenemy].SetIsCaptured(true);
                    trainer.GetMyTeam()[i] = rivalPokemon[randomenemy];
                    trainer.GetMyTeam()[i] = new IndividualPokemon(new SpeciesPokemon(rivalPokemon[randomenemy].GetName(),r), movements,r);
                    DateTime? currentDate = DateTime.Now;
                    trainer.GetMyTeam()[i].SetCaptureDateTime(currentDate);
                    PutNickName(i);
                    trainer.GetMyTeam()[i].SetEo(trainer.GetName()+trainer.GetGender()+trainer.GetID()+trainer.GetSecretNumber());
                    break;
                }
                if (trainer.GetMyTeam()[trainer.GetMyTeam().Length - 1] != null) //Si la bolsa esta llena se guardarán los Pokémon en la caja correspondiente.
                {
                    io.SlowWrite("Parece que tu equipo esta lleno. Pero no te preocupes, hemos mandando a " + rivalPokemon[randomenemy].GetName() + " a las Cajas Pokémon para que se mantenga a salvo. ");

                    for (int j = 0; j < boxPokemon.Length; ++j)
                    {
                        if (boxPokemon[j] == null)
                        {
                            rivalPokemon[randomenemy].SetIsCaptured(true);
                            boxPokemon[j] = rivalPokemon[randomenemy];
                            boxPokemon[j] = new IndividualPokemon(new SpeciesPokemon(rivalPokemon[randomenemy].GetName(),r), movements,r);
                            DateTime? currentDate = DateTime.Now;
                            trainer.GetMyTeam()[i].SetCaptureDateTime(currentDate);
                            boxPokemon[j].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber());
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public bool Capture(IndividualPokemon rivalpokemon, int randomenemy) //Función para poder capturar al Pokémon.
        {
            
            double ratiocapture = (3 * rivalpokemon.GetHpmax() - 2 * rivalpokemon.GetCurrentHP())  * rivalpokemon.GetCaptureRatio();
            ratiocapture = ratiocapture / 3 * rivalpokemon.GetHpmax();
            double agitated = 65536 / Math.Pow((255 / ratiocapture), 0.1875);
            
            int randomnumber = r.Next(0, 65536); //tenemos ya el random arrriba

            for (int i = 0; i < 4; ++i)
            {
                if (randomnumber >= agitated)
                {
                    io.SlowWrite("No se ha podido capturar al Pokémon.");
                    DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[0]);
                    io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
                    return false;
                }
            }
            io.SlowWrite("Has capturado al Pokémon con éxito.");
            //DateTime? currentDate = DateTime.Now;
            //rivalPokemon[randomenemy].SetCaptureDateTime(currentDate);
            return true;
        }

        public void Healpokemon(IndividualPokemon[] packpokemon) //Función para la opción del Centro Pokémon, para restablecer su vida actual a la vida máxima correspondiente.
        {
            // restaurar vida
            for (int i = 0; i < packpokemon.Length; ++i)
            {
                if (packpokemon[i] != null)
                {
                    packpokemon[i].SetCurrentHP(packpokemon[i].GetHpmax());
                    for (int j = 0; j < packpokemon[i].GetMovements().Length; ++j)
                    {
                        packpokemon[i].GetMovements()[j].SetPp(packpokemon[i].GetMovements()[j].GetPpMax()); //funcion restaurar pp
                    }
                }
            }
         
        }
        public void ChangePosition(int change, int randomenemy) //Función para cambiar de Pokémon en el combate.
        {
            if (trainer.GetMyTeam()[1] != null)
            {
                IndividualPokemon aux = trainer.GetMyTeam()[0];
                trainer.GetMyTeam()[0] = trainer.GetMyTeam()[change - 1];
                trainer.GetMyTeam()[change - 1] = aux;
                DmgFight(rivalPokemon[randomenemy], trainer.GetMyTeam()[0], rivalPokemon[randomenemy].GetMovements()[0]);
                io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + trainer.GetMyTeam()[0].GetName() + " y ahora tiene " + trainer.GetMyTeam()[0].GetCurrentHP() + " puntos de vida.");
            }
            else
            {
                io.SlowWrite("Vaya.. parece que solo tienes 1 Pokémon, no has realizado ningún cambio. ");
            }
        }

        public void PutNickName(int number) //Función para poner mote al Pokémon.
        {
            io.SlowWrite("¿Te gustaría ponerle un mote a tu Pokémon?");
            io.ColorGreen(" 1. Si.");
            io.ColorRed(" 2. No.");
            int option = 0;
            option = io.OptionCorrect(1, 2, option);
            if (option == 1)
            {
                io.SlowWrite("Escribe como quieres llamar a tu Pokémon: ");
                string nickName = io.ReadLine();
                trainer.GetMyTeam()[number].SetNickName(nickName);
                io.SlowWrite("Perfecto, ahora tu Pokémon tiene el mote : "+ nickName+ ". ");
            }
            else
            {
                io.SlowWrite("Perfecto, no le has puesto ningún mote a tu Pokémon.");
            }
        }

        public double DmgFight(IndividualPokemon mypokemon, IndividualPokemon rivalpokemon, Movements movement) //Función que devuelve el cálculo del daño del combate.
        {
            
            double random = r.Next(85, 101);
            double rand = random / 100;
            int valueAttack;
            if(movement.GetCategory() == "Physical")
            {
                valueAttack = mypokemon.GetAttack();
            } else if (movement.GetCategory() == "Special")
            {
                valueAttack = mypokemon.GetSpecialAttack();
            }
            else
            {
                return 0;
            }
            double dmg = (2 * movement.GetPower() * (valueAttack / rivalpokemon.GetDefense()) / 50 + 2) * rand * CriticDmg();
            rivalpokemon.SetCurrentHP(rivalpokemon.GetCurrentHP() - (int)dmg); //Quitamos la vida al pokémon rival según el daño causado.
            return (int)dmg;

        }
        public double CriticDmg() //Función que nos devuelve si el ataque ha sido crítico o no.
        {
            
            double crit = r.Next(1, 25);
            if (crit == 1)
            {
                return 1.5;
            }
            else
            {
                return 1;
            }
        }
        public int Escape(IndividualPokemon mypokemon, IndividualPokemon rivalpokemon) //Función para la opción escapar dentro del combate pokémon.
        {
            if (mypokemon.GetSpeed() >= rivalpokemon.GetSpeed())
            {
                return 1;
            }
            else
            {
                bool exit = false;
                int attempts = 1;
                
                int probabilityescape = r.Next(0, 256);
                while (exit == false)
                {
                    double oddsescape = (((mypokemon.GetSpeed() * 128) / rivalpokemon.GetSpeed()) + 30 * attempts) % 256;
                    ++attempts;
                    if (probabilityescape < oddsescape)
                    {
                        exit = true;

                    }
                    else
                    {
                        DmgFight(rivalpokemon, mypokemon, rivalpokemon.GetMovements()[0]);
                        return 0;
                    }
                }
                return 1;
            }
        }
        public IndividualPokemon[] StartPokemon(Movements[] allMoves)   // Función que contiene un array de los 3 Pokémon iniciales
        {
            IndividualPokemon[] speciesPokemons= AllPokemon(allMoves);
            IndividualPokemon[] startpokemon = new IndividualPokemon[3];
            startpokemon[0] = speciesPokemons[0];
            startpokemon[1] = speciesPokemons[1];
            startpokemon[2] = speciesPokemons[2];
            return startpokemon;
        }
        public IndividualPokemon[] RivalPokemon(Movements[] allMoves) // Función que contiene un array de los posibles rivales del jugador
        {
            IndividualPokemon[] speciesPokemons = AllPokemon(allMoves);
            IndividualPokemon[] rivalpokemon = new IndividualPokemon[6];
            rivalpokemon[0] = speciesPokemons[3];
            rivalpokemon[1] = speciesPokemons[4];
            rivalpokemon[2] = speciesPokemons[5];
            rivalpokemon[3] = speciesPokemons[6];
            rivalpokemon[4] = speciesPokemons[7];
            rivalpokemon[5] = speciesPokemons[8];
            return rivalpokemon;
        }

        public IndividualPokemon[] AllPokemon(Movements[] allMoves)
        {
            List<IndividualPokemon> list = new List<IndividualPokemon>();
            IndividualPokemon[] speciesPokemons = list.ToArray();
            MySqlConnection con;

            con = new MySqlConnection("server=127.0.0.1; database=Pokemon; Uid=root; pwd=root;");
            con.Open();
            MySqlCommand query = new MySqlCommand("select * from speciespokemon", con);

            MySqlDataReader ra = query.ExecuteReader();

            while (ra.Read())
            {
                
                string name;
                           
                name = ra.GetString(0);
                

                /*SpeciesPokemon newPokemon = new SpeciesPokemon(name);*/

                list.Add(new IndividualPokemon(new SpeciesPokemon(name,r),allMoves,r));
                

            }
            speciesPokemons = list.ToArray();
            con.Close();

            
            return speciesPokemons;
        }
        /*public Movements[] LoadMovementsList() //Función para crear los movimientos.
        {
            Movements[] movements = new Movements[7];
            movements[0] = new Movements("Physical", "Placaje", 1, 35, 40, 100, 0);
            movements[1] = new Movements("Physical", "Látigo Cepa", 2, 25, 45, 100, 0);
            movements[2] = new Movements("Physical", "Derribo", 3, 20, 90, 85, 0);
            movements[3] = new Movements("Special", "Hoja afilada", 4, 25, 45, 100, 0);
            movements[4] = new Movements("Physical", "Arañazo", 5, 35, 40, 100, 0);
            movements[5] = new Movements("Special", "Ascuas", 6, 25, 40, 100, 0);
            movements[6] = new Movements("Special", "Lanzallamas", 7, 15, 90, 100, 0);
            return movements;
        }*/
        public Movements[] LoadMovementsList() //Función para crear los movimientos.
        {
            List<Movements> list = new List<Movements>();
            Movements[] movements = list.ToArray();
            MySqlConnection con;

            con = new MySqlConnection("server=127.0.0.1; database=Pokemon; Uid=root; pwd=root;");
            con.Open();
            MySqlCommand query = new MySqlCommand("SELECT * FROM Movement", con);

            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                string category;
                string name;
                int ID;
                int pp;
                int power;
                int accuracy;
                int priority;
                int ppmax;

                category = r.GetString(0);
                name = r.GetString(1);
                ID = r.GetInt32(2);
                ppmax = r.GetInt32(3);
                power = r.GetInt32(4);
                accuracy = r.GetInt32(5);
                priority = r.GetInt32(6);
                pp = ppmax;

                Movements newlumno = new Movements( category,  name,  ID,  ppmax,  power,  accuracy,  priority);

                list.Add(newlumno);
               
                //Console.WriteLine("Nombre: "+ name + ". Score: " + score);
            }
            movements = list.ToArray();
            con.Close();

           /* for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }*/
            return movements;
        }

        public Item[] GiveItemShop() //Función para mostrar los items de la tienda.
        {
            Item[] listItem = new Item[500];          
            Potion potion = new Potion();
            listItem[0] = potion.AssignHyperPotion();
            listItem[1]=potion.AssignPotion();
            listItem[2]=potion.AssignSuperPotion();
            listItem[3]=potion.AssignMaxPotion();
            Elixirs elixir = new Elixirs();
            listItem[4] = elixir.AssignEther();
            listItem[5] = elixir.AssignMaxElixir();
            listItem[6] = elixir.AssignMaxEther();
            listItem[7] = elixir.AssignElixir();
            PokeballItem pokeball = new PokeballItem();
            listItem[8] = pokeball.AssignPokeball();
            listItem[9] = pokeball.AssignSuperball();
            listItem[10] = pokeball.AssignUltraball();
            listItem[11] = pokeball.AssignMasterball();
            Pokedoll pokedoll = new Pokedoll();
            listItem[12] = pokedoll.AssignPokedoll();
            Treasures treasures = new Treasures();
            listItem[13] = treasures.AssignBigMushroom();
            listItem[14] = treasures.AssignPerl();
            listItem[15] = treasures.AssignBigNugget();
            listItem[16] = treasures.AssignBigPearl();
            listItem[17] = treasures.AssignCometShard();
            listItem[18] = treasures.AssignNugget();
            listItem[19] = treasures.AssignStardust();
            listItem[20] = treasures.AssignStarPiece();
            EvolutionStone evolutionStone = new EvolutionStone();
            listItem[21] = evolutionStone.AssignWaterStone();
            listItem[22] = evolutionStone.AssignFireStone();
            listItem[23] = evolutionStone.AssignPlantStone();
            return listItem;
        }
        public void ShowShopItem() //Funcion para enseñar los items en la tienda.
        {
            io.Space();
            for (int i=0;i< listItem.Length; ++i)
            {
                if (listItem[i] != null)
                {
                    string itemPriceString = ("\t" + (i + 1) + ". " + listItem[i].GetName() + " x 1 " + "Coste: " + listItem[i].GetBuyPricePokedollars() + " Pokedóllares.");
                    if (itemPriceString.Length < 40)
                    {
                        io.SlowWriteWithOutSpace(itemPriceString + "   ");
                    }
                    else
                    {
                        io.SlowWriteWithOutSpace(itemPriceString);
                    }

                    if ((i + 1) % 2 == 0)
                    {
                        io.SlowWriteWithOutSpace("\n");
                        io.Space();
                    }
                }              
            }        
        }
        public void BuyItem(int item, int numberItems) //Comprar items y meterlo en el bolsillo correspondiente.
        {
            bool isBought = false;
            while (isBought == false)
            {
                if (trainer.GetPokeDollars() >= (listItem[item - 1].GetBuyPricePokedollars() * numberItems))
                {
                    io.SlowWrite("¿Estás seguro que quieres comprar " + numberItems + " unidades de " + listItem[item - 1].GetName());
                    io.ColorGreen("\t 1. Si.");
                    io.ColorRed("\t 2. No.");
                    int option = 0;
                    option = io.OptionCorrect(1, 2, option);
                    if (option == 1)
                    {
                        int pocket = GetPocket(listItem[item - 1]);
                        if (pocket >= 0)
                        {
                            Item[][] items = trainer.GetBag().GetItems();
                            for (int i = 0; i < items[pocket].Length; ++i)
                            {
                                if (items[pocket][i] != null && items[pocket][i].GetName() == (listItem[item - 1].GetName()))
                                {
                                    items[pocket][i].AddQuantity(numberItems);
                                    io.SlowWrite("Has comprado " + numberItems + " unidades de " + items[pocket][i].GetName()); //moverlo
                                    break;
                                }
                                else if (items[pocket][i] == null)
                                {
                                    items[pocket][i] = listItem[item - 1];
                                    items[pocket][i].AddQuantity(numberItems);
                                    io.SlowWrite("Has comprado " + numberItems + " unidades de " + items[pocket][i].GetName());
                                    break;
                                }
                            }
                            trainer.SetPokeDollars(trainer.GetPokeDollars() - listItem[item - 1].GetBuyPricePokedollars() * numberItems);
                            isBought = true;
                        }    
                    }
                    else
                    {
                        io.SlowWrite("Has salido del Menú de compra");
                        break;
                    }
                }
                else
                {
                    io.SlowWrite("No tienes dinero suficiente para comprar " + numberItems + " unidades de " + listItem[item - 1].GetName() + ".");
                    break;
                }
            }
        }

        public void SellItem() //Función para vender en la tienda
        {
            io.ColorYellow("\t 1. Botiquín.");
            io.ColorRed("\t 2. Pokéballs.");
            io.ColorGreen("\t 3. Objetos de Combate.");
            io.ColorMagenta("\t 4. Tesoros.");
            io.ColorYellow("\t 5. Objetos Clave.");
            io.ColorBlue("\t 6. Otros.");
            io.ColorBlue("\t 7. Salir.");
            int pocketOption = 0;
            pocketOption = io.OptionCorrect(1, 8, pocketOption);
            switch (pocketOption)
            {
                case 1:
                    ShowPocketBagInfoWithPrice(0);
                    MenuSell(0);
                    break;
                case 2:
                    ShowPocketBagInfoWithPrice(1);
                    MenuSell(1);
                    break;
                case 3:
                    ShowPocketBagInfoWithPrice(2);
                    MenuSell(2);
                    break;
                case 4:
                    ShowPocketBagInfoWithPrice(4);
                    MenuSell(4);
                    break;
                case 5:
                    ShowPocketBagInfoWithPrice(5);
                    MenuSell(5);
                    break;
                case 6:
                    ShowPocketBagInfoWithPrice(6);
                    MenuSell(6);
                    break;
                case 7:
                    io.SlowWrite("Has salido de la Mochila.");
                    break;
            }
        }

        public void MenuSell(int numPocket) //Funcionalidad de la venta en el menu.
        {
            io.SlowWrite("¿Quieres vender algún objeto?");
            io.ColorGreen("\t 1. Si.");
            io.ColorRed("\t 2. No.");
            int option = 0;
            option = io.OptionCorrect(1, 2, option);
            if (option == 1)
            {
                io.SlowWrite("Elija el item que desea vender: ");
                int chosenItem = 0;
                int max = 0;
                for (int j = 0; j < trainer.GetBag().GetItems()[numPocket].Length; ++j) //Para que me de opción a elegir unicamente entre los Items que tengo
                {
                    if (trainer.GetBag().GetItems()[numPocket][j] != null)
                    {
                        max = j + 1;
                    }
                }
                chosenItem = io.OptionCorrect(1, max, chosenItem);
                io.SlowWrite("¿Cuantas unidades quieres vender?: ");
                int numItems = 0;
                numItems = io.OptionCorrect(1, trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetQuantity(), numItems);
                io.SlowWrite("¿Estás seguro que quieres vender " + numItems + " unidades de " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " por " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetSellPricePokedollars() * numItems + " Pokedolláres?");
                io.ColorGreen("\t 1. Si.");
                io.ColorRed("\t 2. No.");
                int confirm = 0;
                confirm = io.OptionCorrect(1, 2, confirm);
                if (confirm == 1)
                {
                    if (numItems == 1)
                    {
                        io.SlowWrite("Has vendido " + numItems + " unidad de " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + ".");
                        io.SlowWrite("Has ganado " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetSellPricePokedollars() * numItems + " Pokedolláres.");
                    }//segunda linea puede ir fuera
                    else
                    {
                        io.SlowWrite("Has vendido " + numItems + " unidades de " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + ".");
                        io.SlowWrite("Has ganado " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetSellPricePokedollars() * numItems + " Pokedolláres.");
                    }
                    trainer.SetPokeDollars(trainer.GetPokeDollars() + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetSellPricePokedollars() * numItems);
                    trainer.GetBag().GetItems()[numPocket][chosenItem - 1].RemoveQuantity(numItems);
                    if (trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetQuantity() == 0)
                    {
                        for (int j = chosenItem - 1; j < trainer.GetBag().GetItems()[numPocket].Length - 1; ++j) //Mover los null a la derecha dejando los items a la izquierda del array.
                        {
                            trainer.GetBag().GetItems()[numPocket][j] = trainer.GetBag().GetItems()[numPocket][j + 1];
                        }
                        trainer.GetBag().GetItems()[numPocket][trainer.GetBag().GetItems()[numPocket].Length - 1] = null;
                    }
                }
                else
                {
                    io.SlowWrite("Perfecto, no has vendido ningun objeto.");
                }        
            }
        }
        public int GetPocket(Item item) //Comprobar a que bolsillo pertenece un item.
        {
            if (item is Medicine)
            {
                return 0;
            }
            else if (item is PokeballItem)
            {
                return 1;
            }
            else if (item is BattleItem)
            {
                return 2;
            }
            else if (item is MT)
            {
                return 3;
            }
            else if (item is Treasures)
            {
                return 4;
            }
            else if (item is EvolutionStone)
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }
        public  int RandomEnemy(int min, int max) //Generar un Pokémon random aleatorio. 
        {
            
            int randomnum = r.Next(min, max);
            return randomnum;
        }
    }
}

