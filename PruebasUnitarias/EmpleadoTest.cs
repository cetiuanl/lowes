﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LowesCN;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class EmpleadoTest
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

            [TestMethod]
            public void TestDesactivar()
            {
                bool result = false;
                string mensaje = "";

                try
                {
                    //var rolActual = Rol.traerTodos(true);

                    //Rol.desactivar(rolActual.);
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

                List<Rol> listado = null;
                try
                {
                    listado = Rol.traerTodos(false);
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message.ToString();
                }

                Assert.IsTrue((listado.Count > 0), mensaje);
            }
        }
    }
}
