using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class ModoPago
    {
        public static string DisplayMember = "descripcion";
        public static string ValueMember = "idModoPago";

        public ModoPago(int _idModoPago, string _descripcion)
        {
            idModoPago = _idModoPago;
            descripcion = _descripcion;
        }

        public int idModoPago { get; set; }
        public string descripcion { get; set; }
    }
}
