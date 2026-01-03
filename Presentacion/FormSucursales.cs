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
    public partial class FormSucursales : Form
    {
        private NSucursales nSucursales = new NSucursales();
        public FormSucursales()
        {
            InitializeComponent();
            MostrarSucursales(nSucursales.ListarSucursales());
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
        private void LimpiarCampos()
        {
            txtCodigoSucursal.Text = "";
            txtNombreSucursal.Text = "";
            txtDireccionSucursal.Text = "";
            txtCorreoSucursal.Text = "";
            cbEstadoSucursal.Text = "";
        }

        private void btnRegistrarSucursal_Click(object sender, EventArgs e)
        {
            if (txtCodigoSucursal.Text.Trim() == "" || txtNombreSucursal.Text.Trim() == "" || txtDireccionSucursal.Text.Trim() == "" || txtCorreoSucursal.Text.Trim() == "" || cbEstadoSucursal.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese todos los campos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCodigoSucursal.Text.Trim().StartsWith("SUC"))
            {
                MessageBox.Show("El código de la sucursal debe empezar con 'SUC'", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCodigoSucursal.Text.Trim().Length != 6)
            {
                MessageBox.Show("El código de la sucursal debe tener exactamente 6 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombreSucursal.Text.Trim().Length < 8)
            {
                MessageBox.Show("El nombre de la sucursal debe tener al menos 8 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nombre de la sucursal

            string sucursalOriginal = txtNombreSucursal.Text.Trim();
            string[] palabras = sucursalOriginal.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1).ToLower();
            }

            txtNombreSucursal.Text = string.Join(" ", palabras);

            //Direccion de la sucursal
            string direccion = txtDireccionSucursal.Text.Trim();

            string[] dic = direccion.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < dic.Length; i++)
            {
                dic[i] = char.ToUpper(dic[i][0]) + dic[i].Substring(1).ToLower();
            }

            direccion = string.Join(" ", dic);

            if (!string.IsNullOrWhiteSpace(direccion))
            {
                direccion = char.ToUpper(direccion[0]) + direccion.Substring(1);
            }

            txtDireccionSucursal.Text = string.Join(" ", dic);


            if (txtNombreSucursal.Text.Trim().Any(c => char.IsDigit(c)))
            {
                MessageBox.Show("El nombre de la sucursal no debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDireccionSucursal.Text.Trim().Length < 10)
            {
                MessageBox.Show("La dirección de la sucursal debe tener al menos 10 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreoSucursal.Text.Trim().Length < 10)
            {
                MessageBox.Show("El correo de la sucursal debe tener al menos 10 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreoSucursal.Text.Trim().Contains("@"))
            {
                MessageBox.Show("El correo de la sucursal debe contener un @", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreoSucursal.Text.Trim().Contains("."))
            {
                MessageBox.Show("El correo de la sucursal debe contener un .", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreoSucursal.Text.Trim().Contains(" "))
            {
                MessageBox.Show("El correo de la sucursal no debe contener espacios", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbEstadoSucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado válido", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbEstadoSucursal.Text.Trim() != "Activo" && cbEstadoSucursal.Text.Trim() != "Inactivo")
            {
                MessageBox.Show("Seleccione un estado válido (Activo o Inactivo)", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nSucursales.ExisteSucursal(txtCodigoSucursal.Text.Trim()))
            {
                MessageBox.Show("Ya existe una sucursal con ese código", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSucursal cSucursal = new CSucursal()
            {
                Codigo = txtCodigoSucursal.Text,
                Nombre = txtNombreSucursal.Text,
                Direccion = txtDireccionSucursal.Text,
                Correo = txtCorreoSucursal.Text,
                Estado = cbEstadoSucursal.Text
            };

            var resultado = nSucursales.RegistrarSucursal(cSucursal);
            if (resultado == "Sucursal registrada correctamente")
            {
                MessageBox.Show("Sucursal registrada correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                MostrarSucursales(nSucursales.ListarSucursales());
            }
            else
            {
                MessageBox.Show("Error al registrar la sucursal: " + resultado, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSucursal_Click(object sender, EventArgs e)
        {
            if (dgSucursal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una sucursal para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSucursal cSucursal = dgSucursal.SelectedRows[0].DataBoundItem as CSucursal;
            if (cSucursal == null) return;

            if (!string.IsNullOrWhiteSpace(txtCodigoSucursal.Text)) cSucursal.Codigo = txtCodigoSucursal.Text;
            if (!string.IsNullOrWhiteSpace(txtNombreSucursal.Text)) cSucursal.Nombre = txtNombreSucursal.Text;
            if (!string.IsNullOrWhiteSpace(txtDireccionSucursal.Text)) cSucursal.Direccion = txtDireccionSucursal.Text;
            if (!string.IsNullOrWhiteSpace(txtCorreoSucursal.Text)) cSucursal.Correo = txtCorreoSucursal.Text;
            if (!string.IsNullOrWhiteSpace(cbEstadoSucursal.Text)) cSucursal.Estado = cbEstadoSucursal.Text;

            var resultado = nSucursales.ModificarSucursal(cSucursal);

            MostrarSucursales(nSucursales.ListarSucursales());

            MessageBox.Show("Sucursal modificada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            txtCodigoSucursal.Enabled = true;
        }

        private void btnEliminarSucursal_Click(object sender, EventArgs e)
        {
            if (dgSucursal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una sucursal para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSucursal cSucursal = dgSucursal.SelectedRows[0].DataBoundItem as CSucursal;
            if (cSucursal == null) return;
            if (MessageBox.Show($"¿Está seguro de que desea eliminar la sucursal {cSucursal.Codigo}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                nSucursales.EliminarSucursalFisico(cSucursal.Codigo);
                MostrarSucursales(nSucursales.ListarSucursales());
                MessageBox.Show("Sucursal eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eliminación cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSalirSucursal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresarSupervisor_Click(object sender, EventArgs e)
        {
            if (dgSucursal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una sucursal para ingresar supervisores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSucursal sucursalSeleccionada = dgSucursal.SelectedRows[0].DataBoundItem as CSucursal;
            if (sucursalSeleccionada == null)
            {
                MessageBox.Show("Seleccione una sucursal válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormSupervisores formSupervisores = new FormSupervisores(sucursalSeleccionada.Codigo);
            formSupervisores.Show();
        }

        private void btnIngresarEmpleados_Click(object sender, EventArgs e)
        {
            if (dgSucursal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una sucursal para ingresar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSucursal sucursalSeleccionada = dgSucursal.SelectedRows[0].DataBoundItem as CSucursal;
            if (sucursalSeleccionada == null)
            {
                MessageBox.Show("Seleccione una sucursal válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormEmpleados formEmpleados = new FormEmpleados(sucursalSeleccionada.Codigo);
            formEmpleados.Show();
        }

        private void btnIngresarProducto_Click(object sender, EventArgs e)
        {
            if (dgSucursal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una sucursal para ingresar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSucursal sucursalSeleccionada = dgSucursal.SelectedRows[0].DataBoundItem as CSucursal;
            if (sucursalSeleccionada == null)
            {
                MessageBox.Show("Seleccione una sucursal válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormProductos formProductos = new FormProductos(sucursalSeleccionada.Codigo);
            formProductos.Show();
        }
    }
}
