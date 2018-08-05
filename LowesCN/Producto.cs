using LowesCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Producto
    {
        #region Propiedades
        public int idProducto { get; private set; }
        public string nombre { get; private set; }
        public float precioCompra { get; private set; }
        public float precioVenta { get; private set; }
        public decimal inventario { get; private set; }
        public int idCategoria { get; private set; }
        public string unidad { get; private set; }
        public bool esActivo { get; private set; }
        public DateTime fechaCracion { get; private set; }
        
        #endregion

        #region Constructores
        public Producto (int _idProducto, string _nombre, float _precioCompra, float _precioVenta, decimal _inventario, int _idCategoria, string _unidad, bool _esActivo, DateTime _fechaCreacion )
        { 
            idProducto = _idProducto;
            nombre = _nombre;
            precioCompra = _precioCompra;
            precioVenta = _precioVenta;
            inventario = _inventario;
            idCategoria = _idCategoria;
            unidad = _unidad;
            esActivo = _esActivo;
            fechaCracion = _fechaCreacion;
                }
        public Producto(int _idProducto, string _nombre, float _precioCompra, float _precioVenta, decimal _inventario, int _idCategoria, string _unidad, bool _esActivo)
        {
            idProducto = _idProducto;
            nombre = _nombre;
            precioCompra = _precioCompra;
            precioVenta = _precioVenta;
            inventario = _inventario;
            idCategoria = _idCategoria;
            unidad = _unidad;
            esActivo = _esActivo;
            
        }
        public Producto(DataRow fila)
        {
            idProducto = fila.Field<int>("idProducto");
            nombre = fila.Field<string>("nombre");
            precioCompra = fila.Field<float>("precioCompra");
            precioVenta = fila.Field<float>("precioVenta");
            inventario = fila.Field<decimal>("inventario");
            idCategoria = fila.Field<int>("idCategoria");
            unidad = fila.Field<string>("unidad");
            esActivo = fila.Field<bool>("esActivo");
            fechaCracion = fila.Field<DateTime>("fechaCracion");
            
        }
        #endregion

        #region Procedimientos y funciones
        public void guardar() {
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@nombre", this.nombre);
            parametros.Add("@precioCompra", this.precioCompra);
            parametros.Add("@precioVenta", this.precioVenta);
            parametros.Add("@inventario", this.inventario);
            parametros.Add("@idCategoria", this.idCategoria);
            parametros.Add("@unidad", this.unidad);

            //Si idDetalleVenta es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idProducto > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idProducto", this.idProducto);
                
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPUProductos", parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idDetalleVenta = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPIProductos", parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }

        }
        public static void desactivar(int idProducto) {
        }
        public static Producto traerPorId(int idProducto) {
            return null;
        }
        public static List<Producto> traerTodos() {
            return null;
        }
        public static List<Producto> traerActivos() {
            return null;
        }


        #endregion
    }
}
