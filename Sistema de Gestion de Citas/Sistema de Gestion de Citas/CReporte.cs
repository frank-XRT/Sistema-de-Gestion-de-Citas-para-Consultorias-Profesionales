using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CReporte
    {
        // Mapea cualquier rubro especifico a una de las 4 Grandes areas Maestro
        private string ObtenerAreaPrincipal(string rubro)
        {
            string r = rubro.ToLower();

            // 1. AREA DE SALUD
            if (r.Contains("medic") || r.Contains("psicolog") || r.Contains("nutri") || 
                r.Contains("odonto") || r.Contains("veterinar") || r.Contains("salud") || 
                r.Contains("terapia") || r.Contains("enfermer") || r.Contains("clinica"))
                return "Area de Salud";

            // 2. AREA DE NEGOCIOS Y LEYES
            if (r.Contains("derecho") || r.Contains("legal") || r.Contains("contab") || 
                r.Contains("administr") || r.Contains("finanz") || r.Contains("marketing") || 
                r.Contains("negocio") || r.Contains("econom") || r.Contains("audit") || 
                r.Contains("ley") || r.Contains("tributar"))
                return "Area de Negocios y Leyes";

            // 3. AREA DE TECNOLOGIA Y DISENO
            if (r.Contains("tecnolog") || r.Contains("sistem") || r.Contains("software") || 
                r.Contains("ingenier") || r.Contains("civil") || r.Contains("arquitect") || 
                r.Contains("diseno") || r.Contains("diseño") || r.Contains("digital") || 
                r.Contains("computa") || r.Contains("grafic"))
                return "Area de Tecnologia y Diseno";

            // 4. AREA DE EDUCACION Y SOCIEDAD
            if (r.Contains("docen") || r.Contains("educa") || r.Contains("social") || 
                r.Contains("idioma") || r.Contains("sociolog") || r.Contains("pedago") || 
                r.Contains("clase") || r.Contains("tutor") || r.Contains("humanid"))
                return "Area de Educacion y Sociedad";

            return "Otras Areas";
        }

        public List<object> CitasPorServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            // Inicializamos el diccionario con las 4 areas en 0 para asegurar que siempre aparezcan
            var totalesPorArea = new Dictionary<string, int>
            {
                { "Area de Salud", 0 },
                { "Area de Negocios y Leyes", 0 },
                { "Area de Tecnologia y Diseno", 0 },
                { "Area de Educacion y Sociedad", 0 }
            };

            // Procesamos los datos existentes
            foreach (var rubro in CControlador.ListaRubros)
            {
                string areaPrincipal = ObtenerAreaPrincipal(rubro.Nombre);
                
                // Solo sumamos si es una de nuestras 4 areas principales
                if (totalesPorArea.ContainsKey(areaPrincipal))
                {
                    int citas = rubro.ListaConsultores.Sum(con =>
                        con.ListaHorarios.Count(h => h.Cita != null
                            && h.FechaHoraInicio.Date >= fechaInicio.Date
                            && h.FechaHoraInicio.Date <= fechaFin.Date));
                    
                    totalesPorArea[areaPrincipal] += citas;
                }
            }

            // Convertimos a la lista de objetos que espera el grafico
            return totalesPorArea.Select(kvp => (object)new
            {
                Rubro = kvp.Key,
                CantidadCitas = kvp.Value
            }).ToList();
        
        }

        public List<object> IngresosPorServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            // Inicializamos las 4 areas con 0 para que siempre aparezcan las 4 barras
            var totalesPorArea = new Dictionary<string, decimal>
            {
                { "Area de Salud", 0 },
                { "Area de Negocios y Leyes", 0 },
                { "Area de Tecnologia y Diseno", 0 },
                { "Area de Educacion y Sociedad", 0 }
            };

            // Sumamos los ingresos de cada rubro en su area correspondiente
            foreach (var rubro in CControlador.ListaRubros)
            {
                string area = ObtenerAreaPrincipal(rubro.Nombre);

                if (totalesPorArea.ContainsKey(area))
                {
                    decimal ingresos = rubro.ListaConsultores.Sum(con =>
                        con.ListaHorarios
                            .Where(h => h.Cita != null
                                && h.FechaHoraInicio.Date >= fechaInicio.Date
                                && h.FechaHoraInicio.Date <= fechaFin.Date)
                            .Sum(h => h.Cita.Monto));

                    totalesPorArea[area] += ingresos;
                }
            }

            return totalesPorArea.Select(kvp => (object)new
            {
                Rubro = kvp.Key,
                TotalIngresos = kvp.Value
            }).ToList();
        }

        public List<object> ConsultoresPorRubro()
        {
            // Inicializamos las 4 areas con 0 para que siempre aparezcan las 4 barras
            var totalesPorArea = new Dictionary<string, int>
            {
                { "Area de Salud", 0 },
                { "Area de Negocios y Leyes", 0 },
                { "Area de Tecnologia y Diseno", 0 },
                { "Area de Educacion y Sociedad", 0 }
            };

            foreach (var rubro in CControlador.ListaRubros)
            {
                string area = ObtenerAreaPrincipal(rubro.Nombre);
                if (totalesPorArea.ContainsKey(area))
                    totalesPorArea[area] += rubro.ListaConsultores.Count;
            }

            return totalesPorArea.Select(kvp => (object)new
            {
                Rubro = kvp.Key,
                CantidadConsultores = kvp.Value
            }).ToList();
        }

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

        public dynamic EstadisticasPorArea(string areaNombre, DateTime inicio, DateTime fin)
        {
            int asistidas = 0;
            int canceladas = 0;
            int noAsistidas = 0;

            foreach (var rubro in CControlador.ListaRubros)
            {
                if (ObtenerAreaPrincipal(rubro.Nombre) == areaNombre)
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

