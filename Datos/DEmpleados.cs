using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEmpleados
    {
        public bool ExisteEmpleado(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    return context.CEmpleado.Any(e => e.Codigo.Equals(codigo));
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RegistrarEmpleado(CEmpleado cEmpleado, string codigoSucursal)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    var sucursal = context.CSucursal.Include("CEmpleado").FirstOrDefault(s => s.Codigo.Equals(codigoSucursal));

                    if (sucursal == null)
                    {
                        return "Sucursal no encontrada.";
                    }

                    context.CEmpleado.Add(cEmpleado);
                    sucursal.CEmpleado.Add(cEmpleado);
                    context.SaveChanges();
                }
                return "Empleado registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ModificarEmpleado(CEmpleado cEmpleado)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CEmpleado empleadoTemp = context.CEmpleado.Find(cEmpleado.Codigo);
                    empleadoTemp.Nombre = cEmpleado.Nombre;
                    empleadoTemp.Dni = cEmpleado.Dni;
                    empleadoTemp.Telefono = cEmpleado.Telefono;
                    empleadoTemp.Correo = cEmpleado.Correo;
                    empleadoTemp.Cargo = cEmpleado.Cargo;
                    empleadoTemp.Fecha_ingreso = cEmpleado.Fecha_ingreso;
                    context.SaveChanges();
                }
                return "Empleado modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EliminarEmpleado(string codigo)
        {
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    CEmpleado empleadoTemp = context.CEmpleado.Find(codigo);
                    context.CEmpleado.Remove(empleadoTemp);
                    context.SaveChanges();
                }
                return "Empleado eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<CEmpleado> ListarEmpleadosPorSucursal(string codigoSucursal)
        { 
            List<CEmpleado> empleados = new List<CEmpleado>();
            try
            {
                using (var context = new BDGestionProductosEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var sucursal = context.CSucursal
                        .Include("CEmpleado")
                        .FirstOrDefault(s => s.Codigo.Equals(codigoSucursal));

                    if (sucursal != null && sucursal.CEmpleado != null)
                    {
                        empleados = sucursal.CEmpleado.ToList();
                    }
                }
                return empleados;
            }
            catch (Exception)
            {
                return empleados;
            }
        }
    }
}
