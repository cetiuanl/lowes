using System;
using System.Collections.Generic;
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
        public CategoriaProducto(int _idCategoria, string _nombre,
            bool _esActivo, DateTime _fechaCreacion, string _descripcion)
        {
            idCategoria = _idCategoria;
            nombre = _nombre;
            esActivo = _esActivo;
            fechaCreacion = _fechaCreacion;
            descripcion = _descripcion;


        }
        #endregion
        #region metodos y funciones
        public void guardar()
        {
        }
        public static void desactivar(int idCategoriaProducto)
        {

            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@idCategoriaProducto", this.idCategoriaProducto);
            parametros.Add("@Descripcion", this.Descripcion);
            parametros.Add("@nombre", this.nombre);
            

            //Si idCategoriaProducto es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idCategoriaProducto > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idCategoriaProducto", this.idCategoriaProducto);
                parametros.Add("@descripcion", this.Descripcion)
                parametros.Add("@nombre", this.nombre)

                if (DataBaseHelper.ExecuteNonQuery("dbo.SPUCategoriaProducto", parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idCategoriaProducto = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPICategoriaProducto", parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }

        }
        public static CategoriaProducto TraerPorId(int idCategoriaProducto) {return null }
        public static List<CategoriaProducto> traerTodos() { return null}
        public static List<CategoriaProducto> traerActivos() { return null}