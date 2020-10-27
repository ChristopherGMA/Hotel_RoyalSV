using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    class D_Cliente
    {
        private int _ID_Cliente;
        private int _ID_Empleado;
        private String _Nombres;
        private String _Apellidos;
        private String _Correo;
        private int _Edad;
        private String _Telefono;
        private String _Pais;
        private String _Estado_Departamento;
        private String _Direccion;
        private String _Pasaporte;
        private String _DUI;

          //Encapsulamiento//
        public int ID_Cliente { get => _ID_Cliente; set => _ID_Cliente = value; }
        public int ID_Empleado { get => _ID_Empleado; set => _ID_Empleado = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public int Edad { get => _Edad; set => _Edad = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public string Estado_Departamento { get => _Estado_Departamento; set => _Estado_Departamento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Pasaporte { get => _Pasaporte; set => _Pasaporte = value; }
        public string DUI { get => _DUI; set => _DUI = value; }

        public D_Cliente() { }
        public D_Cliente(int id_cliente, int id_empleado, String nombres, string apellidos, String correo, int edad, string telefono,
           string pais, string estado_departamento, string direccion, string pasaporte, string dui){ this.ID_Cliente = id_cliente;
        this.ID_Cliente=id_cliente;
            this.ID_Empleado = id_empleado;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Correo = correo;
            this.Edad = edad;
            this.Telefono = telefono;
            this.Pais = pais;
            this.Estado_Departamento = estado_departamento;
            this.Direccion = direccion;
            this.Pasaporte = pasaporte;
            this.DUI = dui;


        }
        
        //Insertar
        public string Insertar(D_Cliente cliente)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Insertar_Cliente";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParID_Cliente = new SqlParameter();
                    ParID_Cliente.ParameterName = "@IDEmpleado";
                    ParID_Cliente.SqlDbType = SqlDbType.Int;
                    ParID_Cliente.Value = cliente.ID_Cliente;
                    cmd.Parameters.Add(ParID_Cliente);


                    SqlParameter ParNombres = new SqlParameter();
                    ParNombres.ParameterName = "@Nombres";
                    ParNombres.SqlDbType = SqlDbType.VarChar;
                    ParNombres.Size = 250;
                    ParNombres.Value = cliente.Nombres;
                    cmd.Parameters.Add(ParNombres);

                    SqlParameter ParApellidos = new SqlParameter();
                    ParApellidos.ParameterName = "@Apellidos";
                    ParApellidos.SqlDbType = SqlDbType.VarChar;
                    ParApellidos.Size = 250;
                    ParApellidos.Value = cliente.Apellidos;
                    cmd.Parameters.Add(ParApellidos);

                    SqlParameter ParCorreo = new SqlParameter();
                    ParCorreo.ParameterName = "@Correo";
                    ParCorreo.SqlDbType = SqlDbType.VarChar;
                    ParCorreo.Size = 100;
                    ParCorreo.Value = cliente.Correo;
                    cmd.Parameters.Add(ParCorreo);

                    SqlParameter ParEdad = new SqlParameter();
                    ParEdad.ParameterName = "@Edad";
                    ParEdad.SqlDbType = SqlDbType.Int;
                    ParEdad.Value = cliente.Edad;
                    cmd.Parameters.Add(ParEdad);

                    SqlParameter ParTelefono = new SqlParameter();
                    ParTelefono.ParameterName = "@Telefono";
                    ParTelefono.SqlDbType = SqlDbType.VarChar;
                    ParTelefono.Size = 50;
                    ParTelefono.Value = cliente.Telefono;
                    cmd.Parameters.Add(ParTelefono);

                    SqlParameter ParPais = new SqlParameter();
                    ParPais.ParameterName = "@Pais";
                    ParPais.SqlDbType = SqlDbType.VarChar;
                    ParPais.Size = 30;
                    ParPais.Value = cliente.Pais;
                    cmd.Parameters.Add(ParPais);

                    SqlParameter ParEstado_Departamento = new SqlParameter();
                    ParEstado_Departamento.ParameterName = "@Estado_Departamento";
                    ParEstado_Departamento.SqlDbType = SqlDbType.VarChar;
                    ParEstado_Departamento.Size = 50;
                    ParEstado_Departamento.Value = cliente.Estado_Departamento;
                    cmd.Parameters.Add(ParEstado_Departamento);

                    SqlParameter ParDireccion = new SqlParameter();
                    ParDireccion.ParameterName = "@Direccion";
                    ParDireccion.SqlDbType = SqlDbType.VarChar;
                    ParDireccion.Size = 100;
                    ParDireccion.Value = cliente.Direccion;
                    cmd.Parameters.Add(ParDireccion);

                    SqlParameter ParPasaporte = new SqlParameter();
                    ParPasaporte.ParameterName = "@Pasaporte";
                    ParPasaporte.SqlDbType = SqlDbType.VarChar;
                    ParPasaporte.Size = 150;
                    ParPasaporte.Value = cliente.Pasaporte;
                    cmd.Parameters.Add(ParPasaporte);

                    SqlParameter ParDUI = new SqlParameter();
                    ParDUI.ParameterName = "@DUI";
                    ParDUI.SqlDbType = SqlDbType.VarChar;
                    ParDUI.Size = 10;
                    ParDUI.Value = cliente.DUI;
                    cmd.Parameters.Add(ParDUI);
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
        public string Editar(D_Cliente cliente)
                    {
                        string RPT = "";
                        using (SqlConnection CON = D_Coneccion.Coneccion())
                        {
                            try
                            {
                                CON.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = CON;
                                cmd.CommandText = "SP_Editar_Cliente";
                                cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter ParIDCliente = new SqlParameter();
                    ParIDCliente.ParameterName = "@IDCliente";
                    ParIDCliente.SqlDbType = SqlDbType.Int;
                    ParIDCliente.Value = cliente.ID_Cliente;
                    cmd.Parameters.Add(ParIDCliente);

                    SqlParameter ParIDEmpleado = new SqlParameter();
                    ParIDEmpleado.ParameterName = "@IDEmpleado";
                    ParIDEmpleado.SqlDbType = SqlDbType.Int;
                    ParIDEmpleado.Value = cliente.ID_Cliente;
                    cmd.Parameters.Add(ParIDCliente);

                    SqlParameter ParNombres = new SqlParameter();
                                ParNombres.ParameterName = "@Nombres";
                                ParNombres.SqlDbType = SqlDbType.VarChar;
                                ParNombres.Size = 250;
                                ParNombres.Value = cliente.Nombres;
                                cmd.Parameters.Add(ParNombres);

                                SqlParameter ParApellidos = new SqlParameter();
                                ParApellidos.ParameterName = "@Apellidos";
                                ParApellidos.SqlDbType = SqlDbType.VarChar;
                                ParApellidos.Size = 250;
                                ParApellidos.Value = cliente.Apellidos;
                                cmd.Parameters.Add(ParApellidos);

                                SqlParameter ParCorreo = new SqlParameter();
                                ParCorreo.ParameterName = "@Correo";
                                ParCorreo.SqlDbType = SqlDbType.VarChar;
                                ParCorreo.Size = 100;
                                ParCorreo.Value = cliente.Correo;
                                cmd.Parameters.Add(ParCorreo);


                                SqlParameter ParEdad = new SqlParameter();
                                ParEdad.ParameterName = "@Edad";
                                ParEdad.SqlDbType = SqlDbType.Int;
                                ParEdad.Value = cliente.Edad;
                                cmd.Parameters.Add(ParEdad);


                                SqlParameter ParTelefono = new SqlParameter();
                                ParTelefono.ParameterName = "@Telefono";
                                ParTelefono.SqlDbType = SqlDbType.VarChar;
                                ParTelefono.Size = 50;
                                ParTelefono.Value = cliente.Telefono;
                                cmd.Parameters.Add(ParTelefono);

                                SqlParameter ParPais = new SqlParameter();
                                ParPais .ParameterName = "@Pais ";
                                ParPais .SqlDbType = SqlDbType.VarChar;
                                ParPais .Size = 50;
                                ParPais .Value = cliente.Pais;
                                cmd.Parameters.Add(ParPais);


                    SqlParameter ParEstado_Departamento = new SqlParameter();
                    ParEstado_Departamento.ParameterName = "@Estado_Departamento";
                    ParEstado_Departamento.SqlDbType = SqlDbType.VarChar;
                    ParEstado_Departamento.Size = 50;
                    ParEstado_Departamento.Value = cliente.Estado_Departamento;
                    cmd.Parameters.Add(ParEstado_Departamento);


                    SqlParameter ParDireccion = new SqlParameter();
                    ParDireccion.ParameterName = "@Direccion";
                    ParDireccion.SqlDbType = SqlDbType.VarChar;
                    ParDireccion.Size = 100;
                    ParDireccion.Value = cliente.Direccion;
                    cmd.Parameters.Add(ParDireccion);

                    SqlParameter ParPasaporte = new SqlParameter();
                    ParPasaporte.ParameterName = "@Pasaporte";
                    ParPasaporte.SqlDbType = SqlDbType.VarChar;
                    ParPasaporte.Size = 150;
                    ParPasaporte.Value = cliente.Pasaporte;
                    cmd.Parameters.Add(ParPasaporte);


                    SqlParameter ParDUI = new SqlParameter();
                                ParDUI.ParameterName = "@DUI";
                                ParDUI.SqlDbType = SqlDbType.VarChar;
                                ParDUI.Size = 10;
                                ParDUI.Value = cliente.DUI;
                                cmd.Parameters.Add(ParDUI);

                                

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
        public string Eliminar(D_Cliente cliente)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Eliminar_Cliente";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDCliente = new SqlParameter();
                    ParIDCliente.ParameterName = "@IDCliente";
                    ParIDCliente.SqlDbType = SqlDbType.Int;
                    ParIDCliente.Value = cliente.ID_Cliente;
                    cmd.Parameters.Add(ParIDCliente);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }
        //Bucar por Nombre//
        public DataTable Buscar_Nombre(D_Cliente cliente)
        {
            DataTable DAT = new DataTable("Nombre");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "Buscar_Por_Nombre";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParNombres = new SqlParameter();
                    ParNombres.ParameterName = "@Nombre";
                    ParNombres.SqlDbType = SqlDbType.VarChar;
                    ParNombres.Size = 10;
                    ParNombres.Value = cliente.Nombres;
                    cmd.Parameters.Add(ParNombres);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(DAT);
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
                    DAT = null;
                }

                return DAT;
            }
        }
        //Bucar por Pasaporte//
        public DataTable Buscar_Pasaporte(D_Cliente cliente)
        {
            DataTable DAT = new DataTable("Pasaporte");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "Buscar_Por_Pasaporte";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParPasaporte = new SqlParameter();
                    ParPasaporte.ParameterName = "@Pasaporte";
                    ParPasaporte.SqlDbType = SqlDbType.VarChar;
                    ParPasaporte.Size = 10;
                    ParPasaporte.Value = cliente.Pasaporte;
                    cmd.Parameters.Add(ParPasaporte);

                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(DAT);
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show(err.Message + "\n" + err.StackTrace);
                    DAT = null;
                }

                return DAT;
            }
        }


    }






}

