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
using System.Data;
using Capa_Negocio;
using Hotel_RoyalSV.Ventanas;

namespace Hotel_RoyalSV.Pages
{
    /// <summary>
    /// Lógica de interacción para VistaHabitaciones.xaml
    /// </summary>
    public partial class VistaHabitaciones : Page
    {
        #region Variables
        private static VistaHabitaciones _Instancia = new VistaHabitaciones();
        #endregion

        #region Metodos Externos
        public static VistaHabitaciones GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new VistaHabitaciones();
            }
            return _Instancia;
        }

        public DataTable Tabla()
        {
            DataTable DAT = new DataTable();
            try
            {
                DAT = N_Habitaciones.Buscar_Estado("Activo");
                DT_View.ItemsSource = DAT.DefaultView;
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
                DAT = null;
            }
            return DAT;
        }

        public void RecargarTabla(string estado)
        {
            try
            {
                DataTable DAT = N_Habitaciones.Buscar_Estado(estado);
                DT_View.ItemsSource = DAT.DefaultView;
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message);
            }
        }

        #endregion


        public VistaHabitaciones()
        {
            InitializeComponent();
            Tabla();
        }

        private void DT_View_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void DT_View_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ManejarVistas manejarVistas = ManejarVistas.GetInstancia();
            manejarVistas.Hide();
        }

        private void DT_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = DT_View.SelectedItem as DataRowView;
            System.Windows.Clipboard.SetText(row.Row.ItemArray[0].ToString());
        }

        private void Page_Initialized(object sender, EventArgs e)
        {

        }

        private void BTN_Activo_Click(object sender, RoutedEventArgs e)
        {
            RecargarTabla("Activo");
        }

        private void BTN_Inactivo_Click(object sender, RoutedEventArgs e)
        {
            RecargarTabla("Inactivo");
        }

        private void BTN_Mantenimiento_Click(object sender, RoutedEventArgs e)
        {
            RecargarTabla("Mantenimiento");
        }

        private void BTN_Ocupado_Click(object sender, RoutedEventArgs e)
        {
            RecargarTabla("Ocupado");
        }
    }
}
