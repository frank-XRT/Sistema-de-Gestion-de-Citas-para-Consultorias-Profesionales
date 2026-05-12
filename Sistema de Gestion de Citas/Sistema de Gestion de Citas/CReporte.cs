using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CCitaPorRubro
    {
        public string Rubro { get; set; }
        public int CantidadCitas { get; set; }
    }

    public class CIngresoPorRubro
    {
        public string Rubro { get; set; }
        public decimal TotalIngresos { get; set; }
    }

    public class CConsultorPorRubro
    {
        public string Rubro { get; set; }
        public int CantidadConsultores { get; set; }
    }

    public class CIngresoTrimestral
    {
        public string Mes { get; set; }
        public decimal Ingreso { get; set; }
    }

    public class CClienteFrecuente
    {
        public string NombreCliente { get; set; }
        public int NumeroCitas { get; set; }
    }

    public class CResumenCitas
    {
        public int Hoy { get; set; }
        public int Mes { get; set; }
        public int Total { get; set; }
    }

    public class CEstadisticasRubro
    {
        public int Asistidas { get; set; }
        public int Canceladas { get; set; }
        public int NoAsistidas { get; set; }
    }

    public class CReporte
    {
        public List<object> CitasPorServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            List<object> reporte = new List<object>();

            foreach (CRubro rubro in CControlador.ListaRubros)
            {
                int citas = 0;

                foreach (CConsultor con in rubro.ListaConsultores)
                {
                    foreach (CHorarioConsultor h in con.ListaHorarios)
                    {
                        if (h.Cita != null)
                        {
                            if (h.FechaHoraInicio.Date >= fechaInicio.Date)
                            {
                                if (h.FechaHoraInicio.Date <= fechaFin.Date)
                                {
                                    citas = citas + 1;
                                }
                            }
                        }
                    }
                }

                CCitaPorRubro item = new CCitaPorRubro();
                item.Rubro = rubro.Nombre;
                item.CantidadCitas = citas;
                reporte.Add(item);
            }

            return reporte;
        }

        public List<object> IngresosPorServicio(DateTime fechaInicio, DateTime fechaFin)
        {
            List<object> reporte = new List<object>();

            foreach (CRubro rubro in CControlador.ListaRubros)
            {
                decimal ingresos = 0;

                foreach (CConsultor con in rubro.ListaConsultores)
                {
                    foreach (CHorarioConsultor h in con.ListaHorarios)
                    {
                        if (h.Cita != null)
                        {
                            if (h.FechaHoraInicio.Date >= fechaInicio.Date)
                            {
                                if (h.FechaHoraInicio.Date <= fechaFin.Date)
                                {
                                    ingresos = ingresos + h.Cita.Monto;
                                }
                            }
                        }
                    }
                }

                CIngresoPorRubro item = new CIngresoPorRubro();
                item.Rubro = rubro.Nombre;
                item.TotalIngresos = ingresos;
                reporte.Add(item);
            }

            return reporte;
        }

        public List<object> ConsultoresPorRubro()
        {
            List<object> reporte = new List<object>();

            foreach (CRubro rubro in CControlador.ListaRubros)
            {
                CConsultorPorRubro item = new CConsultorPorRubro();
                item.Rubro = rubro.Nombre;
                item.CantidadConsultores = rubro.ListaConsultores.Count;
                reporte.Add(item);
            }

            return reporte;
        }

        public List<object> IngresosMensualesPorTrimestre(int IDConsultor, int trimestre)
        {
            int mesInicio = (trimestre - 1) * 3 + 1;
            int mesFin = mesInicio + 2;

            CConsultor consultor = CControlador.ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            List<object> reporteFinal = new List<object>();

            if (consultor == null)
            {
                return reporteFinal;
            }


            for (int mesActual = mesInicio; mesActual <= mesFin; mesActual++)
            {
                decimal ingresoMensual = 0;

                foreach (CHorarioConsultor horario in consultor.ListaHorarios)
                {
                    if (horario.Cita != null)
                    {
                        if (horario.Cita.Estado == "Atendido")
                        {
                            if (horario.FechaHoraInicio.Month == mesActual)
                            {
                                ingresoMensual = ingresoMensual + horario.Cita.Monto;
                            }
                        }
                    }
                }

                if (ingresoMensual > 0)
                {
                    CIngresoTrimestral item = new CIngresoTrimestral();
                    item.Mes = NombreMes(mesActual);
                    item.Ingreso = ingresoMensual;
                    reporteFinal.Add(item);
                }
            }

            return reporteFinal;
        }

        public List<object> ClientesMasFrecuentes(int IDConsultor)
        {
            CConsultor consultor = CControlador.ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            List<object> reporteFinal = new List<object>();

            if (consultor == null)
            {
                return reporteFinal;
            }

            List<CCliente> clientesUnicos = new List<CCliente>();
            List<int> conteoCitas = new List<int>();

            foreach (CHorarioConsultor horario in consultor.ListaHorarios)
            {
                if (horario.Cita != null)
                {
                    if (horario.Cliente != null)
                    {
                        bool encontrado = false;
                        for (int i = 0; i < clientesUnicos.Count; i++)
                        {
                            if (clientesUnicos[i].ID == horario.Cliente.ID)
                            {
                                conteoCitas[i] = conteoCitas[i] + 1;
                                encontrado = true;
                                break;
                            }
                        }

                        if (encontrado == false)
                        {
                            clientesUnicos.Add(horario.Cliente);
                            conteoCitas.Add(1);
                        }
                    }
                }
            }

            for (int i = 0; i < clientesUnicos.Count - 1; i++)
            {
                for (int j = 0; j < clientesUnicos.Count - 1 - i; j++)
                {
                    if (conteoCitas[j] < conteoCitas[j + 1])
                    {
                        int tempConteo = conteoCitas[j];
                        conteoCitas[j] = conteoCitas[j + 1];
                        conteoCitas[j + 1] = tempConteo;

                        CCliente tempCliente = clientesUnicos[j];
                        clientesUnicos[j] = clientesUnicos[j + 1];
                        clientesUnicos[j + 1] = tempCliente;
                    }
                }
            }

            for (int i = 0; i < clientesUnicos.Count; i++)
            {
                CClienteFrecuente item = new CClienteFrecuente();
                item.NombreCliente = clientesUnicos[i].Nombre;
                item.NumeroCitas = conteoCitas[i];
                reporteFinal.Add(item);
            }

            return reporteFinal;
        }

        public CResumenCitas ObtenerResumenCitas(int IDConsultor)
        {
            DateTime hoy = DateTime.Today;
            int esteMes = hoy.Month;
            int esteAño = hoy.Year;

            CConsultor consultor = CControlador.ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            CResumenCitas resumen = new CResumenCitas();
            resumen.Hoy = 0;
            resumen.Mes = 0;
            resumen.Total = 0;

            if (consultor == null)
            {
                return resumen;
            }

            int hoyCount = 0;
            int mesCount = 0;
            int totalCount = 0;

            foreach (CHorarioConsultor h in consultor.ListaHorarios)
            {
                if (h.Cita != null)
                {
                    if (h.Cita.Estado == "Atendido")
                    {
                        totalCount = totalCount + 1;

                        if (h.FechaHoraInicio.Date == hoy)
                        {
                            hoyCount = hoyCount + 1;
                        }

                        if (h.FechaHoraInicio.Month == esteMes)
                        {
                            if (h.FechaHoraInicio.Year == esteAño)
                            {
                                mesCount = mesCount + 1;
                            }
                        }
                    }
                }
            }

            resumen.Hoy = hoyCount;
            resumen.Mes = mesCount;
            resumen.Total = totalCount;

            return resumen;
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

        public CEstadisticasRubro EstadisticasPorRubro(string rubroNombre, DateTime inicio, DateTime fin)
        {
            int asistidas = 0;
            int canceladas = 0;
            int noAsistidas = 0;

            foreach (CRubro rubro in CControlador.ListaRubros)
            {
                if (rubro.Nombre == rubroNombre)
                {
                    foreach (CConsultor con in rubro.ListaConsultores)
                    {
                        foreach (CHorarioConsultor h in con.ListaHorarios)
                        {
                            if (h.FechaHoraInicio.Date >= inicio.Date)
                            {
                                if (h.FechaHoraInicio.Date <= fin.Date)
                                {
                                    if (h.Cita != null)
                                    {
                                        if (h.Cita.Estado == "Atendido")
                                        {
                                            asistidas = asistidas + 1;
                                        }
                                        else if (h.Cita.Estado == "Cancelado")
                                        {
                                            canceladas = canceladas + 1;
                                        }
                                        else
                                        {
                                            noAsistidas = noAsistidas + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            CEstadisticasRubro estadisticas = new CEstadisticasRubro();
            estadisticas.Asistidas = asistidas;
            estadisticas.Canceladas = canceladas;
            estadisticas.NoAsistidas = noAsistidas;

            return estadisticas;
        }
    }
}

