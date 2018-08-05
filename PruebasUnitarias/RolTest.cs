using LowesCN;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebasUnitarias
{
    [TestClass]
    public class RolTest
    {
        [TestMethod]
        public void TestGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                Rol nuevoRol = new Rol(0, "nombre", "descripcion");
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
