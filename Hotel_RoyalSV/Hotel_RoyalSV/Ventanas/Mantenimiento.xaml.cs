using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Hotel_RoyalSV.Ventanas
{
    /// <summary>
    /// Lógica de interacción para Mantenimiento.xaml
    /// </summary>
    public partial class Mantenimiento : Window
    {
        private static Mantenimiento _Instancia = new Mantenimiento();


        public static Mantenimiento GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Mantenimiento();
            }

            return _Instancia;
        }

        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Mantenimiento1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
