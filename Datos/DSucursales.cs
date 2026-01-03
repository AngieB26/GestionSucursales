using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DSucursales
    {
        public bool ExisteSucursal(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CSucursal.Any(s => s.Codigo.Equals(codigo));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RegistrarSucursal(CSucursal cSucursal)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.CSucursal.Add(cSucursal);
                    context.SaveChanges();
                }
                return "Sucursal registrada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String ModificarSucursal(CSucursal cSucursal)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CSucursal sucursalTemp = context.CSucursal.Find(cSucursal.Codigo);
                    sucursalTemp.Nombre = cSucursal.Nombre;
                    sucursalTemp.Direccion = cSucursal.Direccion;
                    sucursalTemp.Correo = cSucursal.Correo;
                    sucursalTemp.Estado = cSucursal.Estado;
                    context.SaveChanges();
                }
                return "Sucursal modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String EliminarSucursalFisico(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CSucursal sucursalTemp = context.CSucursal.Find(codigo);
                    context.CSucursal.Remove(sucursalTemp);
                    context.SaveChanges();
                }
                return "Sucursal eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<CSucursal> ListarSucursales()
        {
            List<CSucursal> cSucursales = new List<CSucursal>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cSucursales = context.CSucursal.ToList();
                }
                return cSucursales;
            }
            catch (Exception)
            {
                return cSucursales;
            }
        }
        public List<CSucursal> ListarStockCriticodeProductosPorSucursales()
        {
            List<CSucursal> cSucursalestockCritico = new List<CSucursal>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cSucursalestockCritico = context.CSucursal.Include("CProducto")
                        .Where(s => s.CProducto.Any(p => p.Stock <= 5)).ToList();
                }
                return cSucursalestockCritico;
            }
            catch (Exception)
            {
                return cSucursalestockCritico;
            }

        }
    }
}
