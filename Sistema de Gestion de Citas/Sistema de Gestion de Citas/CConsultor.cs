using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CConsultor
    {
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

        public CConsultor()
        {
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
        }
    }
}
