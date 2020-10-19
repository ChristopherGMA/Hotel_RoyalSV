using System;
using System.Collections.Generic;
using System.Data;
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
using Capa_Negocio;

namespace Hotel_RoyalSV
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

        private void LBL_Password_Request_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Acept_Click(object sender, RoutedEventArgs e)
        {
            try
            {  
                if (TXT_Usuario.Text=="" || PSW_UserPassword.Password == "")
                {
                    MessageBox.Show("Hacen falta datos, por favor ingrese su informacion", "Atencion!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    DataTable loing = new DataTable();
                    loing = N_Empleado.Loing(TXT_Usuario.Text, PSW_UserPassword.Password);
                    if (loing.Rows.Count == 1)
                    {
                        MenuEmpleado empleado = new MenuEmpleado();
                        empleado.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña erroneos, revise sus datos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\n" + err.StackTrace);
            }
        }

        private void Loing_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
