using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Rol
    {
        #region Propiedades

        public int  idRol { get; private set; }
        public string  nombre { get; private set; }
        public string descripcion { get; private set; }
        public Boolean esActivo { get; private set; }
        public DateTime fechaCreacion { get; private set; }

        #endregion

        #region Constructores
       
        public Rol (int _idRol, string _nombre, string _descripcion, Boolean _esActivo, DateTime _fechaCreacion )
        {
            idRol = _idRol;
            nombre = _nombre;
            descripcion = _descripcion;
            esActivo = _esActivo;
            fechaCreacion = _fechaCreacion;            
        }

        public Rol(DataRow fila)
        {

            idRol = fila.Field<int>("idRol");
            nombre = fila.Field<string>("nombre");
            descripcion = fila.Field<string>("descripcion");
            esActivo = fila.Field<Boolean>("esActivo");
            fechaCreacion = fila.Field<DateTime>("fechaCreacion");
        }


        #endregion

        #region Procedimientos y Funciones




        #endregion

    }
}
