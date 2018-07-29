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
            fechaCracion = fila.Field<DateTime>("dechaCracion");
            
        }
        #endregion

        #region Procedimientos y funciones

        #endregion
    }
}
