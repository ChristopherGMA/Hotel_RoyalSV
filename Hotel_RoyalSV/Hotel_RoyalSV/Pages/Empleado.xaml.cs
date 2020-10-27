using Capa_Negocio;
using Hotel_RoyalSV.Ventanas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para Empleado.xaml
    /// </summary>
    public partial class Empleado : Page
    {
        Ventanas.ManejarVistas vistas = Ventanas.ManejarVistas.GetInstancia();
        bool ActualizarTabla;

        private static Empleado _Instancia = new Empleado();
        public string _id;

        public static Empleado GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new Empleado();
            }
            return _Instancia;
        }        

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
       
        public Empleado()
        {
            InitializeComponent();
            BTN_Buscar.IsEnabled = false;            
        }

        private void BTN_Insertar_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            
            try
            {
                if (TXT_Nombre.Text!=""||TXT_Apellido.Text!=""||TXT_Edad.Text!=""||TXT_Correo.Text!=""||TXT_Telefono.Text!="" ||
                    TXT_Celular.Text != "" || TXT_Dui.Text != "" || TXT_Nit.Text != "" || TXT_Isss.Text != "" || TXT_Usuario.Text != "" ||
                    TXT_Contraseña.Text != "" || TXT_Puesto.Text != "" || TXT_Departamento.Text != "")
                {
                    A:
                    int id = random.Next(1, 100000);
                    DataTable datEmpleado = N_Random.Random_Exist("EMPLEADO", id);
                    if (datEmpleado.Rows.Count >= 1)
                    {
                        goto A;
                    }
                    else
                    {
                        string RPT = N_Empleado.Insertar(id, TXT_Nombre.Text, TXT_Apellido.Text, Convert.ToInt32(TXT_Edad.Text), TXT_Correo.Text, TXT_Telefono.Text
                                                         , TXT_Celular.Text, TXT_Dui.Text, TXT_Nit.Text, TXT_Isss.Text, TXT_Usuario.Text, TXT_Contraseña.Text,
                                                         TXT_Puesto.Text, TXT_Departamento.Text);
                        if (RPT.Equals("OK"))
                        {
                            System.Windows.MessageBox.Show("Se inserto correctamente el empleado", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show(RPT, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }                    
                }
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
            }
        }

        private void TXT_Nombre_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Control_Errores.SoloLetras(sender, e);
        }

        private void TXT_Apellido_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Control_Errores.SoloLetras(sender, e);
        }

        private void TXT_Edad_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Control_Errores.SoloNumeros(sender, e);
        }

        private void TXT_Correo_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Telefono_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Celular_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Dui_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Nit_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Isss_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Usuario_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Contraseña_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void TXT_Puesto_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Control_Errores.SoloLetras(sender, e);
        }

        private void TXT_Departamento_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Control_Errores.SoloLetras(sender, e);
        }

        private void BTN_Ver_Click(object sender, RoutedEventArgs e)
        {
            if (ActualizarTabla)
            {
                vistas = new ManejarVistas();
                ActualizarTabla = false;
            }          
            MostrarVista("Empleado", "Pages/VistaEmplado.xaml");            
        }        

        private void BTN_Buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable Datos = new DataTable();
                Datos = N_Empleado.BuscarID(Convert.ToInt32(TXT_ID.Text));
                TXT_Nombre.Text = Datos.Rows[0][1].ToString();
                TXT_Apellido.Text = Datos.Rows[0][2].ToString();
                TXT_Edad.Text = Datos.Rows[0][3].ToString();
                TXT_Correo.Text = Datos.Rows[0][4].ToString();
                TXT_Telefono.Text = Datos.Rows[0][5].ToString();
                TXT_Celular.Text = Datos.Rows[0][6].ToString();
                TXT_Dui.Text = Datos.Rows[0][7].ToString();
                TXT_Nit.Text = Datos.Rows[0][8].ToString();
                TXT_Isss.Text = Datos.Rows[0][9].ToString();
                TXT_Usuario.Text = Datos.Rows[0][10].ToString();
                TXT_Contraseña.Text = Datos.Rows[0][11].ToString();
                TXT_Puesto.Text = Datos.Rows[0][12].ToString();
                TXT_Departamento.Text = Datos.Rows[0][13].ToString();
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BTN_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            TXT_ID.Focus();
        }

        private void TXT_ID_TextChanged(object sender, TextChangedEventArgs e)
        {            
            if (TXT_ID.Text == "")
            {
                BTN_Buscar.IsEnabled = false;
            }
            else
            {
                BTN_Buscar.IsEnabled = true;
            }

        }

        private void BTN_Editar_Click(object sender, RoutedEventArgs e)
        {
            if (TXT_ID.Text=="")
            {
                Point relativePoint = IMG_Info.PointToScreen(new Point(0d, 0d));
                TXT_ID.Focus();
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(relativePoint.X), Convert.ToInt32(relativePoint.Y));
            }
            else
            {
                try
                {
                    string RPT = N_Empleado.Editar(Convert.ToInt32(TXT_ID.Text), TXT_Nombre.Text, TXT_Apellido.Text, Convert.ToInt32(TXT_Edad.Text), TXT_Correo.Text, TXT_Telefono.Text,
                                                    TXT_Celular.Text, TXT_Dui.Text, TXT_Nit.Text, TXT_Isss.Text, TXT_Usuario.Text, TXT_Contraseña.Text, TXT_Puesto.Text,
                                                    TXT_Departamento.Text);
                    if (RPT.Equals("OK"))
                    {
                        System.Windows.MessageBox.Show("Se actualiz el registro.", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show(RPT, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    Limpiar();
                    ActualizarTabla = true;
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message);
                }
            }
        }

        private void BTN_Anular_Click(object sender, RoutedEventArgs e)
        {
            if (TXT_ID.Text=="")
            {                
                Point relativePoint = IMG_Info.PointToScreen(new Point(0d, 0d));
                TXT_ID.Focus();
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(relativePoint.X), Convert.ToInt32(relativePoint.Y));
            }
            else
            {
                try
                {
                    if (TXT_Puesto.Text=="")
                    {
                        BTN_Buscar_Click(null, e);
                    }
                    else
                    {
                        if (TXT_Puesto.Text=="Anulado")
                        {
                            TXT_Puesto.Focus();
                            TXT_Puesto.Select(0, 7);
                        }
                        else
                        {
                            string RPT = N_Empleado.Anular(Convert.ToInt32(TXT_ID.Text), "Anulado");
                            if (RPT.Equals("OK"))
                            {
                                System.Windows.MessageBox.Show("Se anulo el empleado", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                System.Windows.MessageBox.Show(RPT, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            Limpiar();
                            ActualizarTabla = true;
                        }
                    }                    
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message);
                }
            }
        }

        private void BTN_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (TXT_ID.Text=="")
            {
                Point relativePoint = IMG_Info.PointToScreen(new Point(0d, 0d));
                TXT_ID.Focus();
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(Convert.ToInt32(relativePoint.X), Convert.ToInt32(relativePoint.Y));
            }
            else
            {
                try
                {
                    DialogResult resul = System.Windows.Forms.MessageBox.Show("Dese eliminar este empleado?\nLos cambios no se podran deshacer", "Hotel Royal S.V", (MessageBoxButtons)MessageBoxButton.YesNo, (MessageBoxIcon)MessageBoxImage.Warning);
                    if (resul == DialogResult.Yes)
                    {
                        string RPT = N_Empleado.Eliminar(Convert.ToInt32(TXT_ID.Text));
                        if (RPT.Equals("OK"))
                        {
                            System.Windows.MessageBox.Show("Se elimino el empleado", "Hotel Royal S.V", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show(RPT, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        Limpiar();
                        ActualizarTabla = true;
                    }                    
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message);
                }
            }
        }

        private void TXT_ID_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <=Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
