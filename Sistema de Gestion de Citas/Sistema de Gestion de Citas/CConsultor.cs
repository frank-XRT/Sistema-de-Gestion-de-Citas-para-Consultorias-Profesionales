using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CConsultor
    {
        // ===========================================================================
        // SECCION: PROPIEDADES DEL CONSULTOR
        // ===========================================================================
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Rubro { get; set; }
        public string Descripcion { get; set; }
        public string Contraseña { get; set; }
        public decimal Monto { get; set; }
        public List<CHorarioConsultor> ListaHorarios { get; set; }

        // ===========================================================================
        // SECCION: CONSTRUCTORES
        // ===========================================================================
        public CConsultor()
        {
            ListaHorarios = new List<CHorarioConsultor>();
        }

        public CConsultor(int codigo, string nombre, string dni, string sexo, string telefono,
                          string correo, string rubro, string descripcion, string contraseña, decimal monto)
        {
            Codigo = codigo;
            Nombre = nombre;
            Dni = dni;
            Sexo = sexo;
            Telefono = telefono;
            Correo = correo;
            Rubro = rubro;
            Descripcion = descripcion;
            Contraseña = contraseña;
            Monto = monto;
            ListaHorarios = new List<CHorarioConsultor>();
        }

        // ===========================================================================
        // SECCION: GENERACION DE HORARIOS
        // Usado por CControlador en la carga inicial y al generar horarios nuevos
        // ===========================================================================
        public void GenerarHorarios(DateTime fecha, ref int ultimoCodigoHorario)
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
                AgregarHorarioSiNoExiste(ultimoCodigoHorario++, inicios[i], fines[i]);
            }
        }

        private void AgregarHorarioSiNoExiste(int codigo, DateTime inicio, DateTime fin)
        {
            bool existe = ListaHorarios.Any(h => h.FechaHoraInicio == inicio && h.FechaHoraFin == fin);

            if (!existe)
            {
                ListaHorarios.Add(new CHorarioConsultor(codigo, this.Codigo, inicio, fin, "Libre"));
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
