using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CAdministrador
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Contraseña { get; set; }

        public CAdministrador()
        {
        }

        public CAdministrador(int codigo, string nombre, string dni, string contraseña)
        {
            Codigo = codigo;
            Nombre = nombre;
            Dni = dni;
            Contraseña = contraseña;
        }
    }
}
