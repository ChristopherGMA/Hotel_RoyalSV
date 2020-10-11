using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Empleado
    {
        //Defnicion de variables
        private int _ID_Empleado;
        private string _Nombre;
        private string _Apellido;
        private int _Edad;
        private string _Correo;
        private string _Telefono;
        private string _Celular;
        private string _DUI;
        private string _NIT;
        private string _ISSS;
        private string _Usuario;
        private string _Contraseña;
        private string _Puesto;
        private string _Departamento;

        //Encapsulamiento
        public int ID_Empleado { get => _ID_Empleado; set => _ID_Empleado = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public int Edad { get => _Edad; set => _Edad = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Celular { get => _Celular; set => _Celular = value; }
        public string DUI { get => _DUI; set => _DUI = value; }
        public string NIT { get => _NIT; set => _NIT = value; }
        public string ISSS { get => _ISSS; set => _ISSS = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public string Puesto { get => _Puesto; set => _Puesto = value; }
        public string Departamento { get => _Departamento; set => _Departamento = value; }

        //Metodos

        public D_Empleado() { }


        public D_Empleado(int id_empleado, string nombre, string apellido, int edad, string correo, string telefono, string celular, string dui, string nit, string isss,
                            string usuario, string contraseña, string puesto, string departamento)
        {
            this.ID_Empleado = id_empleado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Correo = correo;
            this.Telefono = telefono;
            this.Celular = celular;
            this.DUI = dui;
            this.NIT = nit;
            this.ISSS = isss;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.Puesto = puesto;
            this.Departamento = departamento;
        }

        //Insertar
        public string Insertar(D_Empleado empleado)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Insertar_Empleado";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDEmpleado = new SqlParameter();
                    ParIDEmpleado.ParameterName = "@IDEmpleado";
                    ParIDEmpleado.SqlDbType = SqlDbType.Int;
                    ParIDEmpleado.Value = empleado.ID_Empleado;
                    cmd.Parameters.Add(ParIDEmpleado);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@Nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 250;
                    ParNombre.Value = empleado.Nombre;
                    cmd.Parameters.Add(ParNombre);

                    SqlParameter ParApellido = new SqlParameter();
                    ParApellido.ParameterName = "@Apellido";
                    ParApellido.SqlDbType = SqlDbType.VarChar;
                    ParApellido.Size = 250;
                    ParApellido.Value = empleado.Apellido;
                    cmd.Parameters.Add(ParNombre);

                    SqlParameter ParEdad = new SqlParameter();
                    ParEdad.ParameterName = "@Edad";
                    ParEdad.SqlDbType = SqlDbType.Int;
                    ParEdad.Value = empleado.Edad;
                    cmd.Parameters.Add(ParEdad);

                    SqlParameter ParCorreo = new SqlParameter();
                    ParCorreo.ParameterName = "@Correo";
                    ParCorreo.SqlDbType = SqlDbType.VarChar;
                    ParCorreo.Size = 100;
                    ParCorreo.Value = empleado.Correo;
                    cmd.Parameters.Add(ParCorreo);

                    SqlParameter ParTelefono = new SqlParameter();
                    ParTelefono.ParameterName = "@Telefono";
                    ParTelefono.SqlDbType = SqlDbType.VarChar;
                    ParTelefono.Size = 50;
                    ParTelefono.Value = empleado.Telefono;
                    cmd.Parameters.Add(ParTelefono);

                    SqlParameter ParCelular = new SqlParameter();
                    ParCelular.ParameterName = "@Celular";
                    ParCelular.SqlDbType = SqlDbType.VarChar;
                    ParCelular.Size = 50;
                    ParCelular.Value = empleado.Celular;
                    cmd.Parameters.Add(ParCelular);

                    SqlParameter ParDUI = new SqlParameter();
                    ParDUI.ParameterName = "@DUI";
                    ParDUI.SqlDbType = SqlDbType.VarChar;
                    ParDUI.Size = 10;
                    ParDUI.Value = empleado.DUI;
                    cmd.Parameters.Add(ParDUI);

                    SqlParameter ParNIT = new SqlParameter();
                    ParNIT.ParameterName = "@NIT";
                    ParNIT.SqlDbType = SqlDbType.VarChar;
                    ParNIT.Size = 10;
                    ParNIT.Value = empleado.NIT;
                    cmd.Parameters.Add(ParNIT);

                    SqlParameter ParISSS = new SqlParameter();
                    ParISSS.ParameterName = "@ISSS";
                    ParISSS.SqlDbType = SqlDbType.VarChar;
                    ParISSS.Size = 50;
                    ParISSS.Value = empleado.ISSS;
                    cmd.Parameters.Add(ParISSS);

                    SqlParameter ParUsuario = new SqlParameter();
                    ParUsuario.ParameterName = "@Usuario";
                    ParUsuario.SqlDbType = SqlDbType.VarChar;
                    ParUsuario.Size = 50;
                    ParUsuario.Value = empleado.Usuario;
                    cmd.Parameters.Add(ParUsuario);

                    SqlParameter ParContraseña = new SqlParameter();
                    ParContraseña.ParameterName = "@Contraseña";
                    ParContraseña.SqlDbType = SqlDbType.VarChar;
                    ParContraseña.Size = 50;
                    ParContraseña.Value = empleado.Contraseña;
                    cmd.Parameters.Add(ParContraseña);

                    SqlParameter ParPuesto = new SqlParameter();
                    ParPuesto.ParameterName = "@Puesto";
                    ParPuesto.SqlDbType = SqlDbType.VarChar;
                    ParPuesto.Size = 30;
                    ParPuesto.Value = empleado.Puesto;
                    cmd.Parameters.Add(ParPuesto);

                    SqlParameter ParDepartamento = new SqlParameter();
                    ParDepartamento.ParameterName = "@Departamento";
                    ParDepartamento.SqlDbType = SqlDbType.VarChar;
                    ParDepartamento.Size = 30;
                    ParDepartamento.Value = empleado.Departamento;
                    cmd.Parameters.Add(ParDepartamento);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }
        //Editar
        public string Editar(D_Empleado empleado)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Editar_Empleado";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDEmpleado = new SqlParameter();
                    ParIDEmpleado.ParameterName = "@IDEmpleado";
                    ParIDEmpleado.SqlDbType = SqlDbType.Int;
                    ParIDEmpleado.Value = empleado.ID_Empleado;
                    cmd.Parameters.Add(ParIDEmpleado);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@Nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 250;
                    ParNombre.Value = empleado.Nombre;
                    cmd.Parameters.Add(ParNombre);

                    SqlParameter ParApellido = new SqlParameter();
                    ParApellido.ParameterName = "@Apellido";
                    ParApellido.SqlDbType = SqlDbType.VarChar;
                    ParApellido.Size = 250;
                    ParApellido.Value = empleado.Apellido;
                    cmd.Parameters.Add(ParNombre);

                    SqlParameter ParEdad = new SqlParameter();
                    ParEdad.ParameterName = "@Edad";
                    ParEdad.SqlDbType = SqlDbType.Int;
                    ParEdad.Value = empleado.Edad;
                    cmd.Parameters.Add(ParEdad);

                    SqlParameter ParCorreo = new SqlParameter();
                    ParCorreo.ParameterName = "@Correo";
                    ParCorreo.SqlDbType = SqlDbType.VarChar;
                    ParCorreo.Size = 100;
                    ParCorreo.Value = empleado.Correo;
                    cmd.Parameters.Add(ParCorreo);

                    SqlParameter ParTelefono = new SqlParameter();
                    ParTelefono.ParameterName = "@Telefono";
                    ParTelefono.SqlDbType = SqlDbType.VarChar;
                    ParTelefono.Size = 50;
                    ParTelefono.Value = empleado.Telefono;
                    cmd.Parameters.Add(ParTelefono);

                    SqlParameter ParCelular = new SqlParameter();
                    ParCelular.ParameterName = "@Celular";
                    ParCelular.SqlDbType = SqlDbType.VarChar;
                    ParCelular.Size = 50;
                    ParCelular.Value = empleado.Celular;
                    cmd.Parameters.Add(ParCelular);

                    SqlParameter ParDUI = new SqlParameter();
                    ParDUI.ParameterName = "@DUI";
                    ParDUI.SqlDbType = SqlDbType.VarChar;
                    ParDUI.Size = 10;
                    ParDUI.Value = empleado.DUI;
                    cmd.Parameters.Add(ParDUI);

                    SqlParameter ParNIT = new SqlParameter();
                    ParNIT.ParameterName = "@NIT";
                    ParNIT.SqlDbType = SqlDbType.VarChar;
                    ParNIT.Size = 10;
                    ParNIT.Value = empleado.NIT;
                    cmd.Parameters.Add(ParNIT);

                    SqlParameter ParISSS = new SqlParameter();
                    ParISSS.ParameterName = "@ISSS";
                    ParISSS.SqlDbType = SqlDbType.VarChar;
                    ParISSS.Size = 50;
                    ParISSS.Value = empleado.ISSS;
                    cmd.Parameters.Add(ParISSS);

                    SqlParameter ParUsuario = new SqlParameter();
                    ParUsuario.ParameterName = "@Usuario";
                    ParUsuario.SqlDbType = SqlDbType.VarChar;
                    ParUsuario.Size = 50;
                    ParUsuario.Value = empleado.Usuario;
                    cmd.Parameters.Add(ParUsuario);

                    SqlParameter ParContraseña = new SqlParameter();
                    ParContraseña.ParameterName = "@Contraseña";
                    ParContraseña.SqlDbType = SqlDbType.VarChar;
                    ParContraseña.Size = 50;
                    ParContraseña.Value = empleado.Contraseña;
                    cmd.Parameters.Add(ParContraseña);

                    SqlParameter ParPuesto = new SqlParameter();
                    ParPuesto.ParameterName = "@Puesto";
                    ParPuesto.SqlDbType = SqlDbType.VarChar;
                    ParPuesto.Size = 30;
                    ParPuesto.Value = empleado.Puesto;
                    cmd.Parameters.Add(ParPuesto);

                    SqlParameter ParDepartamento = new SqlParameter();
                    ParDepartamento.ParameterName = "@Departamento";
                    ParDepartamento.SqlDbType = SqlDbType.VarChar;
                    ParDepartamento.Size = 30;
                    ParDepartamento.Value = empleado.Departamento;
                    cmd.Parameters.Add(ParDepartamento);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }

        //Eliminar
        public string Eliminar(D_Empleado empleado)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Eliminar_Empleado";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDEmpleado = new SqlParameter();
                    ParIDEmpleado.ParameterName = "@IDEmpleado";
                    ParIDEmpleado.SqlDbType = SqlDbType.Int;
                    ParIDEmpleado.Value = empleado.ID_Empleado;
                    cmd.Parameters.Add(ParIDEmpleado);                    

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }

        //Anular
        public string Anular(D_Empleado empleado)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_anular_empleado";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDEmpleado = new SqlParameter();
                    ParIDEmpleado.ParameterName = "@IDEmpleado";
                    ParIDEmpleado.SqlDbType = SqlDbType.Int;
                    ParIDEmpleado.Value = empleado.ID_Empleado;
                    cmd.Parameters.Add(ParIDEmpleado);

                    SqlParameter ParPuesto = new SqlParameter();
                    ParPuesto.ParameterName = "@Puesto";
                    ParPuesto.SqlDbType = SqlDbType.VarChar;
                    ParPuesto.Size = 30;
                    ParPuesto.Value = empleado.Puesto;
                    cmd.Parameters.Add(ParPuesto);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }

        //Bucar por DUI
        public DataTable Buscar_DUI(D_Empleado empleado)
        {
            DataTable DAT = new DataTable("Empleado");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "Buscar_Dui_Empleado";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParDUI = new SqlParameter();
                    ParDUI.ParameterName = "@DUI";
                    ParDUI.SqlDbType = SqlDbType.VarChar;
                    ParDUI.Size = 10;
                    ParDUI.Value = empleado.DUI;
                    cmd.Parameters.Add(ParDUI);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(DAT);
                }
                catch (Exception)
                {
                    DAT = null;
                }

                return DAT;
            }
        }

        //Loing
        public DataTable Loing(D_Empleado empleado)
        {
            DataTable DAT = new DataTable("EMPLEADO");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Login_Empleado";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParUsuario = new SqlParameter();
                    ParUsuario.ParameterName = "@Usuario";
                    ParUsuario.SqlDbType = SqlDbType.VarChar;
                    ParUsuario.Size = 50;
                    ParUsuario.Value = empleado.Usuario;
                    cmd.Parameters.Add(ParUsuario);

                    SqlParameter ParContraseña = new SqlParameter();
                    ParContraseña.ParameterName = "@Contrasena";
                    ParContraseña.SqlDbType = SqlDbType.VarChar;
                    ParContraseña.Size = 50;
                    ParContraseña.Value = empleado.Contraseña;
                    cmd.Parameters.Add(ParContraseña);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(DAT);
                }
                catch (Exception)
                {
                    DAT = null;
                }

                return DAT;
            }
        }
    }    
}
