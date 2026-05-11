using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CCliente : CUsuario
    {
        public List<CCita> ListaCitas { get; set; }

        public CCliente() : base()
        {
            ListaCitas = new List<CCita>();
        }

        public CCliente(int id, string nombre, string dni, string sexo,
                        string telefono, string correo, string contraseña)
            : base(id, nombre, dni, sexo, telefono, correo, contraseña)
        {
            ListaCitas = new List<CCita>();
        }

        public List<CCita> ListarCitas()
        {
            return ListaCitas;
        }

        public void AgregarCita(CCita cita)
        {
            if (!ListaCitas.Contains(cita))
            {
                ListaCitas.Add(cita);
            }
        }
    }
}
