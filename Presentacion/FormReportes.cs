using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FormReportes : Form
    {
        private NSucursales nSucursales = new NSucursales();
        private NProductos nProductos = new NProductos();
        private NSupervisores nSupervisores = new NSupervisores();
        private string sucursalSeleccionada;

        public FormReportes()
        {
            InitializeComponent();

        }
        public void MostrarProductos(List<CProducto> cProductos)
        {
            dgProducto.DataSource = null;
            if (cProductos.Count == 0)
            {
                return;
            }
            else
            {
                var productosParaMostrar = cProductos.Select(p => new
                {
                    p.Codigo,
                    p.Nombre,
                    p.Stock,
                    p.Categoria,
                    p.Precio,
                    p.Oferta,
                    Proveedores = p.CProveedor != null && p.CProveedor.Any()
                              ? string.Join(", ", p.CProveedor.Select(prov => prov.Nombre))
                              : "Sin proveedor"
                }).ToList();

                dgProducto.DataSource = productosParaMostrar;
            }
        }
        private void MostrarSucursales(List<CSucursal> cSucursales)
        {
            dgSucursal.DataSource = null;
            if (cSucursales.Count == 0)
            {
                return;
            }
            else
            {
                dgSucursal.DataSource = cSucursales;
            }
        }
        public void MostrarSupervisores(List<CSupervisor> cSupervisor)
        {
            dgSupervisor.DataSource = null;
            if (cSupervisor.Count == 0)
            {
                return;
            }
            else
            {
                dgSupervisor.DataSource = cSupervisor;
            }
        }

        private void btnSupervisoresPorCodigoSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                List<CSucursal> sucursalesStockCritico = nSucursales.ListarStockCriticodeProductosPorSucursales();
                MostrarSucursales(sucursalesStockCritico);

                if (sucursalesStockCritico.Count > 0)
                {
                    MessageBox.Show($"Se encontraron {sucursalesStockCritico.Count} sucursales con productos en stock crítico (≤ 5 unidades).",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar sucursales con stock crítico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnProductosPorSucursal_Click(object sender, EventArgs e)
        {
            string codigoSucursal = txtNombreSucursal.Text.Trim();

            if (string.IsNullOrEmpty(codigoSucursal))
            {
                MessageBox.Show("Por favor ingrese el código de una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DProductos dProductos = new DProductos();
            List<CProducto> productos = dProductos.ListarProductosPorSucursal(codigoSucursal);

            if (productos != null && productos.Count > 0)
            {
               MostrarProductos(productos);
            }
            else
            {
                MessageBox.Show("No se encontraron productos para la sucursal ingresada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProductosPorCategoria_Click(object sender, EventArgs e)
        {
            string categoria = cbCategoríaProducto.Text.Trim();

            if (string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Por favor ingrese una categoría.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productos = nProductos.ListarProductosPorCategoria(categoria);

            if (productos != null && productos.Count > 0)
            {
                MostrarProductos(productos);
            }
            else
            {
                MessageBox.Show("No se encontraron productos para la categoría ingresada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMenosStock_Click(object sender, EventArgs e)
        {
            DSucursales dSucursales = new DSucursales();
            List<CSucursal> sucursalesConStockCritico = dSucursales.ListarStockCriticodeProductosPorSucursales();

            if (sucursalesConStockCritico.Count > 0)
            {
                MostrarSucursales(sucursalesConStockCritico);
            }
            else
            {
                MessageBox.Show("No hay sucursales con productos en stock crítico.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSupervisoresPorCodigoSucursal_Click_1(object sender, EventArgs e)
        {
            string codigoSucursal = txtCodigoSucursal.Text.Trim();

            if (string.IsNullOrEmpty(codigoSucursal))
            {
                MessageBox.Show("Por favor ingrese el código de una sucursal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DSupervisores dSupervisores = new DSupervisores();
            List<CSupervisor> supervisores = dSupervisores.ListarSupervisoresPorSucursalSeleccionada(codigoSucursal);

            if (supervisores != null && supervisores.Count > 0)
            {
                MostrarSupervisores(supervisores);
            }
            else
            {
                MessageBox.Show("No se encontraron supervisores para la sucursal ingresada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
