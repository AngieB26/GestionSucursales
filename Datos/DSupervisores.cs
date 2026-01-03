using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 

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
                    return context.CSupervisor.Any(s => s.Codigo == codigo);
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
                    var supervisorExistente = context.CSupervisor
                        .Include(s => s.CSucursal)
                        .FirstOrDefault(s => s.Codigo == cSupervisor.Codigo);

                    if (supervisorExistente != null)
                    {
                        string sucursalCodigo = supervisorExistente.CSucursal
                            .FirstOrDefault()?.Codigo ?? "Sin sucursal";

                        return $"Supervisor existe|{supervisorExistente.Codigo}|{sucursalCodigo}";
                    }

                    var sucursal = context.CSucursal
                        .Include(s => s.CSupervisor)
                        .FirstOrDefault(s => s.Codigo == codigoSucursal);

                    if (sucursal == null)
                    {
                        return "Sucursal no encontrada";
                    }

                    context.CSupervisor.Add(cSupervisor);
                    sucursal.CSupervisor.Add(cSupervisor);
                    context.SaveChanges();

                    return "Supervisor registrado correctamente.";
                }
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
                    var supervisorTemp = context.CSupervisor.Find(cSupervisor.Codigo);

                    if (supervisorTemp == null)
                    {
                        return "Supervisor no encontrado";
                    }

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
                    var supervisorTemp = context.CSupervisor.Find(codigo);

                    if (supervisorTemp == null)
                    {
                        return "Supervisor no encontrado";
                    }

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
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;

                    return context.CSupervisor
                        .Where(s => s.CSucursal.Any(su => su.Codigo == codigoSucursal))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar supervisores: " + ex.Message);
                return new List<CSupervisor>();
            }
        }

        public List<CSupervisor> ListarSupervisoresPorSucursalSeleccionada(string codigoSucursal)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;

                    return context.CSupervisor
                        .Include(s => s.CSucursal)
                        .Where(s => s.CSucursal.Any(su => su.Codigo == codigoSucursal))
                        .ToList();
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
