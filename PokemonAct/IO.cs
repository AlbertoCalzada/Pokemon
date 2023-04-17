using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pokemon
{
    abstract class  IO
    {
        public abstract void SlowWrite(string sentence); //Función para escribir letra a letra en color blanco todo.
        public abstract void SlowWrite2(string sentence);//Función para escribir letra a letra en las opciones cambiadas al color mostrado posteriormente.

        public abstract void SlowWriteWithOutSpace(string sentence); //Función para escribir letra a letra en las opciones cambiadas al color mostrado posteriormente.
        public abstract string ReadLine(); //Función para  un string como valor a introducir por el usuario.

        public abstract int AskNumber(); //Función para un int  como valor a introducir por el usuario.

        public abstract void Space(); //Función para espacio en blanco entre frases o menús determinados del juego.

        public abstract void ColorBlue(string sentence);//Función para cambiar el texto a color azul.
        public abstract void ColorGreen(string sentence);//Función para cambiar el texto a color verde.
        public abstract void ColorRed(string sentence); //Función para cambiar el texto a color rojo.
        public abstract void ColorYellow(string sentence); //Función para cambiar el texto a color amarillo.
        public abstract void ColorCyan(string sentence); //Función para cambiar el texto a color azul claro.
        public abstract void ColorMagenta(string sentence); //Función para cambiar el texto a color magenta.
        public abstract int OptionCorrect(int num1, int num2, int option); //Función cuando pedimos un número por teclado y nos queremos asegurar de que está dentro del rango establecido
        public abstract int RandomEnemy(int min, int max); //Generar un Pokémon random aleatorio. mover a game
    }
}
