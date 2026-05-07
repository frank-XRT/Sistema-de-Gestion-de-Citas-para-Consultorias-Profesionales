using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CCliente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public List<CCita> ListaCitas { get; set; }

        public CCliente()
        {
            ListaCitas = new List<CCita>();
        }

        public CCliente(int codigo, string nombre, string dni, string sexo,
                        string telefono, string correo, string contraseña)
        {
            Codigo = codigo;
            Nombre = nombre;
            Dni = dni;
            Sexo = sexo;
            Telefono = telefono;
            Correo = correo;
            Contraseña = contraseña;
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
