using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class EstatusVenta
    {
        public static string DisplayMember = "descripcion";
        public static string ValueMember = "idEstatus";

        public EstatusVenta(int _idEstatus, string _descripcion)
        {
            idEstatus = _idEstatus;
            descripcion = _descripcion;
        }

        public int idEstatus { get; set; }
        public string descripcion { get; set; }
    }
}
