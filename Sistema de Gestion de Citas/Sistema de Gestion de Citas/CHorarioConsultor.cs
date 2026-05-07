using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CHorarioConsultor
    {
        public int Codigo { get; set; }
        public int CodigoConsultor { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; }
        public CCita Cita { get; set; }
        public CCliente Cliente { get; set; }

        public CHorarioConsultor()
        {
        }

        public CHorarioConsultor(int codigo, int codigoConsultor, DateTime fechaHoraInicio,
                                 DateTime fechaHoraFin, string estado)
        {
            Codigo = codigo;
            CodigoConsultor = codigoConsultor;
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
