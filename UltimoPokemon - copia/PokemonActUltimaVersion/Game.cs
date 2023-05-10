using PokemonAct;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WpfApp2;

namespace Pokemon
{
    class Game
    {
        //Creación de instancias de la clase Io, Random  SpeciesPokemon  IndividialPokemon , Trainer, movimientos, mochila y item. para poder utilizar funciones de clases anteriores.
        IO io;
        Random r = new Random();
        SpeciesPokemon pokemon;
        Trainer trainer;
        IndividualPokemon myPokemon;
        IndividualPokemon[] startPokemon;
        IndividualPokemon[] packPokemon; //dentro de entrenador
        IndividualPokemon[] rivalPokemon;
        IndividualPokemon[] boxPokemon;
        Movements[] movements;
        Bag bag; //dentro de entrenador
        Item[] listItem;
        public Game(IO io) //Constructor que inicia el juego de forma lenta.
        {
            this.io = io;
            pokemon = new SpeciesPokemon();
            movements = LoadMovementsList();
            myPokemon = new IndividualPokemon(pokemon, movements);
            bag = new Bag();
            trainer = new Trainer(bag,io);   
            startPokemon = StartPokemon(movements);
            packPokemon = trainer.PackPokemon();
            rivalPokemon = RivalPokemon(movements);
            boxPokemon = trainer.BoxPokemon();
            listItem= GiveItemShop();
            /*SlowStart();*/
        }
        public Game() //Constructor que inicia el juego de forma rápida.
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
        }
        public void Run() //Función con el Menú principal del juego.
        {
            io.SlowWrite("¿Quieres usar la opción rápida o lenta?");
            io.SlowWrite("\t 1. Rápida.");
            io.SlowWrite("\t 2. Lenta.");
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
            chosenPokemon = io.OptionCorrect(1, 3, chosenPokemon);
            bool exit = false;
            while (exit == false)
            {
                switch (chosenPokemon)
                {
                    case 1:
                        io.SlowWrite("Así que Bulbasaur! Resulta muy fácil criarlo.");
                        packPokemon[0] = startPokemon[0];
                        PutNickName(0);//sacar estas lineas 
                        packPokemon[0].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber());
                        exit = true;
                        break;
                    case 2:
                        io.SlowWrite("Así que Charmander! Pues ten paciencia con él.");
                        packPokemon[0] = startPokemon[1];
                        PutNickName(0);
                        packPokemon[0].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber());
                        exit = true;
                        break;
                    case 3:
                        io.SlowWrite("¡Así que Squirtle! Merece la pena, sí, sí. ");
                        packPokemon[0] = startPokemon[2];
                        PutNickName(0);
                        packPokemon[0].SetEo(trainer.GetName() + trainer.GetGender() + trainer.GetID() + trainer.GetSecretNumber());
                        exit = true;
                        break;
                }
            }
            io.SlowWrite("Enhorabuena, este será el Pokémon que te acompañe a partir de ahora, no dudes en cuidarlo y visitarme de vez en cuando.");
            io.Space();
        }

        public void FastStart() //Función para el inicio rápido, nos da un Pokémon sin elegirlo nosotros.
        {
            packPokemon[0] = startPokemon[1]; //Damos por defecto a Charmander como Pokémon inicial.
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
                menuoption = io.OptionCorrect(1, 8, menuoption);
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
                             Healpokemon(packPokemon);
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
                            itemOption = io.OptionCorrect(1, 22, itemOption); //cambiar esto
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
                    default:
                        io.SlowWrite("Elige una opción correcta.");
                        break;
                }
            }
        }
        public void Fight() //Función para el combate Pokémon.
        {
            
            int randomenemy = RandomEnemy(0,5); //Generamos un enemigo aleatorio dentro de lista de array enemigos.
            bool exit = false;
            while (exit == false)
            {
                io.SlowWrite("¿Qué deseas hacer?");
                io.Space();
                if (packPokemon[0].GetCurrentHP()>0 && rivalPokemon[randomenemy].GetCurrentHP() > 0)
                {
                    io.SlowWrite("Datos: " + packPokemon[0].GetCurrentHP() + " puntos de vida de mi Pokémon " + packPokemon[0].GetName() + ",  " + rivalPokemon[randomenemy].GetCurrentHP() +
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
                        io.SlowWrite("¿Qué ataque deseas realizar?");
                        ShowMovements();
                        int movementOption = 0;
                        movementOption = io.OptionCorrect(1, 4, movementOption);
                        int enemymovementOption = RandomEnemy(0, 3);
                        io.Space();
                        if (packPokemon[0].GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Tu Pokémon no puede luchar porque esta debilitado. ");
                            int change2 = io.AskNumber();
                            ChangePosition(change2, randomenemy);
                        }

                        if (packPokemon[0].GetMovements()[movementOption-1].GetPriority() > rivalPokemon[randomenemy].GetMovements()[enemymovementOption].GetPriority())
                        {
                            if (packPokemon[0].GetSpeed() > rivalPokemon[randomenemy].GetSpeed())
                            {
                                while(CheckUseMovement(packPokemon[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(packPokemon[0], rivalPokemon[randomenemy], packPokemon[0].GetMovements()[movementOption - 1]);
                                CheckLife(rivalPokemon[randomenemy]);
                                io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() +" usando "+ packPokemon[0].GetMovements()[movementOption-1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                if (rivalPokemon[randomenemy].GetCurrentHP() > 0)
                                {
                                    DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                    CheckLife(packPokemon[0]);
                                    io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " usando " + rivalPokemon[enemymovementOption].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                            else
                            {
                                while (CheckUseMovement(packPokemon[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                CheckLife(packPokemon[0]);
                                io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " usando " + rivalPokemon[enemymovementOption].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
                                if (packPokemon[0].GetCurrentHP() > 0)
                                {
                                    DmgFight(packPokemon[0], rivalPokemon[randomenemy], packPokemon[0].GetMovements()[movementOption - 1]);
                                    CheckLife(rivalPokemon[randomenemy]);
                                    io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() + " usando " + packPokemon[0].GetMovements()[movementOption-1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                        }

                        if (packPokemon[0].GetMovements()[movementOption-1].GetPriority() == rivalPokemon[randomenemy].GetMovements()[enemymovementOption].GetPriority())
                        {
                            if (packPokemon[0].GetSpeed() > rivalPokemon[randomenemy].GetSpeed())
                            {
                                while (CheckUseMovement(packPokemon[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(packPokemon[0], rivalPokemon[randomenemy], packPokemon[0].GetMovements()[movementOption - 1]);
                                CheckLife(rivalPokemon[randomenemy]);
                                io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() + " usando " + packPokemon[0].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                if (rivalPokemon[randomenemy].GetCurrentHP() > 0)
                                {
                                    DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                    CheckLife(packPokemon[0]);
                                    io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " usando " + rivalPokemon[randomenemy ].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                            else
                            {
                                while (CheckUseMovement(packPokemon[0].GetMovements()[movementOption - 1]))
                                {
                                    ShowMovements();
                                    movementOption = 0;
                                    movementOption = io.OptionCorrect(1, 4, movementOption);
                                }
                                DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[enemymovementOption]);
                                CheckLife(packPokemon[0]);
                                io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " usando " + rivalPokemon[randomenemy].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
                                if (packPokemon[0].GetCurrentHP() > 0)
                                {
                                    DmgFight(packPokemon[0], rivalPokemon[randomenemy], packPokemon[0].GetMovements()[movementOption - 1]);
                                    CheckLife(rivalPokemon[randomenemy]);
                                    io.SlowWrite("Has atacado a " + rivalPokemon[randomenemy].GetName() + " usando " + packPokemon[0].GetMovements()[movementOption - 1].GetName() + ", y ahora tiene " + rivalPokemon[randomenemy].GetCurrentHP() + " puntos de vida.");
                                }
                            }
                        }
                        packPokemon[0].GetMovements()[movementOption - 1].PpRemoveAttack(1); //Le quitamos un pp al ataque usado.
                        if (packPokemon[0].GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Oh.... Tu Pokémon ha sido debilitado... Has perdido el combate.");
                            exit = true;
                        }
                        else if (rivalPokemon[randomenemy].GetCurrentHP() <= 0)
                        {
                            io.SlowWrite("Enhorabuena, ¡has ganado el combate!");
                            exit = true;
                        }
                        break;
                    case 2:
                        io.SlowWrite("¿Qué Pokémon deseas cambiar por " + packPokemon[0].GetName() + "? ");
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
                        if (packPokemon[0].GetHasEscaped() == true)
                        {
                            exit = true;
                            packPokemon[0].SetHasEscaped(false);
                        }
                        break;
                    case 4:
                        int numberescape = Escape(packPokemon[0], rivalPokemon[randomenemy]);
                        if (numberescape == 1)
                        {
                            io.SlowWrite("Has huido del combate con éxito.");
                            exit = true;
                        }
                        else
                        {
                            io.SlowWrite("No has podido huir del combate.");
                            DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[0]);
                            io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
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
        public void ShowBagInfoInCombat(IndividualPokemon rivalPokemon, int randomenemy) //Mostrar la mochila del jugador.
        {

            io.SlowWrite("¿Qué tipo de objeto quieres ver?");
            io.ColorYellow("\t 1. Botiquín.");
            io.ColorRed("\t 2. Pokéballs.");
            io.ColorGreen("\t 3. Objetos de Combate.");
            io.ColorCyan("\t 4. Movimientos.");
            io.ColorMagenta("\t 5. Tesoros.");
            io.ColorYellow("\t 6. Objetos Clave.");
            io.ColorBlue("\t 7. Otros.");
            io.ColorBlue("\t 8. Salir.");
            int pocketOption = 0;
            pocketOption = io.OptionCorrect(1, 8, pocketOption);
            switch (pocketOption)
            {
                case 1:
                    ShowPocketBagInfo(0);
                    MenuBagUsesInCombat(0, rivalPokemon, randomenemy);
                    break;
                case 2:
                    ShowPocketBagInfo(1);
                    MenuBagUsesInCombat(1, rivalPokemon, randomenemy);
                    break;
                case 3:
                    ShowPocketBagInfo(2);
                    MenuBagUsesInCombat(2, rivalPokemon, randomenemy);
                    break;
                case 4:
                    ShowPocketBagInfo(3);
                    MenuBagUsesInCombat(3, rivalPokemon, randomenemy);
                    break;
                case 5:
                    ShowPocketBagInfo(4);
                    MenuBagUsesInCombat(4, rivalPokemon, randomenemy);
                    break;
                case 6:
                    ShowPocketBagInfo(5);
                    MenuBagUsesInCombat(5, rivalPokemon, randomenemy);
                    break;
                case 7:
                    ShowPocketBagInfo(6);
                    MenuBagUsesInCombat(6, rivalPokemon, randomenemy);
                    break;
                case 8:
                    io.SlowWrite("Has salido de la Mochila.");
                    break;
            }
        }
        public void ShowBagInfo() //Mostrar la mochila del jugador.
        {

            io.SlowWrite("¿Qué tipo de objeto quieres ver?");
            io.ColorYellow("\t 1. Botiquín.");
            io.ColorRed("\t 2. Pokéballs.");
            io.ColorGreen("\t 3. Objetos de Combate.");
            io.ColorCyan("\t 4. Movimientos.");
            io.ColorMagenta("\t 5. Tesoros.");
            io.ColorYellow("\t 6. Objetos Clave.");
            io.ColorBlue("\t 7. Otros.");
            io.ColorBlue("\t 8. Salir.");
            int pocketOption = 0;
            pocketOption = io.OptionCorrect(1, 8, pocketOption);
            switch (pocketOption)
            {
                case 1:
                    ShowPocketBagInfo(0);
                    MenuBagUses(0); //mirar delegados 
                    break;
                case 2:
                    ShowPocketBagInfo(1);
                    MenuBagUses(1);
                    break;
                case 3:
                    ShowPocketBagInfo(2);
                    MenuBagUses(2);
                    break;
                case 4:
                    ShowPocketBagInfo(3);
                    MenuBagUses(3);
                    break;
                case 5:
                    ShowPocketBagInfo(4);
                    MenuBagUses(4);
                    break;
                case 6:
                    ShowPocketBagInfo(5);
                    MenuBagUses(5);
                    break;
                case 7:
                    ShowPocketBagInfo(6);
                    MenuBagUses(6);
                    break;
                case 8:
                    io.SlowWrite("Has salido de la Mochila.");
                    break;
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
                                        trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(rivalPokemon);
                                        if (rivalPokemon.GetIsCaptured() == false)
                                        {
                                            DmgFight(rivalPokemon, packPokemon[0], rivalPokemon.GetMovements()[0]);
                                        }
                                    }
                                    else
                                    {
                                        io.SlowWrite("Has salido del menu.");
                                        break;
                                    }
                                }else if (numPocket == 2) //revisar
                                {
                                    io.SlowWrite("Has escapado del combate.");
                                    trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(packPokemon[0]);
                                }
                                else
                                {
                                    ShowPokemonInfo();
                                    io.SlowWrite("Elija el Pokémon sobre el que desea usar el objeto: ");
                                    max = 0;
                                    for (int j = 0; j < packPokemon.Length; ++j) //Para que me de opción a elegir unicamente entre los Pokémon que tengo
                                    {
                                        if (packPokemon[j] != null) //levar a trainer 
                                        {
                                            max = j + 1;
                                        }
                                    }
                                    int chosenPokemon = 0;
                                    chosenPokemon = io.OptionCorrect(1, max, chosenPokemon);
                                    io.SlowWrite("¿Estás seguro de utilizar " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + packPokemon[chosenPokemon - 1].GetNickName() + " ?");
                                    int areUSure = 0; //llevar a io
                                    io.ColorGreen(" 1. Si.");
                                    io.ColorRed(" 2. No.");
                                    areUSure = io.OptionCorrect(1, 2, areUSure);
                                    if(areUSure== 1)
                                    {
                                        trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(packPokemon[chosenPokemon - 1]);
                                        io.SlowWrite("Has usado " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + packPokemon[chosenPokemon - 1].GetNickName() + " con éxito. ");
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
                                    for (int j = chosenItem - 1; j < trainer.GetBag().GetItems()[numPocket].Length - 1; ++j) //Mover los null a la derecha dejando los items a la izquierda del array.
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
                                for (int j = 0; j < packPokemon.Length; ++j) //Para que me de opción a elegir unicamente entre los Pokémon que tengo
                                {
                                    if (packPokemon[j] != null)
                                    {
                                        max = j + 1;
                                    }
                                }
                                int chosenPokemon = 0;
                                chosenPokemon = io.OptionCorrect(1, max, chosenPokemon);
                                trainer.GetBag().GetItems()[numPocket][chosenItem - 1].Utility(packPokemon[chosenPokemon - 1]);
                                io.SlowWrite("Has usado " + trainer.GetBag().GetItems()[numPocket][chosenItem - 1].GetName() + " en " + packPokemon[chosenPokemon - 1].GetNickName() + " con éxito. ");
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

            for (int i = 0; i < packPokemon.Length; ++i)
            {
                if (packPokemon[i] != null)
                {
                    io.Space();
                    io.ColorYellow("\t Pokémon " + (i + 1));
                    io.ColorBlue("\t Especie: " + packPokemon[i].GetName() + ". ");
                    io.ColorGreen("\t Vida: " + packPokemon[i].GetCurrentHP() + ". ");
                    io.ColorRed("\t Vida máxima: " + packPokemon[i].GetHpmax() + ". ");
                    io.ColorCyan("\t Mote: " + packPokemon[i].GetNickName() + ". ");
                    io.Space();
                }    
            }
        }
        public void ShowMovements() //Mostrar información sobre los movimientos.
        {
            io.Space();
            for (int i = 0; i < 4; ++i) //usar constantes
            {
                io.SlowWrite("\t"+(i+1)+". "+(packPokemon[0].GetMovements()[i]).GetName()+" " +(packPokemon[0].GetMovements()[i]).GetPp() + "/" +(packPokemon[0].GetMovements()[i]).GetPpMax() 
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
        public void ShowMorePokemonInfo() // Mostrar información más detallada de los Pokémon.
        {
            io.SlowWrite("Elige un Pokémon para saber más:");
            int option = 0;
            option = io.OptionCorrect(1, 6, option);
            switch (option)
            {
                case 1:
                    ShowCaptureTime(0);
                    break;

                case 2:
                    ShowCaptureTime(1);
                    break;

                case 3:
                    ShowCaptureTime(2);
                    break;

                case 4:
                    ShowCaptureTime(3);
                    break;

                case 5:
                    ShowCaptureTime(4);
                    break;

                case 6:
                    ShowCaptureTime(5);
                    break;
            }

        }
        public void ChangePositionMenu() //Función para cambiar de Pokémon en el menú.
        {          
            io.SlowWrite("Elige un Pokémon que quieras cambiar de posición: ");
            int option = 0;
            option = io.OptionCorrect(1, 6, option);
            io.Space();
            io.SlowWrite("Perfecto, vas a cambiar de posición a " + packPokemon[option - 1].GetNickName() + ". Ahora elige que Pokémon ocupara su lugar:");
            int option2 = 0;
            option2 = io.OptionCorrect(1, 6, option2);
            io.Space();
            if (packPokemon[option2-1] != null)
            {
                io.SlowWrite(packPokemon[option-1].GetNickName() + " y " + packPokemon[option2-1].GetNickName() + " han cambiado sus posiciones.");
                IndividualPokemon aux = packPokemon[option - 1];
                packPokemon[option - 1] = packPokemon[option2 - 1];
                packPokemon[option2 - 1] = aux;
            }
            else
            {
                io.SlowWrite("Vaya parece el último cambio no se ha podido realizar de la forma correcta..Inténtalo de nuevo. ");
            }

        }
        public void ShowCaptureTime(int i) //Función que nos mostrara la información de los Pokémon y si tiene fecha de captura.
        {
            if (packPokemon[i] != null)
            {
                io.Space();
                io.ColorBlue("\t " + packPokemon[i].GetNickName());
                io.ColorRed("\t Ataque: " + packPokemon[i].GetAttack());
                io.ColorGreen("\t Defensa: " + packPokemon[i].GetDefense());
                if (packPokemon[i].GetCaptureDateTime() != null) //Si la fecha de captura esta vacia no se mostrará.
                {
                    io.ColorMagenta("\t Fecha de Captura: " + packPokemon[i].GetCaptureDateTime());
                }
                io.ColorYellow("\t Velocidad: " + packPokemon[i].GetSpeed());
                io.ColorCyan("\t Género: " + packPokemon[i].GetGender());
                io.Space();
            }          
        }
        public void AddPokemon(int randomenemy) //Función para añadir los Pokémon capturados a mi equipo
        {
            for (int i = 0; i < packPokemon.Length; ++i)
            {
                if (packPokemon[i] == null)
                {
                    rivalPokemon[randomenemy].SetIsCaptured(true);
                    packPokemon[i] = rivalPokemon[randomenemy];
                    packPokemon[i] = new IndividualPokemon(new SpeciesPokemon(rivalPokemon[randomenemy].GetName()), movements);
                    DateTime? currentDate = DateTime.Now;
                    packPokemon[i].SetCaptureDateTime(currentDate);
                    PutNickName(i);
                    packPokemon[i].SetEo(trainer.GetName()+trainer.GetGender()+trainer.GetID()+trainer.GetSecretNumber());
                    break;
                }
                if (packPokemon[packPokemon.Length - 1] != null) //Si la bolsa esta llena se guardarán los Pokémon en la caja correspondiente.
                {
                    io.SlowWrite("Parece que tu equipo esta lleno. Pero no te preocupes, hemos mandando a " + rivalPokemon[randomenemy].GetName() + " a las Cajas Pokémon para que se mantenga a salvo. ");

                    for (int j = 0; j < boxPokemon.Length; ++j)
                    {
                        if (boxPokemon[j] == null)
                        {
                            rivalPokemon[randomenemy].SetIsCaptured(true);
                            boxPokemon[j] = rivalPokemon[randomenemy];
                            boxPokemon[j] = new IndividualPokemon(new SpeciesPokemon(rivalPokemon[randomenemy].GetName()), movements);
                            DateTime? currentDate = DateTime.Now;
                            packPokemon[i].SetCaptureDateTime(currentDate);
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
            
            double ratiocapture = (3 * rivalpokemon.GetHpmax() - 2 * rivalpokemon.GetCurrentHP()) * 4096 * rivalpokemon.GetCaptureRatio();
            ratiocapture = ratiocapture / 3 * rivalpokemon.GetHpmax();
            double agitated = 65536 / Math.Pow((255 / ratiocapture), 0.1875);
            Random r = new Random();
            int randomnumber = r.Next(0, 65536); //tenemos ya el random arrriba

            for (int i = 0; i < 4; ++i)
            {
                if (randomnumber >= agitated)
                {
                    io.SlowWrite("No se ha podido capturar al Pokémon.");
                    DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[0]);
                    io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
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
            if (packPokemon[1] != null)
            {
                IndividualPokemon aux = packPokemon[0];
                packPokemon[0] = packPokemon[change - 1];
                packPokemon[change - 1] = aux;
                DmgFight(rivalPokemon[randomenemy], packPokemon[0], rivalPokemon[randomenemy].GetMovements()[0]);
                io.SlowWrite(rivalPokemon[randomenemy].GetName() + " ha atacado a " + packPokemon[0].GetName() + " y ahora tiene " + packPokemon[0].GetCurrentHP() + " puntos de vida.");
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
                packPokemon[number].SetNickName(nickName);
                io.SlowWrite("Perfecto, ahora tu Pokémon tiene el mote : "+ nickName+ ". ");
            }
            else
            {
                io.SlowWrite("Perfecto, no le has puesto ningún mote a tu Pokémon.");
            }
        }

        public double DmgFight(IndividualPokemon mypokemon, IndividualPokemon rivalpokemon, Movements movement) //Función que devuelve el cálculo del daño del combate.
        {
            Random r = new Random();
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
            Random r = new Random();
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
                Random r = new Random();
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
            IndividualPokemon[] startpokemon = new IndividualPokemon[3];
            startpokemon[0] = new IndividualPokemon(new SpeciesPokemon("Bulbasaur"), allMoves);
            startpokemon[1] = new IndividualPokemon(new SpeciesPokemon("Charmander"), allMoves);
            startpokemon[2] = new IndividualPokemon(new SpeciesPokemon("Squirtle"), allMoves);
            return startpokemon;
        }
        public IndividualPokemon[] RivalPokemon(Movements[] allMoves) // Función que contiene un array de los posibles rivales del jugador
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
        public Movements[] LoadMovementsList() //Función para crear los movimientos.
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
                                    io.SlowWrite("Has comprado " + numberItems + " unidades de " + items[pocket][i].GetName());
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
            Random r = new Random();
            int randomnum = r.Next(min, max);
            return randomnum;
        }
    }
}

