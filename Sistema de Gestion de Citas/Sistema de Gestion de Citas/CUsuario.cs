using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public abstract class CUsuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        protected CUsuario()
        {
        }

        protected CUsuario(int id, string nombre, string dni, string sexo, 
                           string telefono, string correo, string contraseña)
        {
            ID = id;
            Nombre = nombre;
            Dni = dni;
            Sexo = sexo;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
        }
    }
}
