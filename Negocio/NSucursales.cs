using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NSucursales
    {
        private DSucursales dSucursales = new DSucursales();

        public bool ExisteSucursal(string codigo)
        {
            return dSucursales.ExisteSucursal(codigo);
        }

        public string RegistrarSucursal(CSucursal cSucursal)
        {
            return dSucursales.RegistrarSucursal(cSucursal);
        }

        public String ModificarSucursal(CSucursal cSucursal)
        {
            return dSucursales.ModificarSucursal(cSucursal);
        }

        public String EliminarSucursalFisico(string codigo)
        {
            return dSucursales.EliminarSucursalFisico(codigo);
        }

        public List<CSucursal> ListarSucursales()
        {
            return dSucursales.ListarSucursales();
        }
        public List<CSucursal> ListarStockCriticodeProductosPorSucursales()
        {
            return dSucursales.ListarStockCriticodeProductosPorSucursales();
        }
    }
}
