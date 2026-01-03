using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NEmpleados
    {
        private DEmpleados dEmpleados = new DEmpleados();

        public bool ExisteEmpleado(string codigo)
        {
            return dEmpleados.ExisteEmpleado(codigo);
        }

        public string RegistrarEmpleado(CEmpleado cEmpleado, string codigoSucursal)
        {
            return dEmpleados.RegistrarEmpleado(cEmpleado, codigoSucursal);
        }

        public string ModificarEmpleado(CEmpleado cEmpleado)
        {
            return dEmpleados.ModificarEmpleado(cEmpleado);
        }

        public string EliminarEmpleado(string codigo)
        {
            return dEmpleados.EliminarEmpleado(codigo);
        }

        public List<CEmpleado> ListarEmpleadosPorSucursal(string codigoSucursal)
        {
            return dEmpleados.ListarEmpleadosPorSucursal(codigoSucursal);
        }
    }
}
