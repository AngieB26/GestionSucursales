using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public void MostrarSupervisores(List<CSupervisor> supervisores)
        {
            dgSupervisor.DataSource = null;

            if (supervisores.Count == 0)
                return;

            dgSupervisor.DataSource = supervisores;

            dgSupervisor.DefaultCellStyle.ForeColor = Color.Black;
            dgSupervisor.DefaultCellStyle.BackColor = Color.White;

            dgSupervisor.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgSupervisor.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private void CargarYMostrarSupervisores()
        {
            try
            {
                List<CSupervisor> supervisores =
                    nSupervisores.ListarSupervisoresPorSucursal(sucursalSeleccionada);

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
            txtCodigoSupervisor.Enabled = true;
        }

        private void btnRegistrarSupervisor_Click(object sender, EventArgs e)
        {
            if (txtCodigoSupervisor.Text.Trim() == "" ||
                txtNombreSupervisor.Text.Trim() == "" ||
                txtTelefonoSupervisor.Text.Trim() == "" ||
                txtCorreoSupervisor.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese todos los campos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtCodigoSupervisor.Text.StartsWith("SUP"))
            {
                MessageBox.Show("El código debe iniciar con SUP", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCodigoSupervisor.Text.Length < 6)
            {
                MessageBox.Show("El código debe tener al menos 6 caracteres", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNombreSupervisor.Text.Length < 8 || !txtNombreSupervisor.Text.Contains(" "))
            {
                MessageBox.Show("Ingrese el nombre completo del supervisor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNombreSupervisor.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no debe contener números", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtTelefonoSupervisor.Text.Length != 9 ||
                !txtTelefonoSupervisor.Text.StartsWith("9") ||
                txtTelefonoSupervisor.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Teléfono inválido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtCorreoSupervisor.Text.Contains("@") ||
                !txtCorreoSupervisor.Text.Contains(".") ||
                txtCorreoSupervisor.Text.Contains(" "))
            {
                MessageBox.Show("Correo inválido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtFechaIngresoSupervisor.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha no puede ser mayor a hoy", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSupervisor cSupervisor = new CSupervisor()
            {
                Codigo = txtCodigoSupervisor.Text.Trim(),
                Nombre = txtNombreSupervisor.Text.Trim(),
                Telefono = int.Parse(txtTelefonoSupervisor.Text),
                Correo = txtCorreoSupervisor.Text.Trim(),
                Fecha_ingreso = dtFechaIngresoSupervisor.Value.Date
            };

            string resultado =
                nSupervisores.RegistrarSupervisor(cSupervisor, sucursalSeleccionada);

            if (resultado == "Supervisor registrado correctamente.")
            {
                MessageBox.Show("Supervisor registrado correctamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarYMostrarSupervisores();
                LimpiarCampos();
            }
            else if (resultado.StartsWith("Supervisor existe"))
            {
                // Supervisor existe|CODIGO|SUCURSAL
                string[] datos = resultado.Split('|');

                string codigo = datos.Length > 1 ? datos[1] : "Desconocido";
                string sucursal = datos.Length > 2 ? datos[2] : "Sin sucursal";

                MessageBox.Show(
                    $"El supervisor {codigo} ya existe y pertenece a la sucursal {sucursal}.",
                    "Supervisor existente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show("Error: " + resultado,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSupervisor_Click(object sender, EventArgs e)
        {
            if (dgSupervisor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un supervisor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSupervisor cSupervisor =
                dgSupervisor.SelectedRows[0].DataBoundItem as CSupervisor;

            if (cSupervisor == null) return;

            cSupervisor.Nombre = txtNombreSupervisor.Text;
            cSupervisor.Telefono = int.Parse(txtTelefonoSupervisor.Text);
            cSupervisor.Correo = txtCorreoSupervisor.Text;
            cSupervisor.Fecha_ingreso = dtFechaIngresoSupervisor.Value;

            nSupervisores.ModificarSupervisor(cSupervisor);

            CargarYMostrarSupervisores();
            LimpiarCampos();

            MessageBox.Show("Supervisor modificado correctamente",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminarSupervisor_Click(object sender, EventArgs e)
        {
            if (dgSupervisor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un supervisor", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CSupervisor cSupervisor =
                dgSupervisor.SelectedRows[0].DataBoundItem as CSupervisor;

            if (cSupervisor == null) return;

            if (MessageBox.Show(
                $"¿Eliminar supervisor {cSupervisor.Codigo}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                nSupervisores.EliminarSupervisor(cSupervisor.Codigo);
                CargarYMostrarSupervisores();

                MessageBox.Show("Supervisor eliminado correctamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalirSupervisor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
