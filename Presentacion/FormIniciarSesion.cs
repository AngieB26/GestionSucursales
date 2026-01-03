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
    public partial class FormIniciarSesion : Form
    {
        private NUsuarioIniciarSesion nUsuarioIniciarSesion = new NUsuarioIniciarSesion();
        public FormIniciarSesion()
        {
            InitializeComponent();
            txtIngresarContraseña.PasswordChar = '*';
        }

        private void btnIniciarSesionUsuario_Click(object sender, EventArgs e)
        {

            long rucLong;
            if (!long.TryParse(txtIngresarRuc.Text.Trim(), out rucLong))
            {
                MessageBox.Show("El RUC ingresado no es válido numéricamente", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contraseña = txtIngresarContraseña.Text.Trim();

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Ingrese la contraseña", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nUsuarioIniciarSesion.ExisteRuc(rucLong))
            {
                CUsuario cUsuario = nUsuarioIniciarSesion.ObtenerUsuario(rucLong, contraseña);
                if (cUsuario == null || cUsuario.Contrasena != txtIngresarContraseña.Text)
                {
                    MessageBox.Show("Contraseña Incorrecta", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    FormMenu formMenu = new FormMenu();
                    formMenu.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnSalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
