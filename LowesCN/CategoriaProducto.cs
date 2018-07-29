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
    }
}
