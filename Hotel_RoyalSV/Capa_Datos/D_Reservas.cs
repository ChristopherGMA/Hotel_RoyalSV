using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Reservas
    {
        //definicion de variables
        private int _IDReserva;
        private int _IDServicio;
        private int _IDCLiente;
        private int _IDHabitacion;
        private int _Fecha_Entrada;
        private int _Fecha_Salida;
        private int _Costo_Total;

        //encapsulamiento
        public int IDReserva { get => _IDReserva; set => _IDReserva = value; }
        public int IDServicio { get => _IDServicio; set => _IDServicio = value; }
        public int IDCLiente { get => _IDCLiente; set => _IDCLiente = value; }
        public int IDHabitacion { get => _IDHabitacion; set => _IDHabitacion = value; }
        public int Fecha_Entrada { get => _Fecha_Entrada; set => _Fecha_Entrada = value; }
        public int Fecha_Salida { get => _Fecha_Salida; set => _Fecha_Salida = value; }
        public int Costo_Total { get => _Costo_Total; set => _Costo_Total = value; }

        //metodos
        public D_Reservas() { }

        public D_Reservas(int id_reserva, int id_servicio, int id_cliente, int id_habitacion,
            int fechaEntrada, int fechaSalida, int costoTotal)
        {
            this.IDReserva = id_reserva;
            this.IDServicio = id_servicio;
            this.IDCLiente = id_cliente;
            this.IDHabitacion = id_habitacion;
            this.Fecha_Entrada = fechaEntrada;
            this.Fecha_Salida = fechaSalida;
            this.Costo_Total = costoTotal;
                

        }


        //Insertar
        public string Insertar(D_Reservas reservas)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Insertar_Reservas";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDReserva = new SqlParameter();
                    ParIDReserva.ParameterName = "@IDReserva";
                    ParIDReserva.SqlDbType = SqlDbType.Int;
                    ParIDReserva.Value = reservas.IDReserva;
                    cmd.Parameters.Add(ParIDReserva);

                    SqlParameter ParIDServicio = new SqlParameter();
                    ParIDServicio.ParameterName = "@IDServicio";
                    ParIDServicio.SqlDbType = SqlDbType.Int;
                    ParIDServicio.Value = reservas.IDServicio;
                    cmd.Parameters.Add(ParIDServicio);

                    SqlParameter ParIDCLiente = new SqlParameter();
                    ParIDCLiente.ParameterName = "@IDCLiente";
                    ParIDCLiente.SqlDbType = SqlDbType.Int;
                    ParIDCLiente.Value = reservas.IDCLiente;
                    cmd.Parameters.Add(ParIDCLiente);

                    SqlParameter ParIDHabitacion = new SqlParameter();
                    ParIDHabitacion.ParameterName = "@IDHabitacion";
                    ParIDHabitacion.SqlDbType = SqlDbType.Int;
                    ParIDHabitacion.Value = reservas.IDHabitacion;
                    cmd.Parameters.Add(ParIDHabitacion);

                    SqlParameter ParFecha_Entrada = new SqlParameter();
                    ParFecha_Entrada.ParameterName = "@Fecha_Entrada";
                    ParFecha_Entrada.SqlDbType = SqlDbType.Int;
                    ParFecha_Entrada.Value = reservas._Fecha_Entrada;
                    cmd.Parameters.Add(ParFecha_Entrada);

                    SqlParameter ParFecha_Salida = new SqlParameter();
                    ParFecha_Salida.ParameterName = "@Fecha_Salida";
                    ParFecha_Salida.SqlDbType = SqlDbType.Int;
                    ParFecha_Salida.Value = reservas._Fecha_Salida;
                    cmd.Parameters.Add(ParFecha_Salida);

                    SqlParameter ParCosto_Total = new SqlParameter();
                    ParCosto_Total.ParameterName = "@Costo_Total";
                    ParCosto_Total.SqlDbType = SqlDbType.Int;
                    ParCosto_Total.Value = reservas.Costo_Total;
                    cmd.Parameters.Add(ParFecha_Entrada);


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

        public string eliminar(D_Reservas reserva)

        {
            string RPTE = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Eliminar_Reserva";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDReserva = new SqlParameter();
                    ParIDReserva.ParameterName = "@IDReserva";
                    ParIDReserva.SqlDbType = SqlDbType.Int;
                    ParIDReserva.Value = reserva.IDReserva;
                    cmd.Parameters.Add(ParIDReserva);

                    RPTE = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPTE = err.Message;
                }

                return RPTE;
            }
        }
        //Bucar por fecha de entrada
        public DataTable Buscar_Reserva(D_Reservas reserva)
        {
            DataTable DAT = new DataTable("Reservas");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Buscar_reserva";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDReserva = new SqlParameter();
                    ParIDReserva.ParameterName = "@IDReserva";
                    ParIDReserva.SqlDbType = SqlDbType.VarChar;
                    ParIDReserva.Size = 10;
                    ParIDReserva.Value = reserva.IDReserva;
                    cmd.Parameters.Add(ParIDReserva);

                    SqlParameter ParFecha_Entrada = new SqlParameter();
                    ParFecha_Entrada.ParameterName = "@Fecha_Entrada";
                    ParFecha_Entrada.SqlDbType = SqlDbType.Int;
                    ParFecha_Entrada.Value = reserva._Fecha_Entrada;
                    cmd.Parameters.Add(ParFecha_Entrada);

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
