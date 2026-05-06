using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CReporte
    {
        public List<object> CitasPorServicio()
        {
            var reporte = from cita in CControlador.ListaCitas
                          join horario in CControlador.ListaHorarios
                          on cita.CodigoHorario equals horario.Codigo
                          join consultor in CControlador.ListaConsultores
                          on horario.CodigoConsultor equals consultor.Codigo
                          group cita by consultor.Rubro into grupo
                          select new
                          {
                              Rubro = grupo.Key,
                              CantidadCitas = grupo.Count()
                          };

            return reporte.Cast<object>().ToList();
        }

        public List<object> ConsultoresPorRubro()
        {
            var reporte = from consultor in CControlador.ListaConsultores
                          group consultor by consultor.Rubro into grupo
                          select new
                          {
                              Rubro = grupo.Key,
                              CantidadConsultores = grupo.Count()
                          };

            return reporte.Cast<object>().ToList();
        }

        public decimal IngresosPorTrimestre(int codigoConsultor, int trimestre)
        {
            int mesInicio = 1;
            int mesFin = 3;

            if (trimestre == 1)
            {
                mesInicio = 1;
                mesFin = 3;
            }
            else if (trimestre == 2)
            {
                mesInicio = 4;
                mesFin = 6;
            }
            else if (trimestre == 3)
            {
                mesInicio = 7;
                mesFin = 9;
            }
            else if (trimestre == 4)
            {
                mesInicio = 10;
                mesFin = 12;
            }

            var horariosConsultor = CControlador.ListaHorarios
                .Where(h => h.CodigoConsultor == codigoConsultor)
                .ToList();

            decimal total = 0;

            foreach (CHorarioConsultor horario in horariosConsultor)
            {
                if (horario.FechaHoraInicio.Month >= mesInicio &&
                    horario.FechaHoraInicio.Month <= mesFin)
                {
                    List<CCita> citas = CControlador.ListaCitas
                        .Where(c => c.CodigoHorario == horario.Codigo &&
                                    c.Estado == "Atendido")
                        .ToList();

                    foreach (CCita cita in citas)
                    {
                        total += cita.Monto;
                    }
                }
            }

            return total;
        }

        public List<object> ClientesMasFrecuentes(int codigoConsultor)
        {
            var horariosConsultor = CControlador.ListaHorarios
                .Where(h => h.CodigoConsultor == codigoConsultor)
                .Select(h => h.Codigo)
                .ToList();

            var reporte = from cita in CControlador.ListaCitas
                          where horariosConsultor.Contains(cita.CodigoHorario)
                          group cita by cita.CodigoCliente into grupo
                          orderby grupo.Count() descending
                          select new
                          {
                              CodigoCliente = grupo.Key,
                              NombreCliente = ObtenerNombreCliente(grupo.Key),
                              NumeroCitas = grupo.Count()
                          };

            return reporte.Cast<object>().ToList();
        }

        private string ObtenerNombreCliente(int codigoCliente)
        {
            CCliente cliente = CControlador.ListaClientes
                .Find(c => c.Codigo == codigoCliente);

            if (cliente == null)
            {
                return "Cliente no encontrado";
            }

            return cliente.Nombre;
        }
    }
}
