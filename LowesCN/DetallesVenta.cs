using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
     public class DetallesVenta
    {
        #region Propiedades

        public int idDetalleVenta { get; private set; }
        public int idVenta { get; private set; }
        public int idProducto { get; private set; }
        public decimal cantidad { get; private set; }
        public float precioVenta { get; private set; }
        public decimal   IVA { get; private set; }
        public bool esActivo { get; private set; }
        #endregion

        #region Constructores
        public DetallesVenta(int _idDetalleVenta, int _idVenta, int _idProducto, decimal _cantidad,
            float _precioVenta, decimal _IVA, bool _esActivo)
        {
            idDetalleVenta = _idDetalleVenta;
            idVenta = _idVenta;
            idProducto = _idProducto;
            cantidad = _cantidad;
            precioVenta = _precioVenta;
            IVA = _IVA;
            esActivo = _esActivo;
        }

        public DetallesVenta(DataRow fila)
        {
            idDetalleVenta = fila.Field<int>("idDetalleVenta");
            idVenta = fila.Field<int>("idVenta");
            idProducto = fila.Field<int>("idProducto");
            cantidad = fila.Field<decimal>("cantidad");
            precioVenta = fila.Field<float>("precioVenta");
            IVA = fila.Field<decimal>("IVA");
            esActivo = fila.Field<bool>("esActivo");            
        }
        #endregion

        #region Metodos y funciones

        #endregion
    }
}
