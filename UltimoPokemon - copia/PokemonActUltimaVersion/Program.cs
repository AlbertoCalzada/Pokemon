using PokemonAct;
using System;
using System.Threading;
using WpfApp2;
namespace Pokemon
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) //Método main con su sintaxis e instancias a la clase Io y Game para poder ejecutar el juego.
        {

            IO io = new GUI();
            Game g = new Game(io);
            g.Run();
        }
    }
}

