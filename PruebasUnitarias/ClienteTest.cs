using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowesCN;
using System.Collections.Generic;

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
            bool result = false;
            string mensaje2 = "";

            try
            {
                Cliente.desactivar(1);
                result = true;
            }
            catch (Exception ex)
            {
                mensaje2 = ex.Message.ToString();
            }
            Assert.IsTrue(result, mensaje2);
        }

        [TestMethod]
        public void TestTraerTodos()
        {
            string mensaje = "";

            List<Cliente> Clientes = null;
            try
            {
                Clientes = Cliente.traerTodos(false);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue((Clientes.Count > 0), mensaje);
        }
    }

   

}
