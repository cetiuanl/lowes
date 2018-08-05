using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowesCN
{
    public class Constantes
    {
        static public class StoreProcedure
        {
            static public class Empleado
            {
                static string Insert = "dbo.SPIEmpleado";
                static string Update = "dbo.SPUEmpleado";
            }
            static public class Rol
            {
                static public string Insert = "dbo.SPIRolEmpleado";
                static public string Update = "dbo.SPURolEmpleado";
            }
            static public class DetallesVenta
            {
                static public string Insert = "dbo.SPIDetallesVenta";
                static public string Update = "dbo.SPUDetallesVenta";
            }
        }        
    }
}
