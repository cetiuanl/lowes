using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowesCN;

namespace PruebasUnitarias
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void tesGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                Cliente nuevoRol = new Cliente(0,"nombre", "direccion", "RFC", "correoElectronico");
                nuevoRol.guardar();
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue(result, mensaje);
        }
        [TestMethod]
        public void Desactivar()
        {
            bool esActivo = false;
            string mensaje2 = "";

            try
            {
                Cliente.desactivar(4);
                esActivo = true;
            }
            catch (Exception ex)
            {
                mensaje2 = ex.Message.ToString();
            }
            Assert.IsTrue(esActivo, mensaje2);
        }
    }

   

}
