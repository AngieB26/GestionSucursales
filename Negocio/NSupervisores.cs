using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NSupervisores
    {
        private DSupervisores dSupervisores = new DSupervisores();
        public bool ExisteSupervisor(string codigo)
        {
            return dSupervisores.ExisteSupervisor(codigo);
        }
        public string RegistrarSupervisor(CSupervisor cSupervisor, string codigoSucursal)
        {
            return dSupervisores.RegistrarSupervisor(cSupervisor, codigoSucursal);
        }
        public string ModificarSupervisor(CSupervisor cSupervisor)
        {
            return dSupervisores.ModificarSupervisor(cSupervisor);
        }
        public string EliminarSupervisor(string codigo)
        {
            return dSupervisores.EliminarSupervisorFisico(codigo);
        }
        public List<CSupervisor> ListarSupervisoresPorSucursal(string codigoSucursal)
        {
            return dSupervisores.ListarSupervisoresPorSucursal(codigoSucursal);
        }
        public List<CSupervisor> ListarSupervisoresPorSucursalSeleccionada(string codigoSucursal)
        {
            return dSupervisores.ListarSupervisoresPorSucursalSeleccionada(codigoSucursal);
        }
    }
}
