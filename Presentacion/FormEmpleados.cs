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
    public partial class FormEmpleados : Form
    {
        private string sucursalSeleccionada;
        private NEmpleados nEmpleados = new NEmpleados();
        public FormEmpleados(string codigoSucursal)
        {
            InitializeComponent();
            sucursalSeleccionada = codigoSucursal;
            CargarYMostrarEmpleados();
        }

        public void MostrarEmpleados(List<CEmpleado> cEmpleados)
        {
            dgEmpleado.DataSource = null;
            if (cEmpleados.Count == 0)
            {
                return;
            }
            else
            {
                dgEmpleado.DataSource = cEmpleados;
            }
        }

        private void CargarYMostrarEmpleados()
        {
            try
            {
                List<CEmpleado> empleados = nEmpleados.ListarEmpleadosPorSucursal(sucursalSeleccionada);
                MostrarEmpleados(empleados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoEmpleado.Clear();
            txtNombreEmpleado.Clear();
            txtDniEmpleado.Clear();
            txtTelefonoEmpleado.Clear();
            txtCorreoEmpleado.Clear();
            cbCargoEmpleado.SelectedIndex = -1;
            dtFechaIngresoEmpleado.Value = DateTime.Now;
        }

        private void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            if (txtCodigoEmpleado.Text.Trim() == "" || txtNombreEmpleado.Text.Trim() == "" || txtDniEmpleado.Text.Trim() == "" || txtTelefonoEmpleado.Text.Trim() == "" || txtCorreoEmpleado.Text.Trim() == "" || cbCargoEmpleado.Text.Trim() == "" || dtFechaIngresoEmpleado.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese todos los campos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCodigoEmpleado.Text.Trim().StartsWith("EMP"))
            {
                MessageBox.Show("El código de la sucursal debe empezar con 'EMP'", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCodigoEmpleado.Text.Trim().Length != 6)
            {
                MessageBox.Show("El código debe tener exactamente 6 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombreEmpleado.Text.Trim().Length < 8)
            {
                MessageBox.Show("El nombre del empleado debe tener al menos 8 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtNombreEmpleado.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Ingrese el nombre completo del empleado (nombre y apellidos)", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nombre del empleado

            string empleadoOriginal = txtNombreEmpleado.Text.Trim();
            string[] palabras = empleadoOriginal.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1).ToLower();
            }

            txtNombreEmpleado.Text = string.Join(" ", palabras);

            if (txtNombreEmpleado.Text.Trim().Any(c => char.IsDigit(c)))
            {
                MessageBox.Show("El nombre del empleado no debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDniEmpleado.Text.Trim().Length != 8)
            {
                MessageBox.Show("El DNI debe tener exactamente 8 dígitos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDniEmpleado.Text.Trim().Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("El DNI solo debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTelefonoEmpleado.Text.Trim().Length != 9)
            {
                MessageBox.Show("El teléfono debe tener exactamente 9 dígitos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtTelefonoEmpleado.Text.Trim().StartsWith("9"))
            {
                MessageBox.Show("El teléfono debe comenzar con 9", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTelefonoEmpleado.Text.Trim().Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("El teléfono solo debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreoEmpleado.Text.Trim().Length < 10)
            {
                MessageBox.Show("El correo debe tener al menos 10 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreoEmpleado.Text.Trim().Contains("@"))
            {
                MessageBox.Show("El correo del empleado debe contener un @", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreoEmpleado.Text.Trim().Contains("."))
            {
                MessageBox.Show("El correo del empleado debe contener un .", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreoEmpleado.Text.Trim().Contains(" "))
            {
                MessageBox.Show("El correo del empleado no debe contener espacios", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbCargoEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cargo válido", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtFechaIngresoEmpleado.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de ingreso no puede ser mayor a la fecha actual", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CEmpleado cEmpleado = new CEmpleado()
            {
                Codigo = txtCodigoEmpleado.Text,
                Nombre = txtNombreEmpleado.Text,
                Dni = txtDniEmpleado.Text,
                Telefono = int.Parse(txtTelefonoEmpleado.Text),
                Correo = txtCorreoEmpleado.Text,
                Cargo = cbCargoEmpleado.Text,
                Fecha_ingreso = dtFechaIngresoEmpleado.Value.Date
            };

            var resultado = nEmpleados.RegistrarEmpleado(cEmpleado, sucursalSeleccionada);
            if (resultado == "Empleado registrado correctamente")
            {
                MessageBox.Show("Empleado registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarYMostrarEmpleados();
            }
            else
            {
                MessageBox.Show("El empleado ya existe", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            if (dgEmpleado.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una empleado para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CEmpleado cEmpleado = dgEmpleado.SelectedRows[0].DataBoundItem as CEmpleado;
            if (cEmpleado == null) return;

            if (!string.IsNullOrWhiteSpace(txtCodigoEmpleado.Text)) cEmpleado.Codigo = txtCodigoEmpleado.Text;
            if (!string.IsNullOrWhiteSpace(txtNombreEmpleado.Text)) cEmpleado.Nombre = txtNombreEmpleado.Text;
            if (!string.IsNullOrWhiteSpace(txtDniEmpleado.Text)) cEmpleado.Dni = txtDniEmpleado.Text;
            if (int.TryParse(txtTelefonoEmpleado.Text, out int telefono)) cEmpleado.Telefono = int.Parse(txtTelefonoEmpleado.Text);
            if (!string.IsNullOrWhiteSpace(txtCorreoEmpleado.Text)) cEmpleado.Correo = txtCorreoEmpleado.Text;
            if (!string.IsNullOrWhiteSpace(cbCargoEmpleado.Text)) cEmpleado.Correo = cbCargoEmpleado.Text;

            var resultado = nEmpleados.ModificarEmpleado(cEmpleado);

            CargarYMostrarEmpleados();

            MessageBox.Show("Empleado modificada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            txtCodigoEmpleado.Enabled = true;
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (dgEmpleado.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CEmpleado cEmpleado = dgEmpleado.SelectedRows[0].DataBoundItem as CEmpleado;
            if (cEmpleado == null) return;
            if (MessageBox.Show($"¿Está seguro de que desea eliminar el empleado {cEmpleado.Codigo}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                nEmpleados.EliminarEmpleado(cEmpleado.Codigo);
                CargarYMostrarEmpleados();
                MessageBox.Show("Empleado eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eliminación cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalirEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
