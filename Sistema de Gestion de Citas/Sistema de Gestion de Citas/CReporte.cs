using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CReporte
    {


        // ===========================================================================
        // SECCION: REPORTES DEL ADMINISTRADOR - Estadisticas globales por rubro
        // ===========================================================================
        public List<object> CitasPorServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            var totalesPorRubro = new Dictionary<string, int>();

            // Inicializar para todos los rubros en 0
            foreach (var rubro in CControlador.ListaRubros)
            {
                totalesPorRubro[rubro.Nombre] = 0;
            }

            foreach (var rubro in CControlador.ListaRubros)
            {
                int citas = rubro.ListaConsultores.Sum(con =>
                    con.ListaHorarios.Count(h => h.Cita != null
                        && h.FechaHoraInicio.Date >= fechaInicio.Date
                        && h.FechaHoraInicio.Date <= fechaFin.Date));
                
                totalesPorRubro[rubro.Nombre] += citas;
            }

            return totalesPorRubro.Select(kvp => (object)new
            {
                Rubro = kvp.Key,
                CantidadCitas = kvp.Value
            }).ToList();
        }

        public List<object> IngresosPorServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            var totalesPorRubro = new Dictionary<string, decimal>();

            // Inicializamos todos los rubros con 0
            foreach (var rubro in CControlador.ListaRubros)
            {
                totalesPorRubro[rubro.Nombre] = 0;
            }

            foreach (var rubro in CControlador.ListaRubros)
            {
                decimal ingresos = rubro.ListaConsultores.Sum(con =>
                    con.ListaHorarios
                        .Where(h => h.Cita != null
                            && h.FechaHoraInicio.Date >= fechaInicio.Date
                            && h.FechaHoraInicio.Date <= fechaFin.Date)
                        .Sum(h => h.Cita.Monto));

                totalesPorRubro[rubro.Nombre] += ingresos;
            }

            return totalesPorRubro.Select(kvp => (object)new
            {
                Rubro = kvp.Key,
                TotalIngresos = kvp.Value
            }).ToList();
        }

        public List<object> ConsultoresPorRubro()
        {
            var totalesPorRubro = new Dictionary<string, int>();

            foreach (var rubro in CControlador.ListaRubros)
            {
                totalesPorRubro[rubro.Nombre] = rubro.ListaConsultores.Count;
            }

            return totalesPorRubro.Select(kvp => (object)new
            {
                Rubro = kvp.Key,
                CantidadConsultores = kvp.Value
            }).ToList();
        }

        // ===========================================================================
        // SECCION: REPORTES DEL CONSULTOR - Estadisticas individuales por consultor
        // ===========================================================================
        public List<object> IngresosMensualesPorTrimestre(int codigoConsultor, int trimestre)
        {
            int mesInicio = (trimestre - 1) * 3 + 1;
            int mesFin = mesInicio + 2;

            CConsultor consultor = CControlador.ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            if (consultor == null) return new List<object>();

            // MULTILISTA: Navegamos Consultor -> Horarios -> Citas
            var reporte = from horario in consultor.ListaHorarios
                          where horario.Cita != null
                                && horario.Cita.Estado == "Atendido"
                                && horario.FechaHoraInicio.Month >= mesInicio
                                && horario.FechaHoraInicio.Month <= mesFin
                          group horario.Cita by horario.FechaHoraInicio.Month into grupo
                          orderby grupo.Key
                          select new
                          {
                              Mes = NombreMes(grupo.Key),
                              Ingreso = grupo.Sum(c => c.Monto)
                          };

            return reporte.Cast<object>().ToList();
        }

        public List<object> ClientesMasFrecuentes(int codigoConsultor)
        {
            CConsultor consultor = CControlador.ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            if (consultor == null) return new List<object>();

            // MULTILISTA: Navegamos Consultor -> Horarios -> Cliente (via Cita o directo)
            var reporte = from horario in consultor.ListaHorarios
                          where horario.Cita != null && horario.Cliente != null
                          group horario by horario.Cliente into grupo
                          orderby grupo.Count() descending
                          select new
                          {
                              NombreCliente = grupo.Key.Nombre,
                              NumeroCitas = grupo.Count()
                          };

            return reporte.Cast<object>().ToList();
        }

        public dynamic ObtenerResumenCitas(int codigoConsultor)
        {
            var hoy = DateTime.Today;
            var esteMes = hoy.Month;
            var esteAño = hoy.Year;

            CConsultor consultor = CControlador.ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            if (consultor == null) return new { Hoy = 0, Mes = 0, Total = 0 };

            // MULTILISTA: Navegamos directamente por los horarios del consultor
            int hoyCount = consultor.ListaHorarios.Count(h => h.Cita != null 
                && h.Cita.Estado == "Atendido" && h.FechaHoraInicio.Date == hoy);

            int mesCount = consultor.ListaHorarios.Count(h => h.Cita != null 
                && h.Cita.Estado == "Atendido" && h.FechaHoraInicio.Month == esteMes && h.FechaHoraInicio.Year == esteAño);

            int totalCount = consultor.ListaHorarios.Count(h => h.Cita != null && h.Cita.Estado == "Atendido");

            return new
            {
                Hoy = hoyCount,
                Mes = mesCount,
                Total = totalCount
            };
        }

        // ===========================================================================
        // SECCION: METODOS PRIVADOS AUXILIARES (utilidades internas)
        // ===========================================================================
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
        private string NombreMes(int mes)
        {
            if (mes == 1) return "Enero";
            if (mes == 2) return "Febrero";
            if (mes == 3) return "Marzo";
            if (mes == 4) return "Abril";
            if (mes == 5) return "Mayo";
            if (mes == 6) return "Junio";
            if (mes == 7) return "Julio";
            if (mes == 8) return "Agosto";
            if (mes == 9) return "Septiembre";
            if (mes == 10) return "Octubre";
            if (mes == 11) return "Noviembre";
            if (mes == 12) return "Diciembre";

            return "";
        }

        // ===========================================================================
        // SECCION: REPORTES DEL ADMINISTRADOR - Estadisticas de estados por rubro
        // ===========================================================================
        public dynamic EstadisticasPorRubro(string rubroNombre, DateTime inicio, DateTime fin)
        {
            int asistidas = 0;
            int canceladas = 0;
            int noAsistidas = 0;

            foreach (var rubro in CControlador.ListaRubros)
            {
                if (rubro.Nombre == rubroNombre)
                {
                    foreach (var con in rubro.ListaConsultores)
                    {
                        var horariosEnRango = con.ListaHorarios.Where(h => 
                            h.FechaHoraInicio.Date >= inicio.Date && 
                            h.FechaHoraInicio.Date <= fin.Date && 
                            h.Cita != null);

                        foreach (var h in horariosEnRango)
                        {
                            if (h.Cita.Estado == "Atendido") asistidas++;
                            else if (h.Cita.Estado == "Cancelado") canceladas++;
                            else noAsistidas++;
                        }
                    }
                }
            }

            return new { Asistidas = asistidas, Canceladas = canceladas, NoAsistidas = noAsistidas };
        }
    }
}

