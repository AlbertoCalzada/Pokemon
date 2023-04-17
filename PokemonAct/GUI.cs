using Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAct
{
    internal class GUI:IO
    {
        WpfApp1.App app;
        WpfApp1.MainWindow win;


        public GUI()
        {
            app = new WpfApp1.App();
            win = new WpfApp1.MainWindow();
            app.MainWindow = win;
        }

        public void Run()
        {
            app.InitializeComponent();
            app.Run();
        }

        public override int AskNumber()
        {
            throw new NotImplementedException();
        }

        public override void ColorBlue(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void ColorCyan(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void ColorGreen(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void ColorMagenta(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void ColorRed(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void ColorYellow(string sentence)
        {
            throw new NotImplementedException();
        }

        public override int OptionCorrect(int num1, int num2, int option)
        {
            throw new NotImplementedException();
        }

        public override int RandomEnemy(int min, int max)
        {
            throw new NotImplementedException();
        }

        public override string ReadLine()
        {
            throw new NotImplementedException();
        }

        public override void SlowWrite(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void SlowWrite2(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void SlowWriteWithOutSpace(string sentence)
        {
            throw new NotImplementedException();
        }

        public override void Space()
        {
            throw new NotImplementedException();
        }
    }
}
