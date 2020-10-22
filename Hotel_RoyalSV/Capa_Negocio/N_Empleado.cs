using System;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Empleado
    {
        //Insertar
        public static string Insertar(int id_empleado, string nombre, string apellido, int edad, string correo,
                                        string telefono, string celular, string dui, string nit, string isss,
                                        string usuario, String contraseña, string puesto, string departamento)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.ID_Empleado = id_empleado;
            OBJ.Nombre = nombre;
            OBJ.Apellido = apellido;
            OBJ.Edad = edad;
            OBJ.Correo = correo;
            OBJ.Telefono = telefono;
            OBJ.Celular = celular;
            OBJ.DUI = dui;
            OBJ.NIT = nit;
            OBJ.ISSS = isss;
            OBJ.Usuario = usuario;
            OBJ.Contraseña = contraseña;
            OBJ.Puesto = puesto;
            OBJ.Departamento = departamento;

            return OBJ.Insertar(OBJ);
        }

        //Editar
        public static string Editar(int id_empleado, string nombre, string apellido, int edad, string correo,
                                        string telefono, string celular, string dui, string nit, string isss,
                                        string usuario, String contraseña, string puesto, string departamento)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.ID_Empleado = id_empleado;
            OBJ.Nombre = nombre;
            OBJ.Apellido = apellido;
            OBJ.Edad = edad;
            OBJ.Correo = correo;
            OBJ.Telefono = telefono;
            OBJ.Celular = celular;
            OBJ.DUI = dui;
            OBJ.NIT = nit;
            OBJ.ISSS = isss;
            OBJ.Usuario = usuario;
            OBJ.Contraseña = contraseña;
            OBJ.Puesto = puesto;
            OBJ.Departamento = departamento;

            return OBJ.Editar(OBJ);
        }

        //Eliminar
        public static string Eliminar(int id_empleado)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.ID_Empleado = id_empleado;

            return OBJ.Eliminar(OBJ);
        }

        //Anular
        public static string Anular(int id_empleado, string puesto)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.ID_Empleado = id_empleado;
            OBJ.Puesto = puesto;

            return OBJ.Anular(OBJ);
        }

        //Buscar un empleado por DUI
        public static DataTable Buscar_DUI(string dui)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.DUI = dui;

            return OBJ.Buscar_DUI(OBJ);
        }

        //Login
        public static DataTable Loing(string usuario, string contraseña)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.Usuario = usuario;
            OBJ.Contraseña = contraseña;

            return OBJ.Loing(OBJ);
        }

        //Mostrar Datos
        public static DataTable Ver()
        {
            D_Empleado OBJ = new D_Empleado();
            return OBJ.Ver();
        }

        //Buscar por ID
        public static DataTable BuscarID(int id)
        {
            D_Empleado OBJ = new D_Empleado();
            OBJ.ID_Empleado = id;

            return OBJ.BuscarID(OBJ);
        }
    }
}
