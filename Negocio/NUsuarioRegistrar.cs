using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NUsuarioRegistrar
    {
        private DUsuarioRegistrar dUsuario = new DUsuarioRegistrar();

        public string RegistrarUsuario(CUsuario cUsuario)
        {
            return dUsuario.RegistrarUsuario(cUsuario);
        }

        public bool ExisteUsuario(long ruc)
        {
            return dUsuario.ExisteUsuario(ruc);
        }
    }
}
