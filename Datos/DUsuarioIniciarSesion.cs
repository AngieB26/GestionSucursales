using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuarioIniciarSesion
    {
        public bool IniciarSesion(long ruc, string contraseña)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CUsuario.Any(u => u.Ruc.Equals(ruc) && u.Contrasena.Equals(contraseña));
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public CUsuario ObtenerUsuario(long ruc, string contraseña)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CUsuario.FirstOrDefault(u => u.Ruc.Equals(ruc) && u.Contrasena.Equals(contraseña));
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ExisteRuc(long ruc)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CUsuario.Any(u => u.Ruc.Equals(ruc));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
