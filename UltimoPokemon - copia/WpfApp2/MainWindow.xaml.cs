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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            
            InitializeComponent();
        }

        /*public void NextButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            FastStart fastStartWindow = new FastStart();
            fastStartWindow.Show();
            Close();
        }*/

        public void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Crear una instancia de la ventana FastStart, pasando la instancia actual de MainWindow
            FastStart fastStartWindow = new FastStart(this);
            // Mostrar la ventana FastStart y cerrar la ventana actual (MainWindow)
            fastStartWindow.Show();
            Close();

            fastStartWindow.Activate();
        }


        public TextBlock TextBlock
        {
            get { return textBlock; }            
        }

        public TextBox TextBox
        {
            get { return textBox; }            
        }
       
    }
}
