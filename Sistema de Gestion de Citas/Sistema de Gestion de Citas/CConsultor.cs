using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CConsultor : CUsuario
    {
        public string Rubro { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; } = "Activo";
        public List<CHorarioConsultor> ListaHorarios { get; set; }

        public CConsultor() : base()
        {
            ListaHorarios = new List<CHorarioConsultor>();
        }

        public CConsultor(int id, string nombre, string dni, string sexo, string telefono,
                          string correo, string rubro, string description, string contrasena, decimal monto)
            : base(id, nombre, dni, sexo, telefono, correo, contrasena)
        {
            Rubro = rubro;
            Descripcion = description;
            Monto = monto;
            ListaHorarios = new List<CHorarioConsultor>();
        }

        public int GenerarHorarios(DateTime fecha, int ultimoIDHorario)
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
                bool agregado = AgregarHorarioSiNoExiste(ultimoIDHorario, inicios[i], fines[i]);
                if (agregado)
                {
                    ultimoIDHorario = ultimoIDHorario + 1;
                }
            }

            return ultimoIDHorario;
        }

        private bool AgregarHorarioSiNoExiste(int id, DateTime inicio, DateTime fin)
        {
            bool existe = false;
            foreach (CHorarioConsultor h in ListaHorarios)
            {
                if (h.FechaHoraInicio == inicio)
                {
                    if (h.FechaHoraFin == fin)
                    {
                        existe = true;
                        break;
                    }
                }
            }
            
            if (existe == false)
            {
                ListaHorarios.Add(new CHorarioConsultor(id, this.ID, inicio, fin, "Libre"));
                return true;
            }

            return false;
        }

        public List<CHorarioConsultor> ListarHorariosLibres()
        {
            List<CHorarioConsultor> libres = new List<CHorarioConsultor>();
            foreach (CHorarioConsultor h in ListaHorarios)
            {
                if (h.Estado == "Libre")
                {
                    libres.Add(h);
                }
            }
            return libres;
        }

        public List<CHorarioConsultor> ListarHorariosLibres(DateTime fecha)
        {
            List<CHorarioConsultor> libres = new List<CHorarioConsultor>();
            foreach (CHorarioConsultor h in ListaHorarios)
            {
                if (h.Estado == "Libre")
                {
                    if (h.FechaHoraInicio.Date == fecha.Date)
                    {
                        libres.Add(h);
                    }
                }
            }
            return libres;
        }

        public List<CCita> ListarCitas()
        {
            List<CCita> citas = new List<CCita>();
            foreach (CHorarioConsultor h in ListaHorarios)
            {
                if (h.Cita != null)
                {
                    citas.Add(h.Cita);
                }
            }
            return citas;
        }
    }
}
