using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    class D_Servicios
    {
        //definir variables
        private int _IDServicio;
        private string _Nombre;
        private string _Descripcion;
        private int _Costo;

        public int IDServicio { get => _IDServicio; set => _IDServicio = value; }
        public string Nombre { get => Nombre; set => Nombre = value; }
        public string Descripcion { get => Descripcion; set => Descripcion = value; }
        public int Costo { get => Costo; set => Costo = value; }


        //metodos

        public D_Servicios(int idservicio, string nombre, string descripcion, int costo1)
        {
            this.IDServicio = idservicio;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Costo = costo1;
        }
        //Insertar
        public string Insertar(D_Servicios servicios)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Insertar_Servicios";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDServicios = new SqlParameter();
                    ParIDServicios.ParameterName = "@IDServicio";
                    ParIDServicios.SqlDbType = SqlDbType.Int;
                    ParIDServicios.Value = servicios.IDServicio;
                    cmd.Parameters.Add(ParIDServicios);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@Nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 250;
                    ParNombre.Value = servicios.Nombre;
                    cmd.Parameters.Add(ParNombre);

                    SqlParameter ParDescripcion = new SqlParameter();
                    ParDescripcion.ParameterName = "@Descripcion";
                    ParDescripcion.SqlDbType = SqlDbType.VarChar;
                    ParDescripcion.Size = 250;
                    ParDescripcion.Value = servicios.Descripcion;
                    cmd.Parameters.Add(ParDescripcion);

                    SqlParameter ParCosto = new SqlParameter();
                    ParCosto.ParameterName = "@Costo";
                    ParCosto.SqlDbType = SqlDbType.Int;
                    ParCosto.Value = servicios.Costo;
                    cmd.Parameters.Add(ParCosto);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }


        }
        public string Editar(D_Servicios servicios)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Editar_Servicios";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDServicio = new SqlParameter();
                    ParIDServicio.ParameterName = "@IDServicio";
                    ParIDServicio.SqlDbType = SqlDbType.Int;
                    ParIDServicio.Value = servicios.IDServicio;
                    cmd.Parameters.Add(ParIDServicio);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@Nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 250;
                    ParNombre.Value = servicios.Nombre;
                    cmd.Parameters.Add(ParNombre);

                    SqlParameter ParDescripcion = new SqlParameter();
                    ParDescripcion.ParameterName = "@Descripcion";
                    ParDescripcion.SqlDbType = SqlDbType.VarChar;
                    ParDescripcion.Size = 250;
                    ParDescripcion.Value = servicios.Descripcion;
                    cmd.Parameters.Add(ParDescripcion);

                    SqlParameter ParCosto = new SqlParameter();
                    ParCosto.ParameterName = "@Costo";
                    ParCosto.SqlDbType = SqlDbType.Int;
                    ParCosto.Value = servicios.Costo;
                    cmd.Parameters.Add(ParCosto);

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

        public string eliminar(D_Servicios servicios)

        {
            string RPTE = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Eliminar_Servicio";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDServicio = new SqlParameter();
                    ParIDServicio.ParameterName = "@IDServicio";
                    ParIDServicio.SqlDbType = SqlDbType.Int;
                    ParIDServicio.Value = servicios.IDServicio;
                    cmd.Parameters.Add(ParIDServicio);

                    RPTE = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPTE = err.Message;
                }

                return RPTE;
            }
        }
        //Bucar por Nombre
        public DataTable Buscar_Nombre(D_Servicios servicios)
        {
            DataTable DAT = new DataTable("Servicios");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Buscar_Servicios";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@Nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 250;
                    ParNombre.Value = servicios.Nombre;
                    cmd.Parameters.Add(ParNombre);

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
   
