using Capa_Datos.Properties;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Coneccion
    {
        private static string LineaConeccion()
        {
            return Settings.Default.HotelConnectionString;
        }

        public static SqlConnection Coneccion()
        {
            SqlConnection CON = new SqlConnection(LineaConeccion());
            return CON;
        }
    }
}
