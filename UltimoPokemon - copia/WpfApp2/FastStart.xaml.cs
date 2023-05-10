using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Lógica de interacción para FastStart.xaml
    /// </summary>
    public partial class FastStart : Window
    {
        /*public FastStart()
        {
            InitializeComponent();
        }*/
        private readonly MainWindow mainWindow;

        public FastStart(MainWindow mainWindow)
        {
            InitializeComponent();          
            this.mainWindow = mainWindow;
        }

       

    }
}
