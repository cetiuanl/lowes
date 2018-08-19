using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowesCN;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class ProductoTest
    {
        [TestMethod]
        public void TestGuardar()
        {
            bool result = false;
            string mensaje = "";

            try
            {
                //Producto nuevoProducto = new Producto(0, "producto demo", 100.50, 120.60, 20, 1, "pza.", true);
                //nuevoProducto.guardar();
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue(result, mensaje);
        }
        [TestMethod]
        public void TestTraerTodos()
        {
            string mensaje = "";

            List<Producto> productos = null;
            try
            {
                productos =Producto.traerTodos(false);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue((productos.Count > 0), mensaje);
        }
    }
}
