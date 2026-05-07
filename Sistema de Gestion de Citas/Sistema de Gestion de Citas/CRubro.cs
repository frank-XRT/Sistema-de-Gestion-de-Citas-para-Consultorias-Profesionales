using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CRubro
    {
        public string Nombre { get; set; }
        public List<CConsultor> ListaConsultores { get; set; }

        public CRubro()
        {
            ListaConsultores = new List<CConsultor>();
        }

        public CRubro(string nombre)
        {
            Nombre = nombre;
            ListaConsultores = new List<CConsultor>();
        }

        public void AgregarConsultor(CConsultor consultor)
        {
            if (!ListaConsultores.Contains(consultor))
            {
                ListaConsultores.Add(consultor);
            }
        }

        public List<CConsultor> ListarConsultores()
        {
            return ListaConsultores;
        }

        public List<CConsultor> BuscarConsultores(string filtro)
        {
            return ListaConsultores
                .Where(c => c.Nombre.ToLower().Contains(filtro.ToLower()))
                .ToList();
        }
    }
}
