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
    public partial class FormSupervisores : Form
    {
        private string sucursalSeleccionada;
        private NSupervisores nSupervisores = new NSupervisores();

        public FormSupervisores(string codigoSucursal)
        {
            InitializeComponent();
            sucursalSeleccionada = codigoSucursal;
            CargarYMostrarSupervisores();
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

                dgSupervisor.DefaultCellStyle.ForeColor = Color.Black;
                dgSupervisor.DefaultCellStyle.BackColor = Color.White;

                dgSupervisor.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                dgSupervisor.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
        }

        private void CargarYMostrarSupervisores()
        {
            try
            {
                List<CSupervisor> supervisores = nSupervisores.ListarSupervisoresPorSucursal(sucursalSeleccionada);
                MostrarSupervisores(supervisores);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los supervisores: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoSupervisor.Clear();
            txtNombreSupervisor.Clear();
            txtTelefonoSupervisor.Clear();
            txtCorreoSupervisor.Clear();
            dtFechaIngresoSupervisor.Value = DateTime.Now;
        }

        private void btnRegistrarSupervisor_Click(object sender, EventArgs e)
        {
            if (txtCodigoSupervisor.Text.Trim() == "" || txtNombreSupervisor.Text.Trim() == "" || txtTelefonoSupervisor.Text.Trim() == "" || txtCorreoSupervisor.Text.Trim() == "" || dtFechaIngresoSupervisor.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese todos los campos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCodigoSupervisor.Text.Trim().StartsWith("SUP"))
            {
                MessageBox.Show("El código de la sucursal debe empezar con 'SUP'", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCodigoSupervisor.Text.Trim().Length < 6)
            {
                MessageBox.Show("El código del supervisor debe tener al menos 6 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombreSupervisor.Text.Trim().Length < 8)
            {
                MessageBox.Show("El nombre del supervisor debe tener al menos 8 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtNombreSupervisor.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Ingrese el nombre completo del supervisor (nombre y apellidos)", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nombre del supervisor

            string nombreOriginal = txtNombreSupervisor.Text.Trim();
            string[] palabras = nombreOriginal.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1).ToLower();
            }

            txtNombreSupervisor.Text = string.Join(" ", palabras);


            if (txtNombreSupervisor.Text.Trim().Any(c => char.IsDigit(c)))
            {
                MessageBox.Show("El nombre del supervisor no debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTelefonoSupervisor.Text.Trim().Length != 9)
            {
                MessageBox.Show("El teléfono del supervisor debe tener exactamente 9 dígitos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtTelefonoSupervisor.Text.Trim().StartsWith("9"))
            {
                MessageBox.Show("El teléfono debe comenzar con 9", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTelefonoSupervisor.Text.Trim().Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("El teléfono del supervisor solo debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreoSupervisor.Text.Trim().Length < 10)
            {
                MessageBox.Show("El correo del supervisor debe tener al menos 10 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreoSupervisor.Text.Trim().Contains("@"))
            {
                MessageBox.Show("El correo del supervisor debe contener un @", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreoSupervisor.Text.Trim().Contains("."))
            {
                MessageBox.Show("El correo del supervisor debe contener un .", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreoSupervisor.Text.Trim().Contains(" "))
            {
                MessageBox.Show("El correo del supervisor no debe contener espacios", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtFechaIngresoSupervisor.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de ingreso no puede ser mayor a la fecha actual", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSupervisor cSupervisor = new CSupervisor()
            {
                Codigo = txtCodigoSupervisor.Text,
                Nombre = txtNombreSupervisor.Text,
                Telefono = int.Parse(txtTelefonoSupervisor.Text),
                Correo = txtCorreoSupervisor.Text,
                Fecha_ingreso = dtFechaIngresoSupervisor.Value.Date,
            };

            var resultado = nSupervisores.RegistrarSupervisor(cSupervisor, sucursalSeleccionada);   

            if (resultado == "Supervisor registrado correctamente")
            {
                MessageBox.Show("Supervisor registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarYMostrarSupervisores();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("El supervisor ya existe", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSupervisor_Click(object sender, EventArgs e)
        {
            if (dgSupervisor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un supervisor para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSupervisor cSupervisor = dgSupervisor.SelectedRows[0].DataBoundItem as CSupervisor;
            if (cSupervisor == null) return;

            if (!string.IsNullOrWhiteSpace(txtCodigoSupervisor.Text)) cSupervisor.Codigo = txtCodigoSupervisor.Text;
            if (!string.IsNullOrWhiteSpace(txtNombreSupervisor.Text)) cSupervisor.Nombre = txtNombreSupervisor.Text;
            if (int.TryParse(txtTelefonoSupervisor.Text, out int telefono)) cSupervisor.Telefono = int.Parse(txtTelefonoSupervisor.Text);    
            if (!string.IsNullOrWhiteSpace(txtCorreoSupervisor.Text)) cSupervisor.Correo = txtCorreoSupervisor.Text;

            var resultado = nSupervisores.ModificarSupervisor(cSupervisor);

            CargarYMostrarSupervisores();

            MessageBox.Show("Supervisor modificada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            txtCodigoSupervisor.Enabled = true;
        }

        private void btnEliminarSupervisor_Click(object sender, EventArgs e)
        {
            if (dgSupervisor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un supervisor para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSupervisor cSupervisor = dgSupervisor.SelectedRows[0].DataBoundItem as CSupervisor;
            if (cSupervisor == null) return;
            if (MessageBox.Show($"¿Está seguro de que desea eliminar el supervisor {cSupervisor.Codigo}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                nSupervisores.EliminarSupervisor(cSupervisor.Codigo);
                CargarYMostrarSupervisores();
                MessageBox.Show("Supervisor eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Eliminación cancelada", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalirSupervisor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
