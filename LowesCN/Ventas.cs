﻿using LowesCD;
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
        public void guardar() {
        //Creo un diccionario para guardar los parametros
        Dictionary<string, object> parametros = new Dictionary<string, object>();
        //Al diccionario "parametros" agregamos el nombre del parametro del
        // Store Procedure y su valor (propiedad de la clase correspondiente)            

        parametros.Add("@idEmpleado", this.idEmpleado);
        parametros.Add("@fechaVenta", this.fechaVenta);
        parametros.Add("@estatus", this.estatus);
        parametros.Add("@idCliente", this.idCliente);
        parametros.Add("@tipoPago", this.tipoPago);

        //Si idDetalleVenta es mayor a 0, significa que es una registro existente, usar un Update            
        if (this.@idVenta > 0)
        {
            //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
            //a modificar
            parametros.Add("@idVenta", this.idEmpleado);
            if (DataBaseHelper.ExecuteNonQuery("dbo.SPUVentas", parametros) == 0)
            {
                throw new Exception("No se actualizo el registro.");
            }
        }
            else //Si idVenta = 0, significa que es una registro nuevo, entonces usar Insert.
            {
            if (DataBaseHelper.ExecuteNonQuery("dbo.SPIVentas", parametros) == 0)
            {
                throw new Exception("No se creó el registro.");
            }
        }
        }
        public static void desactivar(int idVenta)
        {
        }
        public static Ventas traerPorId(int idVenta)
        {
            return null;
        }
        public static List<Ventas> traerTodos()
        {
            return null;
        }
        public static List<Ventas> traerActivos()
        {
            return null;
        }




        #endregion

    }
}