using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Sesion
    {
        private static Sesion instancia;
        public static Sesion getInstancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sesion();
                }
                return instancia;
            }
        }

        public Empleado empleadoActual { get; set; }
        public Rol rolActual { get; set; }
        public DateTime fechaSesion { get; set; }
    }
}
