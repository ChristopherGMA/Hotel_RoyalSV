using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Habitaciones
    {
        private int _IDHabitacion;
        private int _IDCliente;
        private int _IDCostos;
        private int _Numero;
        private string _Estado;

        public int IDHabitacion { get => _IDHabitacion; set => _IDHabitacion = value; }
        public int IDCliente { get => _IDCliente; set => _IDCliente = value; }
        public int IDCostos { get => _IDCostos; set => _IDCostos = value; }
        public int Numero { get => _Numero; set => _Numero = value; }
        public string Estado { get => _Estado; set => _Estado = value; }


        //metodos

        public D_Habitaciones() { }


        public D_Habitaciones(int id_habitacion, int id_cliente, int id_costos, int numero, string estado)
        {
            this.IDHabitacion = id_habitacion;
            this.IDCliente = id_cliente;
            this.IDCostos = id_costos;
            this.Numero = numero;
            this.Estado = estado;
        }
        public string Insertar(D_Habitaciones habitaciones)
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

                    SqlParameter ParIDHabitacion = new SqlParameter();
                    ParIDHabitacion.ParameterName = "@IDHabitacion";
                    ParIDHabitacion.SqlDbType = SqlDbType.Int;
                    ParIDHabitacion.Value = habitaciones.IDHabitacion;
                    cmd.Parameters.Add(ParIDHabitacion);

                    SqlParameter ParIDCliente = new SqlParameter();
                    ParIDCliente.ParameterName = "@IDCliente";
                    ParIDCliente.SqlDbType = SqlDbType.Int;
                    ParIDCliente.Value = habitaciones.IDCliente;
                    cmd.Parameters.Add(ParIDCliente);

                    SqlParameter ParIDCostos = new SqlParameter();
                    ParIDCostos.ParameterName = "@IDCostos";
                    ParIDCostos.SqlDbType = SqlDbType.Int;
                    ParIDCostos.Value = habitaciones.IDCostos;
                    cmd.Parameters.Add(ParIDCostos);

                    SqlParameter ParNumero = new SqlParameter();
                    ParNumero.ParameterName = "@Numero";
                    ParNumero.SqlDbType = SqlDbType.Int;
                    ParNumero.Value = habitaciones.Numero;
                    cmd.Parameters.Add(ParNumero);



                    SqlParameter ParEstado = new SqlParameter();
                    ParEstado.ParameterName = "@Estado";
                    ParEstado.SqlDbType = SqlDbType.VarChar;
                    ParEstado.Size = 30;
                    ParEstado.Value = habitaciones.Estado;
                    cmd.Parameters.Add(ParEstado);


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
        public string Editar(D_Habitaciones habitaciones)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {

                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Insertar_habitacion";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDHabitacion = new SqlParameter();
                    ParIDHabitacion.ParameterName = "@IDHabitacion";
                    ParIDHabitacion.SqlDbType = SqlDbType.Int;
                    ParIDHabitacion.Value = habitaciones.IDHabitacion;
                    cmd.Parameters.Add(ParIDHabitacion);

                    SqlParameter ParIDCliente = new SqlParameter();
                    ParIDCliente.ParameterName = "@IDCliente";
                    ParIDCliente.SqlDbType = SqlDbType.Int;
                    ParIDCliente.Value = habitaciones.IDCliente;
                    cmd.Parameters.Add(ParIDCliente);

                    SqlParameter ParIDCostos = new SqlParameter();
                    ParIDCostos.ParameterName = "@IDCostos";
                    ParIDCostos.SqlDbType = SqlDbType.Int;
                    ParIDCostos.Value = habitaciones.IDCostos;
                    cmd.Parameters.Add(ParIDCostos);

                    SqlParameter ParNumero = new SqlParameter();
                    ParNumero.ParameterName = "@Numero";
                    ParNumero.SqlDbType = SqlDbType.Int;
                    ParNumero.Value = habitaciones.Numero;
                    cmd.Parameters.Add(ParNumero);



                    SqlParameter ParEstado = new SqlParameter();
                    ParEstado.ParameterName = "@Estado";
                    ParEstado.SqlDbType = SqlDbType.VarChar;
                    ParEstado.Size = 30;
                    ParEstado.Value = habitaciones.Estado;
                    cmd.Parameters.Add(ParEstado);
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
        public string Anular(D_Habitaciones habitaciones)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_anular_habitacion";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDHabitacion = new SqlParameter();
                    ParIDHabitacion.ParameterName = "@IDHabitacion";
                    ParIDHabitacion.SqlDbType = SqlDbType.Int;
                    ParIDHabitacion.Value = habitaciones.IDHabitacion;
                    cmd.Parameters.Add(ParIDHabitacion);

                    SqlParameter ParEstado = new SqlParameter();
                    ParEstado.ParameterName = "@Estado";
                    ParEstado.SqlDbType = SqlDbType.VarChar;
                    ParEstado.Size = 30;
                    ParEstado.Value = habitaciones.Estado;
                    cmd.Parameters.Add(ParEstado);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }
        //Bucar por estado
        public DataTable Buscar_Estado(D_Habitaciones habitaciones)
        {
            DataTable DAT = new DataTable("Habitaciones");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Buscar_habitacion";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDHabitacion = new SqlParameter();
                    ParIDHabitacion.ParameterName = "@IDHabitacion";
                    ParIDHabitacion.SqlDbType = SqlDbType.Int;
                    ParIDHabitacion.Value = habitaciones.IDHabitacion;
                    cmd.Parameters.Add(ParIDHabitacion);

                    SqlParameter ParEstado = new SqlParameter();
                    ParEstado.ParameterName = "@Estado";
                    ParEstado.SqlDbType = SqlDbType.VarChar;
                    ParEstado.Size = 30;
                    ParEstado.Value = habitaciones.Estado;
                    cmd.Parameters.Add(ParEstado);


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
