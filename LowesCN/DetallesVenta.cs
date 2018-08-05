using LowesCD;
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
        public void guardar()
        {
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@idProducto", this.idProducto);
            parametros.Add("@idVenta", this.idVenta);
            parametros.Add("@IVA", this.IVA);
            parametros.Add("@precioVenta", this.precioVenta);
            parametros.Add("@cantidad", this.cantidad);

            //Si idDetalleVenta es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idDetalleVenta > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idDetalleVenta", this.idDetalleVenta);
                parametros.Add("@idEmpleado", 0);

                if (DataBaseHelper.ExecuteNonQuery(Constantes.StoreProcedure.DetallesVenta.Update, parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idDetalleVenta = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery(Constantes.StoreProcedure.DetallesVenta.Insert, parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }
        }

        public static implicit operator DetallesVenta(CategoriaProducto v)
        {
            throw new NotImplementedException();
        }

        //public static void desactivar(int idDetalleVenta)
        //{
        //    if (idRol > 0)
        //    {
        //        Dictionary<string, object> parametros = new Dictionary<string, object>();

        //        parametros.Add("@idRol", idRol);

        //        try
        //        {
        //            if (DataBaseHelper.ExecuteNonQuery("dbo.SPBRoles", parametros) == 0)
        //            {
        //                throw new CustomException("No se elimino el registro.");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new CustomException(ex.Message.ToString(), ex);
        //        }
        //    }
        //}
        //public static DetallesVenta traerPorId(int idDetalleVenta)
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    parametros.Add("@idRol", _idRol);

        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        DataBaseHelper.Fill(dt, "dbo.SPLRol", parametros);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString(), ex);
        //    }

        //    Rol oResultado = new Rol();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        oResultado = new Rol(item);
        //        break;
        //    }
        //    return oResultado;
        //}
        //public static List<DetallesVenta> traerTodos()
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();

        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        DataBaseHelper.Fill(dt, "dbo.SPLRol", parametros);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CustomException(ex.Message.ToString(), ex);
        //    }

        //    List<Rol> listado = new List<Rol>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        listado.Add(new Rol(item));
        //    }

        //    return listado;
        //}
        //public static List<DetallesVenta> traerActivos()
        //{
        //    Dictionary<string, object> parametros = new Dictionary<string, object>();
        //    parametros.Add("@esActivo", true);


        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        DataBaseHelper.Fill(dt, "dbo.SPLRol", parametros);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CustomException(ex.Message.ToString(), ex);
        //    }

        //    List<Rol> listado = new List<Rol>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        listado.Add(new Rol(item));
        //    }

        //    return listado;
        //}
        #endregion
    }
}
