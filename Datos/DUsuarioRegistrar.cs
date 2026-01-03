using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuarioRegistrar
    {
        public string RegistrarUsuario(CUsuario cUsuario)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.CUsuario.Add(cUsuario);
                    context.SaveChanges();
                }
                return "Usuario registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool ExisteUsuario(long ruc)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CUsuario.Any(u => u.Ruc == ruc);
                }
            }
            catch (Exception ex)
            { 
                return false;
            }
        }
    }
}
