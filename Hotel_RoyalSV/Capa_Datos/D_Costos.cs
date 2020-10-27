using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    class D_Costos
    {
        private int _ID_Costo;
        private String _Tipo_Habitacion;
        private int _Costo;

        //Encapsulamiento//
        public int ID_Costo { get => _ID_Costo; set => _ID_Costo = value; }
        public string Tipo_Habitacion { get => _Tipo_Habitacion; set => _Tipo_Habitacion = value; }
        public int Costo { get => _Costo; set => _Costo = value; }

        public D_Costos(){ }
        public D_Costos(int id_costo,String tipo_habitacion, int costos) { this.ID_Costo = id_costo;
        this.Tipo_Habitacion=tipo_habitacion;
            this.Costo = costos;}
        //Insertar
        public string Insertar(D_Costos costos)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Insertar_Costos";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDCosto = new SqlParameter();
                    ParIDCosto.ParameterName = "@IDCosto";
                    ParIDCosto.SqlDbType = SqlDbType.Int;
                    ParIDCosto.Value = costos.ID_Costo;
                    cmd.Parameters.Add(ParIDCosto);


                    SqlParameter ParTipo_Habitacion = new SqlParameter();
                    ParTipo_Habitacion.ParameterName = "@Tipo_Habitacion";
                    ParTipo_Habitacion.SqlDbType = SqlDbType.VarChar;
                    ParTipo_Habitacion.Size = 50;
                    ParTipo_Habitacion.Value = costos.Tipo_Habitacion;
                    cmd.Parameters.Add(ParTipo_Habitacion);

                    SqlParameter ParCosto = new SqlParameter();
                    ParCosto.ParameterName = "@Costo";
                    ParCosto.SqlDbType = SqlDbType.Int;
                    ParCosto.Value = costos.Costo;
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
        //Editar
        public string Editar(D_Costos costos)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Editar_Costo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTipo_Habitacion = new SqlParameter();
                    ParTipo_Habitacion.ParameterName = "@Tipo_Habitacion";
                    ParTipo_Habitacion.SqlDbType = SqlDbType.VarChar;
                    ParTipo_Habitacion.Size = 50;
                    ParTipo_Habitacion.Value = costos.Tipo_Habitacion;
                    cmd.Parameters.Add(ParTipo_Habitacion);

                    SqlParameter ParCosto = new SqlParameter();
                    ParCosto.ParameterName = "@Costo";
                    ParCosto.SqlDbType = SqlDbType.Int;
                    ParCosto.Value = costos.Costo;
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
        public string Eliminar(D_Costos costos)
        {
            string RPT = "";
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Eliminar_Costos";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIDCosto = new SqlParameter();
                    ParIDCosto.ParameterName = "@IDCosto";
                    ParIDCosto.SqlDbType = SqlDbType.Int;
                    ParIDCosto.Value = costos.ID_Costo;
                    cmd.Parameters.Add(ParIDCosto);

                    RPT = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";
                }
                catch (Exception err)
                {
                    RPT = err.Message;
                }

                return RPT;
            }
        }


        //Bucar por Tipo_Habitacion//
      
        public DataTable Buscar_Tipo_Habitacion(D_Costos costos)
        {
            DataTable DAT = new DataTable("Costos");
            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    CON.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;
                    cmd.CommandText = "SP_Buscar_habitacion";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParTipo_Habitacion = new SqlParameter();
                    ParTipo_Habitacion.ParameterName = "@Tipo_Habitacion";
                    ParTipo_Habitacion.SqlDbType = SqlDbType.VarChar;
                    ParTipo_Habitacion.Size = 50;
                    ParTipo_Habitacion.Value = costos.Tipo_Habitacion;
                    cmd.Parameters.Add(ParTipo_Habitacion);


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
