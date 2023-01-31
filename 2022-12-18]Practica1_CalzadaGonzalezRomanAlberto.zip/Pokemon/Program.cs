using System;
using System.Threading;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args) //Método main con su sintaxis e instancias a la clase Io y Game para poder ejecutar el juego.
        {
            IO io = new IO();
            Game g = new Game();
            g.Run();
          
        }

    }
}

