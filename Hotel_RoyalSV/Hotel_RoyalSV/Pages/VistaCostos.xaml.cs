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

namespace Hotel_RoyalSV.Pages
{
    /// <summary>
    /// Lógica de interacción para VistaCostos.xaml
    /// </summary>
    public partial class VistaCostos : Page
    {
        #region Variables
        private static VistaCostos _Instancia = new VistaCostos();
        #endregion

        #region Metodos Externos
        public static VistaCostos GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new VistaCostos();
            }
            return _Instancia;
        }

        public DataTable Tabla()
        {
            DataTable DAT = new DataTable();
            try
            {
                //DAT = N_Costos.Ver();
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

        public VistaCostos()
        {
            InitializeComponent();
            Tabla();
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Back_Click_1(object sender, RoutedEventArgs e)
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
                    //Datos = N_Costos.Buscar_DUI(TXT_Dui.Text);
                    DT_View.ItemsSource = Datos.DefaultView;
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
            }
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
                    //Datos = N_Costos.Buscar_DUI(TXT_Dui.Text);
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

        }

        private void DT_View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = DT_View.SelectedItem as DataRowView;
            System.Windows.Clipboard.SetText(row.Row.ItemArray[0].ToString());
        }
    }
}