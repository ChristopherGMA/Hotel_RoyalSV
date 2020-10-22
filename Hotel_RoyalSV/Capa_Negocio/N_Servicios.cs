using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;


namespace Capa_Negocio
{
    public class N_Servicios
    {
        //Insertar
        public string Insertar(int idservicios, string nombre, string descripcion, int costo)
        {
            D_Servicios OBJ = new D_Servicios();
            OBJ.IDServicio = idservicios;
            OBJ.Nombre = nombre;
            OBJ.Descripcion = descripcion;
            OBJ.Costo = costo;

            return OBJ.Insertar(OBJ);


        }

        //Eliminar
        public string eliminar(D_Servicios servicios, int idservicio)
        {
            D_Servicios OBJ = new D_Servicios();
            OBJ.IDServicio = idservicio;

            return OBJ.eliminar(OBJ);


        }

        //Bucar por Nombre
        public static DataTable Buscar_Nombre(D_Servicios servicios, int idservicio) 
        {
            D_Servicios OBJ = new D_Servicios();
            OBJ.IDServicio = idservicio;
            return OBJ.Buscar_Nombre(OBJ);

        }
    }
}
