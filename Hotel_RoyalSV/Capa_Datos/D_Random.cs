using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Capa_Datos
{
    public class D_Random
    {
        private string[] StoreProcedures = { "SP_BuscarRandomNumber_Cliente", "SP_BuscarRandomNumber_Costos", "SP_BuscarRandomNumber_Empleado"
                                            "SP_BuscarRandomNumber_Habitaciones", "SP_BuscarRandomNumber_Reservas",
                                                "SP_BuscarRandomNumber_Servicios"};
        private int _ID;

        public int ID { get => _ID; set => _ID = value; }

        public D_Random() { }

        public D_Random(int id)
        {
            this.ID = id;
        }

        public DataTable Number_Exist(string table, D_Random random)
        {
            DataTable DAT = new DataTable(table);

            using (SqlConnection CON = D_Coneccion.Coneccion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = CON;

                    switch (table)
                    {

                        case "CLIENTE":
                            cmd.CommandText = StoreProcedures[0];
                            break;

                        case "COSTOS":
                            cmd.CommandText = StoreProcedures[1];
                            break;

                        case "EMPLEADO":
                            cmd.CommandText = StoreProcedures[2];
                            break;

                        case "HABITACIONES":
                            cmd.CommandText = StoreProcedures[3];
                            break;

                        case "RESERVAS":
                            cmd.CommandText = StoreProcedures[4];
                            break;

                        case "SERVICIOS":
                            cmd.CommandText = StoreProcedures[5];
                            break;

                        default:
                            MessageBox.Show("Tabla no encontrada, por favor verifique el nombre ingresado", "Atencion", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParID = new SqlParameter();
                    ParID.ParameterName = "@ID";
                    ParID.SqlDbType = SqlDbType.Int;
                    ParID.Value = random.ID;
                    cmd.Parameters.Add(ParID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(DAT);
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
