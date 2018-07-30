using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Ventas
    {
        #region Propiedades
        public int idVenta { get; private set; }
        public int idEmpleado { get; private set; }
        public DateTime fechaVenta { get; private set; }
        public int estatus { get; private set; }
        public int idCliente { get; private set; }
        public string tipoPago { get; private set; }

        #endregion

        #region Contructores
        public Ventas(int _idVenta, int _idEmpleado,DateTime _fechaVenta,
            int _estatus,int _idCliente,string _tipoPago)
        {
            idVenta = _idVenta;
            idEmpleado = _idEmpleado;
            fechaVenta = _fechaVenta;
            estatus = _estatus;
            idCliente = _idCliente;
            tipoPago = _tipoPago;
        }
        public Ventas(DataRow fila)
        {
            idVenta = fila.Field<int>("idVenta");
            idEmpleado = fila.Field<int>("idEmpleado");
            fechaVenta = fila.Field<DateTime>("fechaVenta");
            estatus = fila.Field<int>("estatus");
            idCliente = fila.Field<int>("idCliente");
            tipoPago = fila.Field<string>("tipoPago");
        }
        #endregion

        #region Procedimientos y Funciones


        #endregion

    }
}
