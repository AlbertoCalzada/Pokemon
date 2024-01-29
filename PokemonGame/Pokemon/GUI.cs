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

namespace PokemonAct
{
    internal class GUI:IO
    {
       WpfApp2.App app;
       WpfApp2.MainWindow win;
       TextBlock textBlock;
       Button nextButton;
       StackPanel stackPanel;
       TextBox textBox;

        public GUI()
        {
            app = new WpfApp2.App();
            win = new WpfApp2.MainWindow();
            textBlock = new TextBlock();
            nextButton = new Button();
            stackPanel = new StackPanel();
            textBox = new TextBox();
            textBox.Visibility = Visibility.Collapsed; // Oculta el TextBox hasta que se necesite

            nextButton.Content = "Siguiente";
            nextButton.Margin = new Thickness(0, 10, 0, 0); // Margen para separar del TextBlock

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(nextButton);
            stackPanel.Children.Add(textBox); // Agrega el TextBox al StackPanel

            win.Content = stackPanel;
            app.MainWindow = win;
        }

        public void Run()
        {
            app.InitializeComponent();
            app.Run();
        }

        public override int AskNumber()
        {
            textBox.Visibility = Visibility.Visible; // Hace visible el TextBox
            textBox.Text = ""; // Limpia el contenido anterior
            nextButton.Visibility = Visibility.Visible; // Hace visible el botón "Siguiente"

            while (true)
            {
                if (int.TryParse(textBox.Text, out int number))
                {
                    textBox.Visibility = Visibility.Collapsed; // Oculta el TextBox
                    nextButton.Visibility = Visibility.Collapsed; // Oculta el botón "Siguiente"
                    return number;
                }

                // Espera a que el usuario presione el botón "Siguiente"
                nextButton.Click += (sender, e) =>
                {
                    nextButton.Visibility = Visibility.Collapsed;
                };
                Thread.Sleep(100);
            }
        }

        public override void ColorBlue(string sentence)
        {
            textBlock.Inlines.Add(new Run(sentence) { Foreground = System.Windows.Media.Brushes.Blue });
        }

        public override void ColorCyan(string sentence)
        {
            textBlock.Inlines.Add(new Run(sentence) { Foreground = System.Windows.Media.Brushes.Cyan });
        }

        public override void ColorGreen(string sentence)
        {
            textBlock.Inlines.Add(new Run(sentence) { Foreground = System.Windows.Media.Brushes.Green });
        }

        public override void ColorMagenta(string sentence)
        {
            textBlock.Inlines.Add(new Run(sentence) { Foreground = System.Windows.Media.Brushes.Magenta });
        }

        public override void ColorRed(string sentence)
        {
            textBlock.Inlines.Add(new Run(sentence) { Foreground = System.Windows.Media.Brushes.Red });
        }

        public override void ColorYellow(string sentence)
        {
            textBlock.Inlines.Add(new Run(sentence) { Foreground = System.Windows.Media.Brushes.Yellow });
        }

        public override int OptionCorrect(int num1, int num2, int option)
        {
            textBox.Visibility = Visibility.Visible;
            textBox.Text = "";
            nextButton.Visibility = Visibility.Visible;

            while (true)
            {
                string input = textBox.Text;
                if (Int32.TryParse(input, out int value) && value >= num1 && value <= num2)
                {
                    textBox.Visibility = Visibility.Collapsed;
                    nextButton.Visibility = Visibility.Collapsed;
                    return value;
                }
                else
                {
                    Space();
                    SlowWrite("Por favor ingresa un número del " + num1 + " al " + num2 + " . ");
                    textBox.Text = "";
                }
            }
        }


        

        public override string ReadLine()
        {
            textBox.Visibility = Visibility.Visible; // Hace visible el TextBox
            textBox.Text = ""; // Limpia el contenido anterior
            nextButton.Visibility = Visibility.Visible; // Hace visible el botón "Siguiente"

            while (true)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text)) // Verifica que se haya ingresado un valor
                {
                    textBox.Visibility = Visibility.Collapsed; // Oculta el TextBox
                    nextButton.Visibility = Visibility.Collapsed; // Oculta el botón "Siguiente"
                    return textBox.Text; // Retorna el valor ingresado en el TextBox
                }
            }
        }


        public override void SlowWrite(string sentence)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                textBlock.Inlines.Add(new Run(sentence[i].ToString()));
                Thread.Sleep(20);
            }
        }


        public override void SlowWrite2(string sentence)
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                textBox.AppendText(sentence[i].ToString());
                Thread.Sleep(20);
            }
            textBox.AppendText(Environment.NewLine);
        }


        public override void SlowWriteWithOutSpace(string sentence)
        {
            for (int i = 0; i < sentence.Length; ++i)
            {
                textBox.AppendText(sentence[i].ToString());
                Thread.Sleep(0);
            }
        }


        public override void Space() //Función para espacio en blanco entre frases o menús determinados del juego.
        {
            // Insertar un espacio en blanco en la GUI
            textBox.Text = "Espacio en blanco presente";
        }

    }
}
