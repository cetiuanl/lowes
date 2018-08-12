using LowesCD;
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
        //private int v1;
        //private int v2;
        //private int v3;
        //private int v4;
        //private int v5;
        //private string v6;

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

        //public Ventas(int v1, int v2, int v3, int v4, int v5, string v6)
        //{
        //    this.v1 = v1;
        //    this.v2 = v2;
        //    this.v3 = v3;
        //    this.v4 = v4;
        //    this.v5 = v5;
        //    this.v6 = v6;
        //}

        //public Ventas(int v1, int v2, int v3, int v4, int v5, string v6)
        //{
        //    this.v1 = v1;
        //    this.v2 = v2;
        //    this.v3 = v3;
        //    this.v4 = v4;
        //    this.v5 = v5;
        //    this.v6 = v6;
        //}
        #endregion

        #region Procedimientos y Funciones

        private string esValido()
        {
            string resultado = "";
            if (this.idVenta==0)
                {
                resultado = resultado + "El campo idVenta es inválido";
                }
            if (this.tipoPago == "")
            {
                resultado = resultado + "El campo idVenta es inválido";
            }
            return resultado;
        }

        public void guardar()
        {
            string mensaje = esValido();
            if (mensaje.Length>0)
            {
                throw new Exception(mensaje);
            }
            
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
                else //Si idVenta = 0, significa que es una registro nuevo, entonces usar Insert.
                    {
                        if (DataBaseHelper.ExecuteNonQuery(Constantes.StoreProcedure.Ventas.Insert, parametros) == 0)
                            {
                                throw new Exception("No se creó el registro.");
                            }
                    }
            }
        }
        public static void desactivar(int idVenta)
        {
            if (idVenta > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idVenta", idVenta);

                if(DataBaseHelper.ExecuteNonQuery("dbo.SPDVenta",parametros)==0)
                {
                    throw new Exception("No se elimino el registro");
                }
            else
                {
                    throw new Exception("Id inválido");
                }
            }

        }
        public static Ventas traerPorId(int idVenta)
        {
            if (idVenta > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idVenta", idVenta);

                DataTable dt = new DataTable();
                DataBaseHelper.Fill(dt, "dbo.SPSVentas", parametros);

                Ventas oResultado = null;

                foreach (DataRow item in dt.Rows)
                {
                    oResultado = new Ventas(item);
                    break;
                }
                return oResultado;
            }
            else
            {
                throw new Exception("Id inválido");
            }
        }
        public static List<Ventas> traerTodos(bool soloActivos)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
         
            if (soloActivos == true)
            {
                parametros.Add("@estatus", true);
            }

            DataTable dt = new DataTable();

            DataBaseHelper.Fill(dt, "dbo.SPSVentas", parametros);

            List<Ventas> listado = new List<Ventas>();

            foreach (DataRow item in dt.Rows)
            {
                listado.Add(new Ventas(item));
            }
            return listado;

        }

        //public static List<Ventas> traerActivos()
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    parametros.Add("@estatus", true);

        //    DataTable dt = new DataTable();

        //    DataBaseHelper.Fill(dt, "dbo.SPSVentas", parametros);

        //    List<Ventas> listado = new List<Ventas>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        listado.Add(new Ventas(item));
        //    }
        //    return listado;
        //}
        #endregion

    }
}
