﻿using LowesCD;
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

        public int idRol { get; private set; }
        public string nombre { get; private set; }
        public string descripcion { get; private set; }
        public Boolean esActivo { get; private set; }
        public DateTime fechaCreacion { get; private set; }

        #endregion

        #region Constructores

        public Rol(int _idRol, string _nombre, string _descripcion, Boolean _esActivo, DateTime _fechaCreacion)
        {
            idRol = _idRol;
            nombre = _nombre;
            descripcion = _descripcion;
            esActivo = _esActivo;
            fechaCreacion = _fechaCreacion;
        }

        public Rol(int _idRol, string _nombre, string _descripcion)
        {
            idRol = _idRol;
            nombre = _nombre;
            descripcion = _descripcion;
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
        public void guardar()
        {
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@nombre", this.nombre);
            parametros.Add("@descripcion", this.descripcion);


            //Si idDetalleVenta es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idRol > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idRol", this.idRol);

                if (DataBaseHelper.ExecuteNonQuery("dbo.SPURolEmpleado", parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idRol = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPIRolEmpleado", parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }

        }

        
        
        public static void desactivar(int idRol)
        public static Rol traerPorId(int idrol)
        public static List<Rol> traerTodos()
        public static List<Rol> traerActivos()
        #endregion

    }
}
