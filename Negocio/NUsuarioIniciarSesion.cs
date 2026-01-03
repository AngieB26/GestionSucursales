using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NUsuarioIniciarSesion
    {
        private DUsuarioIniciarSesion dUsuarioIniciarSesion = new DUsuarioIniciarSesion();

        public bool IniciarSesion(long ruc, string contraseña)
        {
            return dUsuarioIniciarSesion.IniciarSesion(ruc, contraseña);
        }

        public CUsuario ObtenerUsuario(long ruc, string contraseña)
        {
            return dUsuarioIniciarSesion.ObtenerUsuario(ruc, contraseña);
        }

        public bool ExisteRuc(long ruc)
        {
            return dUsuarioIniciarSesion.ExisteRuc(ruc);
        }
    }
}
