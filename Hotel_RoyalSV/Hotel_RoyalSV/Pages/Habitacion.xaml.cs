using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel_RoyalSV.Pages
{
    /// <summary>
    /// Lógica de interacción para Habitacion.xaml
    /// </summary>
    public partial class Habitacion : Page
    {
        Ventanas.ManejarVistas vistas = Ventanas.ManejarVistas.GetInstancia();

        public void MostrarVista(string title, string url)
        {
            vistas.LBL_Title.Content = title;
            vistas.FR_Content.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
            vistas.Show();
        }

        private void Limpiar()
        {
            foreach (System.Windows.Controls.TextBox nuevoObjeto in GR_Content.Children.OfType<System.Windows.Controls.TextBox>())
            {
                nuevoObjeto.Clear();
            }
        }

        public Habitacion()
        {
            InitializeComponent();
        }

        private void TXT_ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TXT_ID_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void TXT_Nombre_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void BTN_Editar_Click(object sender, RoutedEventArgs e)
        {
            string RPT = "";
            try
            {
                if (TXT_ID.Text=="" || TXT_numero.Text == "" || CBX_Estado.SelectedItem.ToString() == "" || TXT_ID_Cliente.Text == "")
                {
                    Point relativePoint = IMG_Info.PointToScreen(new Point(0d, 0d));
                    TXT_ID.Focus();
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(relativePoint.X), Convert.ToInt32(relativePoint.Y));
                }
                else
                {
                    RPT = N_Habitaciones.Editar(Convert.ToInt32(TXT_ID.Text), 0, Convert.ToInt32(CBX_Costo.Text), Convert.ToInt32(TXT_numero.Text), CBX_Estado.Text);

                    if (RPT.Equals("OK"))
                    {
                        System.Windows.MessageBox.Show("Se edito la habitacion", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show(RPT, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                Limpiar();
                TXT_numero.Focus();
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message, err.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BTN_Anular_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Insertar_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            try
            {
                string RPT = "";
                if (TXT_numero.Text == "" || CBX_Estado.SelectedItem.ToString() == "")
                {
                    System.Windows.MessageBox.Show("Por favor, llene la informacion solicitada", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                    TXT_ID.Focus();
                }
                else
                { 
                    A:
                    int id = random.Next(1, 100000);
                    DataTable exist = N_Random.Random_Exist("HABITACIONES", id);
                    if (exist.Rows.Count >= 1)
                    {
                        goto A;
                    }
                    else
                    {
                        if (TXT_numero.Text == "" || CBX_Estado.SelectedItem.ToString() == "" || CBX_Costo.SelectedItem.ToString() == "")
                        {
                            System.Windows.MessageBox.Show("Por favor, llenar los datos solicitados", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            RPT = N_Habitaciones.Insertar(id, 0, Convert.ToInt32(CBX_Costo.Text), Convert.ToInt32(TXT_numero.Text), Convert.ToString(CBX_Estado.Text));
                        }

                        if (RPT.Equals("OK"))
                        {
                            System.Windows.MessageBox.Show("Se inserto la habitacion", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show(RPT, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        Limpiar();
                        TXT_numero.Focus();
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message, err.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BTN_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult resul = System.Windows.Forms.MessageBox.Show("Desea anular esta habitacion?\nEsta accion se puede editar luego"
                                    , "Hotel Royal S.V", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resul == DialogResult.Yes)
            {
                string RPT = "";
                try
                {
                    if (TXT_ID.Text=="")
                    {
                        Point relativePoint = IMG_Info.PointToScreen(new Point(0d, 0d));
                        TXT_ID.Focus();
                        System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(relativePoint.X), Convert.ToInt32(relativePoint.Y));
                    }
                    else
                    {
                        RPT = N_Habitaciones.Anular(Convert.ToInt32(TXT_ID.Text), "Inactivo");

                        if (RPT.Equals("OK"))
                        {
                            System.Windows.MessageBox.Show("Se deshabilito la habitacion", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show(RPT);
                        }
                    }
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message, err.Source, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BTN_Buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXT_ID.Text=="")
                {
                    Point relativePoint = IMG_Info.PointToScreen(new Point(0d, 0d));
                    TXT_ID.Focus();
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(relativePoint.X), Convert.ToInt32(relativePoint.Y));
                }
                else
                {
                    DataTable DAT = N_Habitaciones.Buscar_ID(Convert.ToInt32(TXT_ID.Text));
                    TXT_numero.Text = DAT.Rows[0][3].ToString();
                    CBX_Estado.Text = DAT.Rows[0][4].ToString();
                    CBX_Costo.Text = DAT.Rows[0][2].ToString();
                    TXT_ID_Cliente.Text = DAT.Rows[0][1].ToString();
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message, err.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BTN_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            CBX_Costo.Text = "";
            CBX_Estado.Text = "";
            TXT_ID.Focus();
        }

        private void BTN_Ver_Click(object sender, RoutedEventArgs e)
        {
            vistas = new Ventanas.ManejarVistas();
            MostrarVista("Habitaciones", "Pages/VistaHabitaciones.xaml");
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            
        }

        private void TXT_ID_Cliente_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void BTN_Vista_Cliente_Click(object sender, RoutedEventArgs e)
        {
            MostrarVista("Cliente", "Pages/VistaCliente.xaml");
        }
    }
}
