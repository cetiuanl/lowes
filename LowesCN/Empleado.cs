using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Empleado
    {
        #region Propiedades
        public int idEmpleado { get; private set; }
        public string nombreCompleto { get; private set; }
        public DateTime fechaNacimiento { get; private set; }
        public string usuario { get; private set;}
        public string contrasena { get;  private set;}
        public int idRol { get; private set;}
        public bool esActivo { get; private set; }
        public DateTime fechaCreacion { get; private set; }
        #endregion
        #region Constructores
        //Constructor para llenar informacion desde la capa de presentacion
        public Empleado( int _idEmpleado,
                        string _nombreCompleto,
                        DateTime _fechaNacimiento,
                        string _usuario,
                        string _contrasena,
                        int _idRol,
                        bool _esActivo,
                        DateTime _fechaCreacion)
        {
            idEmpleado = _idEmpleado;
            nombreCompleto = _nombreCompleto;
            fechaNacimiento = _fechaNacimiento;
            usuario = _usuario;
            contrasena = _contrasena;
            idRol = _idRol;
            esActivo = _esActivo;
            fechaCreacion = _fechaCreacion;
        }

        public Empleado(DataRow fila)
        {
            idEmpleado = fila.Field<int>("idEmpleado");
            nombreCompleto = fila.Field<string>("nombreCompleto");
            fechaNacimiento = fila.Field<DateTime>("fechaNacimiento");
            usuario = fila.Field<string>("usuario");
            contrasena = fila.Field<string>("contrasena");
            idRol = fila.Field<int>("idRol");
            esActivo = fila.Field<bool>("esActivo");
            fechaCreacion = fila.Field<DateTime>("fechaCreacion");
        }
        #endregion
        #region Procedimientos y Funciones

        #endregion
    }
}
