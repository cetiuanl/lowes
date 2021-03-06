﻿using LowesCD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Cliente
    {
        public static string DisplayMember = "nombreCompleto";
        public static string ValueMember = "idCliente";

        #region propiedades
        public int idCliente { get; private set; }
        public string nombreCompleto { get; private set; }
        public string direccion { get; private set; }
        public string RFC { get; private set; }
        public string correoElectronico { get; private set; }
        public bool esActivo { get; private set; }
        public DateTime fechaCreacion { get; private set; }

        #endregion

        #region Constructores
        public Cliente(int _idCliente,string _nombre,string _direccion,string _RFC,string _correo,
                        bool _esActivo,DateTime _fechaCreacion)
        {
            idCliente = _idCliente;
            nombreCompleto = _nombre;
            direccion = _direccion;
            RFC = _RFC;
            correoElectronico = _correo;
            esActivo = _esActivo;
            fechaCreacion = _fechaCreacion;
        }
        public Cliente(int _idCliente, string _nombre, string _direccion, string _RFC, string _correo)
        {
            idCliente = _idCliente;
            nombreCompleto = _nombre;
            direccion = _direccion;
            RFC = _RFC;
            correoElectronico = _correo;
        }

        public static List<Cliente> traerTodos()
        {
            throw new NotImplementedException();
        }

        public Cliente(DataRow fila)
        {
            idCliente = fila.Field<int>("idCliente");
            nombreCompleto = fila.Field<string>("nombreCompleto");
            direccion = fila.Field<string>("direccion");
            RFC = fila.Field<string>("RFC");
            correoElectronico = fila.Field<string>("correoElectronico");
            esActivo = fila.Field<bool>("esActivo");
            fechaCreacion = fila.Field<DateTime>("fechaCreacion");
        }
        #endregion

        #region Metodos y funciones
        private string esValido()
        {
            if (this.nombreCompleto.Length == 0)
            {
                string resultado = "";
                if (this.nombreCompleto.Length == 0)
                {
                    resultado = resultado + "El campo nomnbreCompleto es invalido.";
                }

                if(this.direccion.Length == 0)
                {
                    resultado = resultado + "El campo direccion es invalido.";
                }
            }
            return "";
        }
        public void guardar()
        {

            if (esValido().Length > 0)
            {
                //objeto incorrecto 
                return;
            }
            //Creo un diccionario para guardar los parametros
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            //Al diccionario "parametros" agregamos el nombre del parametro del
            // Store Procedure y su valor (propiedad de la clase correspondiente)            

            parametros.Add("@nombreCompleto", this.nombreCompleto);
            parametros.Add("@direccion", this.direccion);
            parametros.Add("@RFC", this.RFC);
            parametros.Add("@correoElectronico", this.correoElectronico);

            //Si idDetalleVenta es mayor a 0, significa que es una registro existente, usar un Update            
            if (this.idCliente > 0)
            {
                //Agregamos el parametro del id de la tabla utilizado para ubicar el registro
                //a modificar
                parametros.Add("@idCliente", this.idCliente);
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPUClientes", parametros) == 0)
                {
                    throw new Exception("No se actualizo el registro.");
                }
            }
            else //Si idDetalleVenta = cero, significa que es una registro nuevo, entonces usar Insert.
            {
                if (DataBaseHelper.ExecuteNonQuery("dbo.SPIClientes", parametros) == 0)
                {
                    throw new Exception("No se creó el registro.");
                }
            }
        }
        public static void desactivar(int idCliente)
        {
            if(idCliente > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idCliente", idCliente);

                if(DataBaseHelper.ExecuteNonQuery("dbo.SPDClientes", parametros) == 0)
                {
                    throw new Exception("No se elimino el registro.");
                }
                
            }
            else
            {
                throw new Exception("Id invalido.");
            }
        }
        public static Cliente traerPorId(int idCliente)
        {
            if (idCliente > 0)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idCliente", idCliente);

                DataTable dt = new DataTable();

                DataBaseHelper.Fill(dt, "dbo.SPSClientes", parametros);

                Cliente oResultado = null;

                foreach (DataRow item in dt.Rows)
                {
                    oResultado = new Cliente(item);
                    break;
                }
                return oResultado;
            }
            else
            {
                throw new Exception("Id invalido. ");
            }
        }
        public static List<Cliente> traerTodos(bool soloActivos)
        {
             Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (soloActivos)
            {
                parametros.Add("@esActivo", true);
            }

            DataTable dt = new DataTable();

            DataBaseHelper.Fill(dt, "dbo.SPSClientes", parametros);

            List<Cliente> listado = new List<Cliente>();

            foreach (DataRow item in dt.Rows)
            {
                listado.Add(new Cliente(item));
            }
            return listado;
        }
        
        #endregion

    }
}
       
