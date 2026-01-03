using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DSupervisores
    {
        public bool ExisteSupervisor(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CSupervisor.Any(s => s.Codigo.Equals(codigo));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RegistrarSupervisor(CSupervisor cSupervisor, string codigoSucursal)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    var sucursal = context.CSucursal.Include("CSupervisor").FirstOrDefault(s => s.Codigo.Equals(codigoSucursal));

                    if (sucursal == null)
                    {
                        return "Sucursal no encontrada.";
                    }

                    context.CSupervisor.Add(cSupervisor);
                    sucursal.CSupervisor.Add(cSupervisor);
                    context.SaveChanges();
                }
                return "Supervisor registrado correctamente.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ModificarSupervisor(CSupervisor cSupervisor)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CSupervisor supervisorTemp = context.CSupervisor.Find(cSupervisor.Codigo);
                    supervisorTemp.Nombre = cSupervisor.Nombre;
                    supervisorTemp.Telefono = cSupervisor.Telefono;
                    supervisorTemp.Correo = cSupervisor.Correo;
                    supervisorTemp.Fecha_ingreso = cSupervisor.Fecha_ingreso;
                    context.SaveChanges();
                }
                return "Supervisor modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarSupervisorFisico(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CSupervisor supervisorTemp = context.CSupervisor.Find(codigo);
                    context.CSupervisor.Remove(supervisorTemp);
                    context.SaveChanges();
                }
                return "Supervisor eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<CSupervisor> ListarSupervisoresPorSucursal(string codigoSucursal)
        {
            List<CSupervisor> supervisores = new List<CSupervisor>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var sucursal = context.CSucursal
                        .Include("CSupervisor")
                        .FirstOrDefault(s => s.Codigo.Equals(codigoSucursal));

                    if (sucursal != null && sucursal.CSupervisor != null)
                    {
                        supervisores = sucursal.CSupervisor.ToList();
                    }
                }
                return supervisores;
            }
            catch (Exception)
            {
                return supervisores;
            }
        }
        public List<CSupervisor> ListarSupervisoresPorSucursalSeleccionada(string codigoSucursal)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;

                    var resultado = context.CSupervisor
                                           .Include("CSucursal")
                                           .Where(s => s.CSucursal.Any(su => su.Codigo == codigoSucursal))
                                           .ToList();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar supervisores: " + ex.Message);
                return new List<CSupervisor>();
            }
        }

    }
}
