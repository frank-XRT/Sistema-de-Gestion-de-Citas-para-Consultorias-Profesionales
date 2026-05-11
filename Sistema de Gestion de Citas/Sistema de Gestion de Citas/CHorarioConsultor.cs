using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CHorarioConsultor
    {
        public int ID { get; set; }
        public int IDConsultor { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; }
        public CCita Cita { get; set; }
        public CCliente Cliente { get; set; }

        public CHorarioConsultor()
        {
        }

        public CHorarioConsultor(int id, int idConsultor, DateTime fechaHoraInicio,
                                 DateTime fechaHoraFin, string estado)
        {
            ID = id;
            IDConsultor = idConsultor;
            FechaHoraInicio = fechaHoraInicio;
            FechaHoraFin = fechaHoraFin;
            Estado = estado;
        }

        public void Reservar(CCita cita, CCliente cliente)
        {
            Estado = "Reservado";
            Cita = cita;
            Cliente = cliente;
        }

        public void Liberar()
        {
            Estado = "Libre";
            Cita = null;
            Cliente = null;
        }
    }
}
