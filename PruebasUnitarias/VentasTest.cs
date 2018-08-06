using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowesCN;

namespace PruebasUnitarias
{
    [TestClass]
    public class VentasTest
    {
        [TestMethod]
        public void TestGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                Ventas nuevoRol = new Ventas(0,109,2018-08-05,1,3,"Efectivo");
                nuevoRol.guardar();
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
