using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Capa_Negocio;
using Hotel_RoyalSV.Ventanas;

namespace Hotel_RoyalSV.Pages
{
    /// <summary>
    /// Lógica de interacción para VistaEmplado.xaml
    /// </summary>
    public partial class VistaEmplado : Page
    {
        #region Variables
        private static VistaEmplado _Instancia = new VistaEmplado();
        #endregion

        #region Metodos Externos
        public static VistaEmplado GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new VistaEmplado();
            }
            return _Instancia;
        }

        public DataTable Tabla()
        {
            DataTable DAT = new DataTable();
            try
            {
                DAT = N_Empleado.Ver();
                DT_View.ItemsSource = DAT.DefaultView;
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
                DAT = null;                
            }
            return DAT;
        }
        #endregion


        public VistaEmplado()
        {
            InitializeComponent();
            Tabla();
        }

        private void DT_View_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void TXT_Dui_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TXT_Dui.Text == "")
                {
                    Tabla();
                }
                else
                {
                    DataTable Datos = new DataTable();
                    Datos = N_Empleado.Buscar_DUI(TXT_Dui.Text);
                    DT_View.ItemsSource = Datos.DefaultView;
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
            }
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
    }
}
