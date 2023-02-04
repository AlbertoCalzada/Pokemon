using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pokemon
{
    class IO
    {
        public void SlowWrite(string sentence) //Función para escribir letra a letra en color blanco todo.
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sentence[i]);
                Thread.Sleep(0);
            }
            Console.WriteLine();
        }
        public void SlowWrite2(string sentence) //Función para escribir letra a letra en las opciones cambiadas al color mostrado posteriormente.
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                Console.Write(sentence[i]);
                Thread.Sleep(0);
            }
            Console.WriteLine();
        }

        public void SlowWriteWithOutSpace(string sentence) //Función para escribir letra a letra en las opciones cambiadas al color mostrado posteriormente.
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sentence[i]);
                Thread.Sleep(0);
            }
        }

        public string ReadLine() //Función para  un string como valor a introducir por el usuario.
        {
            return Console.ReadLine();
        }

        public int AskNumber() //Función para un int  como valor a introducir por el usuario.
        {
            return int.Parse(Console.ReadLine());
        }

        public void Space() //Función para espacio en blanco entre frases o menús determinados del juego.
        {
            Console.WriteLine();
        }

        public void ColorBlue(string sentence) //Función para cambiar el texto a color azul.
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ColorGreen(string sentence) //Función para cambiar el texto a color verde.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ColorRed(string sentence) //Función para cambiar el texto a color rojo.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ColorYellow(string sentence) //Función para cambiar el texto a color amarillo.
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ColorCyan(string sentence) //Función para cambiar el texto a color azul claro.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ColorMagenta(string sentence) //Función para cambiar el texto a color magenta.
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            SlowWrite2(sentence);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public int OptionCorrect(int num1, int num2, int option) //Función cuando pedimos un número por teclado y nos queremos asegurar de que está dentro del rango establecido
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
        public int RandomEnemy(int min, int max) //Generar un Pokémon random aleatorio.
        {
            Random r=new Random();
            int randomnum = r.Next(min, max);
            return randomnum;
        }
    }
}
