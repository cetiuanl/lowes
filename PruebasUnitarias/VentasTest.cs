using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowesCN;
using System.Collections.Generic;

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
                DateTime fecha = new DateTime(2014, 10, 11);
                Ventas nuevoVenta = new Ventas(0,109,DateTime.Today,1,3,"Efectivo");
                nuevoVenta.guardar();
                result = true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue(result, mensaje);
        }

        public void TestTraerTodos()
        {
            string mensaje = "";

            List<Ventas> listado = null;
            try
            {
                listado = Ventas.traerTodos(false);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message.ToString();
            }

            Assert.IsTrue((listado.Count > 0), mensaje);
        }
    }
}
