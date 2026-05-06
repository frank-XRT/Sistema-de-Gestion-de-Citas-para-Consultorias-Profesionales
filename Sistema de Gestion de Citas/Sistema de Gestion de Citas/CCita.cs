using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CCita
    {
        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoHorario { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public CCita()
        {
        }

        public CCita(int codigo, int codigoCliente, int codigoHorario,
                     decimal monto, string descripcion, string estado)
        {
            Codigo = codigo;
            CodigoCliente = codigoCliente;
            CodigoHorario = codigoHorario;
            Monto = monto;
            Descripcion = descripcion;
            Estado = estado;
        }
    }
}
