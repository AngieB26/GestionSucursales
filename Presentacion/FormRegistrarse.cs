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
    public partial class FormRegistrarse : Form
    {
        private NUsuarioRegistrar nUsuarioRegistrar = new NUsuarioRegistrar();
        public FormRegistrarse()
        {
            InitializeComponent();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text == "" || txtNombreUsuario.Text == "" || cbRolUsuario.Text == "" || txtContraseña.Text == "" || txtConfirmarContraseña.Text == "" || txtCorreo.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtRuc.Text.Length != 11)
            {
                MessageBox.Show("El RUC debe tener 11 dígitos", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtRuc.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("El RUC solo debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombreUsuario.Text.Any(c => char.IsDigit(c)))
            {
                MessageBox.Show("El Nombre no debe contener números", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNombreUsuario.Text.Length < 5)
            {
                MessageBox.Show("El Nombre debe tener al menos 5 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MessageBox.Show("Ingrese un correo electrónico válido", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCorreo.Text.Length < 5)
            {
                MessageBox.Show("El Correo debe tener al menos 5 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtCorreo.Text.EndsWith(".com") && !txtCorreo.Text.EndsWith(".org") && !txtCorreo.Text.EndsWith(".net"))
            {
                MessageBox.Show("El Correo debe terminar en .com, .org o .net", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbRolUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol válido", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtContraseña.Text.Length < 8)
            {
                MessageBox.Show("La Contraseña debe tener al menos 8 caracteres", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtContraseña.Text.All(c => !char.IsDigit(c)))
            {
                MessageBox.Show("La Contraseña debe contener al menos un número", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long ruc;
            if (!long.TryParse(txtRuc.Text, out ruc))
            {
                MessageBox.Show("El RUC debe ser un número válido", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nUsuarioRegistrar.ExisteUsuario(ruc))
            {
                MessageBox.Show("El RUC ya está registrado", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CUsuario usuario = new CUsuario()
            {
                Ruc = ruc,
                Nombre = txtNombreUsuario.Text,
                Correo = txtCorreo.Text,
                Contrasena = txtContraseña.Text,
                Rol = cbRolUsuario.Text,
                FechaRegistro = DateTime.Now
            };

            string resultado = nUsuarioRegistrar.RegistrarUsuario(usuario);
            if (resultado == "Usuario registrado correctamente")
            {
                MessageBox.Show("Usuario registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al registrar usuario: " + resultado, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirRegistrarUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
