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
        
        #endregion

    }
}
