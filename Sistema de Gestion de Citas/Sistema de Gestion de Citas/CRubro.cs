using System;
using System.Collections.Generic;

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
            bool existe = false;
            foreach (CConsultor c in ListaConsultores)
            {
                if (c == consultor)
                {
                    existe = true;
                    break;
                }
            }

            if (existe == false)
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
            List<CConsultor> resultados = new List<CConsultor>();

            string filtroBuscado = filtro.ToLower();

            foreach (CConsultor c in ListaConsultores)
            {
                string nombreConsultor = c.Nombre.ToLower();

                if (nombreConsultor.Contains(filtroBuscado))
                {
                    resultados.Add(c);
                }
            }

            return resultados;
        }
    }
}
