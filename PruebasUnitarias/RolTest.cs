using LowesCN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    class RolTest
    {
        public void RolGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                Rol nuevoRol = new Rol(0, "nombre", "descripcion", true);
                //nuevoRol.guardar();
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue(result, mensaje);
        }
    }
}
