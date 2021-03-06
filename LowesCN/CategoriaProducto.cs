﻿using LowesCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class CategoriaProducto
    {
        #region Propiedades
        public int idCategoria { get; private set; }
        public string nombre { get; private set; }
        public bool esActivo { get; private set; }
        public DateTime fechaCreacion { get; private set; }
        public String descripcion { get; private set; }

        #endregion
        #region Constructores
        public CategoriaProducto(int _idCategoria, string _nombre, string _descripcion)
        {
            idCategoria = _idCategoria;
            nombre = _nombre;
            descripcion = _descripcion;            
        }

        public CategoriaProducto(DataRow fila)
        {
            idCategoria = fila.Field<int>("idCategoria");
            nombre = fila.Field<string>("nombre");            
            descripcion = fila.Field<string>("descripcion");
            fechaCreacion = fila.Field<DateTime>("fechaCreacion");
        }

        #endregion
        #region metodos y funciones
        public void guardar()
        {//Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@nombre", this.nombre);
            parametros.Add("@Descripcion", this.descripcion);


            //Si idCategoriaProducto es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idCategoria > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idCategoria", this.idCategoria);
               
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPUCategoriaProductos", parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idCategoriaProducto = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPICategoriaProductos", parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }
        }
        public static void desactivar(int idCategoriaProducto)
        {
            if (idCategoriaProducto > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idCategoriaProducto", idCategoriaProducto);

                if (DataBaseHelper.ExecuteNonQuery("dbo.SPDCategoriaProductos", parametros) == 0)
                {
                    throw new Exception("No se elimino el registro");
                }
            }
            else
            {
                throw new Exception("id no valida");
            }
        }
        public static CategoriaProducto TraerPorId(int idCategoriaProducto)
        {
            if (idCategoriaProducto > 0)
            {

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idCategoriaProducto", idCategoriaProducto);

                DataTable dt = new DataTable();

                DataBaseHelper.Fill(dt, "dbo.SPSCategoriaProductos", parametros);

                CategoriaProducto oResultado = null;

                foreach (DataRow item in dt.Rows)
                {
                    oResultado = new CategoriaProducto(item);
                    break;
                }
                return oResultado;
            }
            else {
                throw new Exception("id no valido.");
            }        
        }
        public static List<CategoriaProducto> traerTodos(bool soloActivos)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            if (soloActivos)
                parametros.Add("@esActivo", true);
            DataTable dt = new DataTable();

            DataBaseHelper.Fill(dt, "dbo.SPSCategoriaProductos", parametros);

            List<CategoriaProducto> listado = new List<CategoriaProducto>();

            foreach (DataRow fila in dt.Rows)
            {
                listado.Add(new CategoriaProducto(fila));
            }
        
            return listado;
        }

        #endregion
    }    
}