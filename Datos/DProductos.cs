using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DProductos
    {
        public bool ExisteProducto(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CProducto.Any(e => e.Codigo.Equals(codigo));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RegistrarProducto(CProducto cProducto, string codigoSucursal, string codigoProveedor)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    var sucursal = context.CSucursal.Include("CProducto").FirstOrDefault(s => s.Codigo.Equals(codigoSucursal));
                    if (sucursal == null)
                    {
                        return "Sucursal no encontrada.";
                    }

                    var proveedor = context.CProveedor.FirstOrDefault(p => p.Codigo.Equals(codigoProveedor));
                    if (proveedor == null)
                    {
                        return "Proveedor no encontrado.";
                    }

                    cProducto.CSucursal.Add(sucursal);
                    cProducto.CProveedor.Add(proveedor);

                    context.CProducto.Add(cProducto);
                    context.SaveChanges();
                }
                return "Producto registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ModificarProducto(CProducto cProducto)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CProducto productoTemp = context.CProducto.Find(cProducto.Codigo);
                    productoTemp.Nombre = cProducto.Nombre;
                    productoTemp.Stock = cProducto.Stock;
                    productoTemp.Categoria = cProducto.Categoria;
                    productoTemp.Precio = cProducto.Precio;
                    productoTemp.Oferta = cProducto.Oferta;

                    if (cProducto.CProveedor != null && cProducto.CProveedor.Count > 0)
                    {
                        productoTemp.CProveedor.Clear();

                        foreach (var proveedor in cProducto.CProveedor)
                        {
                            var proveedorExistente = context.CProveedor.Find(proveedor.Codigo);
                            if (proveedorExistente != null)
                            {
                                productoTemp.CProveedor.Add(proveedorExistente);
                            }
                        }
                    }
                    context.SaveChanges();
                }
                return "Producto modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarProducto(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CProducto productoTemp = context.CProducto.Find(codigo);

                    if (productoTemp == null)
                    {
                        return "Producto no encontrado";
                    }

                    context.CProducto.Remove(productoTemp);
                    context.SaveChanges();
                }
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<CProducto> ListarProductosPorSucursal(string codigoSucursal)
        {
            List<CProducto> productos = new List<CProducto>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var sucursal = context.CSucursal.Include("CProducto").FirstOrDefault(s => s.Codigo.Equals(codigoSucursal));

                    if (sucursal != null && sucursal.CProducto != null)
                    {
                        productos = context.CProducto.Include("CProveedor").Where(p => p.CSucursal.Any(s => s.Codigo.Equals(codigoSucursal))).ToList();
                    }
                }
                return productos;
            }
            catch (Exception)
            {
                return productos;
            }
        }
        public List<CProducto> ListarProductosPorSucursalPorNombre(string nombre)
        {
            List<CProducto> productosporSucursal = new List<CProducto>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    productosporSucursal = context.CProducto
                        .Include("CSucursal")
                        .Include("CProveedor") 
                        .Where(p => p.CSucursal.Any(s => s.Nombre == nombre))
                        .ToList();
                }
                return productosporSucursal;
            }
            catch (Exception)
            {
                return productosporSucursal;
            }
        }
        public List<CProducto> ListarProductosPorCategoria(string categoria)
        {
            List<CProducto> productosporCategoria = new List<CProducto>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    productosporCategoria = context.CProducto
                        .Include("CProveedor") 
                        .Include("CSucursal")  
                        .Where(p => p.Categoria.Equals(categoria))
                        .ToList();
                }
                return productosporCategoria;
            }
            catch (Exception)
            {
                return productosporCategoria;
            }
        }
    }
}
