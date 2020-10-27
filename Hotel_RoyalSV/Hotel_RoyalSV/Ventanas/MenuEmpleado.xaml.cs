using Hotel_RoyalSV.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Hotel_RoyalSV
{
    /// <summary>
    /// Lógica de interacción para MenuEmpleado.xaml
    /// </summary>
    public partial class MenuEmpleado : Window
    {
        Mantenimiento mantenimiento = Mantenimiento.GetInstancia();
        public void PanelMantenimiento(string title, string url)
        {
            mantenimiento.LBL_Title.Content = title;
            mantenimiento.FR_Content.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
            mantenimiento.WindowState = WindowState.Normal;
            mantenimiento.Show();
        }
        public MenuEmpleado()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BTN_Out_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resul = MessageBox.Show("Seguro que desea salir?", "Saliendo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resul == MessageBoxResult.Yes)
            {
                MainWindow loing = new MainWindow();
                loing.Show();
                this.Hide();
            }            
        }

        private void BTN_Reservas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Empleados_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimiento("Empleado", "Pages/Empleado.xaml");
        }

        private void BTN_Costos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Habitaciones_Click(object sender, RoutedEventArgs e)
        {
            PanelMantenimiento("Habitaciones", "Pages/Habitacion.xaml");
        }
    }
}
