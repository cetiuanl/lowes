using LowesCD;
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
        public Empleado(int _idEmpleado,
                string _nombreCompleto,
                DateTime _fechaNacimiento,
                string _usuario,
                string _contrasena,
                int _idRol,
                bool _esActivo)
        {
            idEmpleado = _idEmpleado;
            nombreCompleto = _nombreCompleto;
            fechaNacimiento = _fechaNacimiento;
            usuario = _usuario;
            contrasena = _contrasena;
            idRol = _idRol;
            esActivo = _esActivo;
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
        public void guardar()
        {
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@nombreCompleto", this.nombreCompleto);
            parametros.Add("@fechaNacimiento", this.fechaNacimiento);
            parametros.Add("@usuario", this.usuario);
            parametros.Add("@contrasena", this.contrasena);
            parametros.Add("@idRol", this.idRol);

            //Si idDetalleVenta es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idEmpleado > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idEmpleado", this.idEmpleado);
                //parametros.Add("@idEmpleado", 0);
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPUEmpleados", parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idDetalleVenta = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPIEmpleados", parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }
        }
        public static void desactivar(int idEmpleado)
        {

        }
        public static Empleado traerPorId(int idEmpleado)
        {
            return null;
        }
        public static List<Empleado> traerTodos()
        {
            return null;
        }
        public static List<Empleado> traerActivos()
        {
            return null;
        }
        #endregion
    }
}
