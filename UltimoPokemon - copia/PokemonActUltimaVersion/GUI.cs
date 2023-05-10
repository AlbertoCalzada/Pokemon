using Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.Threading;
using WpfApp2;
using System.Windows.Media;

namespace PokemonAct
{
    internal class GUI : IO
    {
        private MainWindow window;
        private Brush actualcolor;

        public GUI()
        {
            window = new MainWindow();
            actualcolor = Brushes.Black;
            window.TextBlock.Foreground = actualcolor;
        }

        public Brush Actualcolor { get => actualcolor; set => actualcolor = value; }

        public override int AskNumber()
        {
            throw new NotImplementedException();
        }

        public override void ColorBlue(string sentence)
        {
            Run run = new Run(sentence + "\n");
            run.Foreground = Brushes.Blue;

            window.TextBlock.Inlines.Add(run);

            //window.TextBlock.Text += sentence + "\n";
        }

        public override void ColorGreen(string sentence)
        {
            //Run run = new Run(sentence + "\n");
            //run.Foreground = Brushes.Green;
            window.TextBlock.Text += sentence + "\n";
            //window.TextBlock.Inlines.Add(run);
        }

        public override void ColorMagenta(string sentence)
        {
            //Run run = new Run(sentence + "\n");
            window.TextBlock.Text += sentence + "\n";
            //run.Foreground = Brushes.Magenta;
            //window.TextBlock.Inlines.Add(run);
        }

        public override void ColorRed(string sentence)
        {
            //Run run = new Run(sentence + "\n");
            window.TextBlock.Text += sentence + "\n";
            //run.Foreground = Brushes.Red;
            //window.TextBlock.Inlines.Add(run);
        }

        public override void ColorYellow(string sentence)
        {
            //Run run = new Run(sentence + "\n");
            //run.Foreground = Brushes.GreenYellow;
            window.TextBlock.Text += sentence + "\n";
            //window.TextBlock.Inlines.Add(run);
        }

        public override void ColorCyan(string sentence)
        {
            //Run run = new Run(sentence + "\n");
            //run.Foreground = Brushes.Cyan;
            //window.TextBlock.Inlines.Add(run);
            window.TextBlock.Text += sentence + "\n";
        }

        public override void SlowWrite(string sentence)
        {
            window.TextBlock.Text += sentence + "\n";
        }

        public override void SlowWrite2(string sentence)
        {
            window.TextBlock.Text += sentence + "\n";
        }


        public override int OptionCorrect(int num1, int num2, int option)
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

        public override string ReadLine()
        {
            window.ShowDialog();
            string text = window.TextBox.Text; 
            Console.WriteLine(text);
            window = new MainWindow();
            return text;
        }

        

        public override void SlowWriteWithOutSpace(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void Space()
        {
            window.TextBlock.Text += "\n";
        }
    }
}
