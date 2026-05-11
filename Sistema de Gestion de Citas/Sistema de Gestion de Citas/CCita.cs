using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CCita
    {
        public int ID { get; set; }
        public int IDCliente { get; set; }
        public int IDHorario { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public CCita()
        {
        }

        public CCita(int id, int idCliente, int idHorario,
                     decimal monto, string descripcion, string estado)
        {
            ID = id;
            IDCliente = idCliente;
            IDHorario = idHorario;
            Monto = monto;
            Descripcion = descripcion;
            Estado = estado;
        }

        public void Atender()
        {
            Estado = "Atendido";
        }

        public void Cancelar()
        {
            Estado = "Cancelado";
        }
    }
}
