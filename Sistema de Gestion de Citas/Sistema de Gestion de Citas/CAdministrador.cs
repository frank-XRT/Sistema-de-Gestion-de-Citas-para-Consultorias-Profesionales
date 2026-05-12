using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CAdministrador : CUsuario
    {
        public CAdministrador() : base()
        {
        }

        public CAdministrador(int id, string nombre, string dni, string sexo,
                              string telefono, string correo, string Contrasena)
            : base(id, nombre, dni, sexo, telefono, correo, Contrasena)
        {
        }
    }
}
