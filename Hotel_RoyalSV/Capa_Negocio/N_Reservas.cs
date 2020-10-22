using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Reservas
    {

        //Insertar
        public static String Insertar(int id_reservas, int id_servicio, int id_cliente, int id_habitacion, int fehaEntrada,
            int fechaSalida, int costoTotal)
        
        {
            D_Reservas OBJ = new D_Reservas();
            OBJ.IDReserva = id_reservas;
            OBJ.IDServicio = id_servicio;
            OBJ.IDCLiente = id_cliente;
            OBJ.IDHabitacion = id_habitacion;
            OBJ.Fecha_Entrada = fehaEntrada;
            OBJ.Fecha_Salida = fechaSalida;
            OBJ.Costo_Total = costoTotal;



            return OBJ.Insertar(OBJ);

        }

        //Eliminar
        public string eliminar(D_Reservas reserva, int id_reservas)
        {
            D_Reservas OBJ = new D_Reservas();
            OBJ.IDReserva = id_reservas;

            return OBJ.eliminar(OBJ);


        }

        //Bucar por fecha de entrada
        public static DataTable Buscar_Reservas(D_Reservas reserva, int id_reservas) 
        {
            D_Reservas OBJ = new D_Reservas();
            OBJ.IDReserva = id_reservas;
            return OBJ.Buscar_Reserva(OBJ);
            
        }









    }
}
