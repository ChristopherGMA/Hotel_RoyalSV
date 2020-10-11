using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_Random
    {
        public static DataTable Random_Exist(string table, int id)
        {
            D_Random OBJ = new D_Random
            {
                ID = id
            };

            return OBJ.Number_Exist(table, OBJ);
        }
    }
}
