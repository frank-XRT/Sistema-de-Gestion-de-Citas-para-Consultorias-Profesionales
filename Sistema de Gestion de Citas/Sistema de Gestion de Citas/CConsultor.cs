using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CConsultor : CUsuario
    {
        // ===========================================================================
        // SECCION: PROPIEDADES DEL CONSULTOR
        // ===========================================================================
        public string Rubro { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; } = "Activo";
        public List<CHorarioConsultor> ListaHorarios { get; set; }

        // ===========================================================================
        // SECCION: CONSTRUCTORES
        // ===========================================================================
        public CConsultor() : base()
        {
            ListaHorarios = new List<CHorarioConsultor>();
        }

        public CConsultor(int id, string nombre, string dni, string sexo, string telefono,
                          string correo, string rubro, string description, string contraseña, decimal monto)
            : base(id, nombre, dni, sexo, telefono, correo, contraseña)
        {
            Rubro = rubro;
            Descripcion = description;
            Monto = monto;
            ListaHorarios = new List<CHorarioConsultor>();
        }

        // ===========================================================================
        // SECCION: GENERACION DE HORARIOS
        // Usado por CControlador en la carga inicial y al generar horarios nuevos
        // ===========================================================================
        public void GenerarHorarios(DateTime fecha, ref int ultimoIDHorario)
        {
            DateTime[] inicios = {
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 8, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 0, 0)
            };

            DateTime[] fines = {
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 0, 0),
                new DateTime(fecha.Year, fecha.Month, fecha.Day, 17, 0, 0)
            };

            for (int i = 0; i < inicios.Length; i++)
            {
                AgregarHorarioSiNoExiste(ultimoIDHorario++, inicios[i], fines[i]);
            }
        }

        private void AgregarHorarioSiNoExiste(int id, DateTime inicio, DateTime fin)
        {
            bool existe = ListaHorarios.Any(h => h.FechaHoraInicio == inicio && h.FechaHoraFin == fin);
            
            if (!existe)
            {
                ListaHorarios.Add(new CHorarioConsultor(id, this.ID, inicio, fin, "Libre"));
            }
        }

        // ===========================================================================
        // SECCION: METODOS DE CONSULTA DEL CONSULTOR
        // Usados desde frmConsultarCitas y frmMenuConsultor (reportes)
        // ===========================================================================
        public List<CHorarioConsultor> ListarHorariosLibres()
        {
            return ListaHorarios.Where(h => h.Estado == "Libre").ToList();
        }

        public List<CHorarioConsultor> ListarHorariosLibres(DateTime fecha)
        {
            return ListaHorarios.Where(h => h.Estado == "Libre" && h.FechaHoraInicio.Date == fecha.Date).ToList();
        }

        public List<CCita> ListarCitas()
        {
            return ListaHorarios.Where(h => h.Cita != null).Select(h => h.Cita).ToList();
        }
    }
}
