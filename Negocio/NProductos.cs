using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NProductos
    {
        private DProductos dProductos = new DProductos();

        public bool ExisteProducto(string codigo)
        {
            return dProductos.ExisteProducto(codigo);
        }

        public string RegistrarProducto(CProducto cProducto, string codigoSucursal, string codigoProveedor)
        {
            return dProductos.RegistrarProducto(cProducto, codigoSucursal, codigoProveedor);
        }

        public string ModificarProducto(CProducto cProducto)
        {
            return dProductos.ModificarProducto(cProducto);
        }

        public string EliminarProducto(string codigo)
        {
            return dProductos.EliminarProducto(codigo);
        }

        public List<CProducto> ListarProductosPorSucursal(string codigoSucursal)
        {
            return dProductos.ListarProductosPorSucursal(codigoSucursal);
        }
        public List<CProducto> ListarProductosPorSucursalPorNombre(string nombre)
        {
            return dProductos.ListarProductosPorSucursalPorNombre(nombre);
        }
        public List<CProducto> ListarProductosPorCategoria(string categoria)
        {
            return dProductos.ListarProductosPorCategoria(categoria);
        }
    }
}
