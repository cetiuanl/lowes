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
                static public string Insert = "dbo.SPIEmpleado";
                static public string Update = "dbo.SPUEmpleado";
                static public string Delete = "dbo.SPDEmpleado";
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
            static public class Ventas
            {
                static public string Insert = "dbo.SPIVentas";
                static public string Update = "dbo.SPUVentas";
            }
        }        
    }
}
