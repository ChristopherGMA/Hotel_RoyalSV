using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Hotel_RoyalSV.Ventanas
{
    /// <summary>
    /// Lógica de interacción para ManejarVistas.xaml
    /// </summary>
    public partial class ManejarVistas : Window
    {
        private static ManejarVistas _Instancia = new ManejarVistas();        


        public static ManejarVistas GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ManejarVistas();
            }
            return _Instancia;
        }

        public ManejarVistas()
        {
            InitializeComponent();
        }

        private void GenrarVista_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
