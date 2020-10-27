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
        //Editar
        public String Editar (int id_habitacion, int id_cliente, int id_costos, int numero, string estado)
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
        public string Anular(D_Habitaciones habitaciones, int id_habitacion)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.IDHabitacion = id_habitacion;

            return OBJ.Anular(OBJ);

        }

        //Bucar por estado
        public DataTable Buscar_Estado(D_Habitaciones habitaciones, int id_habitacion)
        {
            D_Habitaciones OBJ = new D_Habitaciones();
            OBJ.IDHabitacion = id_habitacion;

            return OBJ.Buscar_Estado(OBJ);
        }





    }




}
