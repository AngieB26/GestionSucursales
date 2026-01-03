using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FormProductos : Form
    {
        private string sucursalSeleccionada;
        private NProductos nProductos = new NProductos();
        private List<CProducto> productosActuales = new List<CProducto>();

        public FormProductos(string codigoSucursal)
        {
            InitializeComponent();
            sucursalSeleccionada = codigoSucursal;
            CargarProveedores();
            CargarYMostrarProductos();
        }

        public void MostrarProductos(List<CProducto> cProductos)
        {
            dgProducto.DataSource = null;
            productosActuales = cProductos; // Guardar los productos reales

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

        private void CargarProveedores()
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    var proveedores = context.CProveedor
                        .Select(p => new { p.Codigo, p.Nombre })
                        .ToList();

                    if (proveedores.Count == 0)
                    {
                        MessageBox.Show("No hay proveedores registrados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbProveedorProducto.DataSource = null;
                        return;
                    }

                    cbProveedorProducto.DataSource = proveedores;
                    cbProveedorProducto.DisplayMember = "Nombre";
                    cbProveedorProducto.ValueMember = "Codigo";
                    cbProveedorProducto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarYMostrarProductos()
        {
            try
            {
                List<CProducto> productos = nProductos.ListarProductosPorSucursal(sucursalSeleccionada);
                MostrarProductos(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoProducto.Clear();
            txtNombreProducto.Clear();
            txtStockProducto.Clear();
            cbCategoríaProducto.SelectedIndex = -1;
            txtPrecioProducto.Clear();
            cbOfertaProducto.SelectedIndex = -1;
            cbProveedorProducto.SelectedIndex = -1;
        }

        private CProducto ObtenerProductoSeleccionado()
        {
            if (dgProducto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            int selectedIndex = dgProducto.SelectedRows[0].Index;

            if (selectedIndex >= 0 && selectedIndex < productosActuales.Count)
            {
                return productosActuales[selectedIndex];
            }

            MessageBox.Show("Error al obtener el producto seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Trim() == "" || txtNombreProducto.Text.Trim() == "" || cbOfertaProducto.SelectedIndex == -1 || txtStockProducto.Text.Trim() == "" || cbCategoríaProducto.SelectedIndex == -1 || txtPrecioProducto.Text.Trim() == "" || cbProveedorProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese todos los campos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCodigoProducto.Text.Trim().StartsWith("PROD"))
            {
                MessageBox.Show("El código de la sucursal debe empezar con 'PROD'", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCodigoProducto.Text.Trim().Length != 7)
            {
                MessageBox.Show("El código del producto debe tener exactamente 7 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombreProducto.Text.Trim().Length < 5)
            {
                MessageBox.Show("El nombre del producto debe tener al menos 5 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nombre del producto

            string productoOriginal = txtNombreProducto.Text.Trim();
            string[] palabras = productoOriginal.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1).ToLower();
            }

            txtNombreProducto.Text = string.Join(" ", palabras);


            if (cbCategoríaProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría para el producto", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbOfertaProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar si el producto está en oferta", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbProveedorProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int stock = 0;
            try
            {
                stock = int.Parse(txtStockProducto.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese los campos numéricos correctamente");
                return;
            }

            Decimal precio = 0;
            try
            {
                precio = Decimal.Parse(txtPrecioProducto.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese los campos numéricos correctamente");
                return;
            }

            CProducto cProducto = new CProducto()
            {
                Codigo = txtCodigoProducto.Text,
                Nombre = txtNombreProducto.Text,
                Stock = stock,
                Precio = precio,
                Categoria = cbCategoríaProducto.Text,
                Oferta = cbOfertaProducto.Text.ToLower() == "true" || cbOfertaProducto.Text.ToLower() == "sí" || cbOfertaProducto.Text.ToLower() == "si",
            };

            string codigoProveedor = cbProveedorProducto.SelectedValue.ToString();

            var resultado = nProductos.RegistrarProducto(cProducto, sucursalSeleccionada, codigoProveedor);
            if (resultado == "Producto registrado correctamente")
            {
                MessageBox.Show("Producto registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarYMostrarProductos();
            }
            else
            {
                MessageBox.Show(resultado, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            CProducto cProducto = ObtenerProductoSeleccionado();
            if (cProducto == null) return;

            // Crear un nuevo objeto con los datos del formulario
            CProducto productoModificado = new CProducto()
            {
                Codigo = cProducto.Codigo, // Mantener el código original
                Nombre = !string.IsNullOrWhiteSpace(txtNombreProducto.Text) ? txtNombreProducto.Text : cProducto.Nombre,
                Stock = int.TryParse(txtStockProducto.Text, out int stock) ? stock : cProducto.Stock,
                Precio = decimal.TryParse(txtPrecioProducto.Text, out decimal precio) ? precio : cProducto.Precio,
                Categoria = !string.IsNullOrWhiteSpace(cbCategoríaProducto.Text) ? cbCategoríaProducto.Text : cProducto.Categoria,
                Oferta = !string.IsNullOrWhiteSpace(cbOfertaProducto.Text) ?
                        (cbOfertaProducto.Text.ToLower() == "true" || cbOfertaProducto.Text.ToLower() == "sí" || cbOfertaProducto.Text.ToLower() == "si") :
                        cProducto.Oferta
            };

            if (cbProveedorProducto.SelectedIndex != -1)
            {
                string codigoProveedor = cbProveedorProducto.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(codigoProveedor))
                {
                    var proveedor = new CProveedor { Codigo = codigoProveedor };
                    productoModificado.CProveedor = new List<CProveedor> { proveedor };
                }
            }
            else
            {
                productoModificado.CProveedor = cProducto.CProveedor;
            }

            var resultado = nProductos.ModificarProducto(productoModificado);

            if (resultado == "Producto modificado correctamente")
            {
                MessageBox.Show("Producto modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarYMostrarProductos();
            }
            else
            {
                MessageBox.Show("Error al modificar el producto: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LimpiarCampos();
            txtCodigoProducto.Enabled = true;
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            CProducto cProducto = ObtenerProductoSeleccionado();
            if (cProducto == null) return;

            if (MessageBox.Show($"¿Está seguro de que desea eliminar el producto {cProducto.Codigo}?",
                               "Confirmar eliminación",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var resultado = nProductos.EliminarProducto(cProducto.Codigo);

                if (resultado == "Producto eliminado correctamente")
                {
                    MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarYMostrarProductos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalirProducto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgProducto_SelectionChanged(object sender, EventArgs e)
        {
            if (dgProducto.SelectedRows.Count > 0)
            {
                CProducto selectedProduct = ObtenerProductoSeleccionado();
                if (selectedProduct != null)
                {
                    txtCodigoProducto.Text = selectedProduct.Codigo;
                    txtNombreProducto.Text = selectedProduct.Nombre;
                    txtStockProducto.Text = selectedProduct.Stock.ToString();
                    txtPrecioProducto.Text = selectedProduct.Precio.ToString();
                    cbCategoríaProducto.Text = selectedProduct.Categoria;
                    cbOfertaProducto.Text = selectedProduct.Oferta ? "Sí" : "No";

                    if (selectedProduct.CProveedor != null && selectedProduct.CProveedor.Any())
                    {
                        var firstSupplier = selectedProduct.CProveedor.First();
                        cbProveedorProducto.SelectedValue = firstSupplier.Codigo;
                    }
                    else
                    {
                        cbProveedorProducto.SelectedIndex = -1;
                    }
                }
            }
        }
    }
}