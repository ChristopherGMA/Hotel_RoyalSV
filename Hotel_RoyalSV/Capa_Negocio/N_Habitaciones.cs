using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Habitaciones
    {
        //Insertar
        public static string Insertar(int id_habitacion, int id_cliente, int id_costo, int numero, string estado)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.IDHabitacion = id_habitacion;
            OBJ.IDCliente = id_cliente;
            OBJ.IDCostos = id_costo;
            OBJ.Numero = numero;
            OBJ.Estado = estado;

            return OBJ.Insertar(OBJ);
        }
        //Editar
        public static String Editar(int id_habitacion, int id_cliente, int id_costos, int numero, string estado)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.IDHabitacion = id_habitacion;
            OBJ.IDCliente = id_cliente;
            OBJ.IDCostos = id_costos;
            OBJ.Numero = numero;
            OBJ.Estado = estado;

            return OBJ.Editar(OBJ);

        }

        //Anular
        public static string Anular(int id_habitacion, string estado)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.IDHabitacion = id_habitacion;
            OBJ.Estado = estado;

            return OBJ.Anular(OBJ);

        }

        //Bucar por estado
        public static DataTable Buscar_Estado(string estado)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.Estado = estado;

            return OBJ.Buscar_Estado(OBJ);
        }

        //Buscar habitacion por id
        public static DataTable Buscar_ID(int id_habitacion)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.IDHabitacion = id_habitacion;

            return OBJ.Buscar_ID(OBJ);
        }
    }
}
