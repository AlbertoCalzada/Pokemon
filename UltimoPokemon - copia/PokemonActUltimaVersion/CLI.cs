using Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonAct
{
    internal class CLI : IO
    {
        public override void SlowWrite(string sentence) //Función para escribir letra a letra en color blanco todo.
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sentence[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
        public override void SlowWrite2(string sentence) //Función para escribir letra a letra en las opciones cambiadas al color mostrado posteriormente.
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                Console.Write(sentence[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        public override void SlowWriteWithOutSpace(string sentence) //Función para escribir letra a letra en las opciones cambiadas al color mostrado posteriormente.
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sentence[i]);
                Thread.Sleep(0);
            }
        }

        public override string ReadLine() //Función para  un string como valor a introducir por el usuario.
        {
            return Console.ReadLine();
        }

        public override int AskNumber() //Función para un int  como valor a introducir por el usuario.
        {
            return int.Parse(Console.ReadLine());
        }

        public override void Space() //Función para espacio en blanco entre frases o menús determinados del juego.
        {
            Console.WriteLine();
        }

        public override void ColorBlue(string sentence) //Función para cambiar el texto a color azul.
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ColorGreen(string sentence) //Función para cambiar el texto a color verde.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ColorRed(string sentence) //Función para cambiar el texto a color rojo.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ColorYellow(string sentence) //Función para cambiar el texto a color amarillo.
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ColorCyan(string sentence) //Función para cambiar el texto a color azul claro.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ColorMagenta(string sentence) //Función para cambiar el texto a color magenta.
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override int OptionCorrect(int num1, int num2, int option) //Función cuando pedimos un número por teclado y nos queremos asegurar de que está dentro del rango establecido
                                                                          //y permite si el usuario realiza por entrada algún valor que no sea entero que el programa pueda seguir su ejecución.
        {
            bool start = false;
            while (start == false)
            {
                string input = ReadLine();
                if (Int32.TryParse(input, out int value) && value >= num1 && value <= num2)
                {
                    option = value;
                    start = true;
                }
                else
                {
                    Space();
                    SlowWrite("Por favor ingresa un número del " + num1 + " al " + num2 + " . ");
                }
            }
            return option;
        }

    }
}
