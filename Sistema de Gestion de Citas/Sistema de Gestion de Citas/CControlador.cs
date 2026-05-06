using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CControlador
    {
        public static List<CAdministrador> ListaAdministradores = new List<CAdministrador>();
        public static List<CConsultor> ListaConsultores = new List<CConsultor>();
        public static List<CCliente> ListaClientes = new List<CCliente>();
        public static List<CHorarioConsultor> ListaHorarios = new List<CHorarioConsultor>();
        public static List<CCita> ListaCitas = new List<CCita>();

        public CControlador()
        {
            CargarAdministradorInicial();
        }

        private void CargarAdministradorInicial()
        {
            if (ListaAdministradores.Count == 0)
            {
                ListaAdministradores.Add(new CAdministrador(1, "Administrador", "1", "1"));
            }
        }

        public object Login(string dni, string contraseña)
        {
            CAdministrador admin = ListaAdministradores.Find(a =>
                a.Dni == dni && a.Contraseña == contraseña);

            if (admin != null)
            {
                return admin;
            }

            CConsultor consultor = ListaConsultores.Find(c =>
                c.Dni == dni && c.Contraseña == contraseña);

            if (consultor != null)
            {
                return consultor;
            }

            CCliente cliente = ListaClientes.Find(c =>
                c.Dni == dni && c.Contraseña == contraseña);

            if (cliente != null)
            {
                return cliente;
            }

            return null;
        }

        public bool RegistrarCliente(CCliente cliente)
        {
            if (ExisteDni(cliente.Dni))
            {
                return false;
            }

            cliente.Codigo = GenerarCodigoCliente();
            ListaClientes.Add(cliente);
            return true;
        }

        public bool RegistrarConsultor(CConsultor consultor)
        {
            if (ExisteDni(consultor.Dni))
            {
                return false;
            }

            consultor.Codigo = GenerarCodigoConsultor();
            ListaConsultores.Add(consultor);
            return true;
        }

        public bool EliminarConsultor(int codigo)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigo);

            if (consultor == null)
            {
                return false;
            }

            ListaConsultores.Remove(consultor);

            ListaHorarios.RemoveAll(h => h.CodigoConsultor == codigo);

            return true;
        }

        public List<CConsultor> BuscarConsultoresPorRubro(string rubro)
        {
            return ListaConsultores
                .Where(c => c.Rubro.ToLower().Contains(rubro.ToLower()))
                .ToList();
        }

        public void GenerarHorarios(int codigoConsultor, DateTime fecha)
        {
            int codigoHorario = GenerarCodigoHorario();

            DateTime bloque1Inicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 8, 0, 0);
            DateTime bloque1Fin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0);

            DateTime bloque2Inicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0);
            DateTime bloque2Fin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 0, 0);

            DateTime bloque3Inicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 12, 0, 0);
            DateTime bloque3Fin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 0, 0);

            DateTime bloque4Inicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 14, 0, 0);
            DateTime bloque4Fin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 0, 0);

            DateTime bloque5Inicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 16, 0, 0);
            DateTime bloque5Fin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 17, 0, 0);

            AgregarHorarioSiNoExiste(codigoHorario++, codigoConsultor, bloque1Inicio, bloque1Fin);
            AgregarHorarioSiNoExiste(codigoHorario++, codigoConsultor, bloque2Inicio, bloque2Fin);
            AgregarHorarioSiNoExiste(codigoHorario++, codigoConsultor, bloque3Inicio, bloque3Fin);
            AgregarHorarioSiNoExiste(codigoHorario++, codigoConsultor, bloque4Inicio, bloque4Fin);
            AgregarHorarioSiNoExiste(codigoHorario++, codigoConsultor, bloque5Inicio, bloque5Fin);
        }

        private void AgregarHorarioSiNoExiste(int codigo, int codigoConsultor, DateTime inicio, DateTime fin)
        {
            bool existe = ListaHorarios.Any(h =>
                h.CodigoConsultor == codigoConsultor &&
                h.FechaHoraInicio == inicio &&
                h.FechaHoraFin == fin);

            if (!existe)
            {
                ListaHorarios.Add(new CHorarioConsultor(
                    codigo,
                    codigoConsultor,
                    inicio,
                    fin,
                    "Libre"
                ));
            }
        }

        public bool ReservarCita(CCita cita)
        {
            CHorarioConsultor horario = ListaHorarios.Find(h => h.Codigo == cita.CodigoHorario);

            if (horario == null)
            {
                return false;
            }

            if (horario.Estado != "Libre")
            {
                return false;
            }

            cita.Codigo = GenerarCodigoCita();
            cita.Estado = "Pendiente";

            ListaCitas.Add(cita);

            horario.Estado = "Reservado";

            return true;
        }

        public bool MarcarCitaComoAtendida(int codigoCita)
        {
            CCita cita = ListaCitas.Find(c => c.Codigo == codigoCita);

            if (cita == null)
            {
                return false;
            }

            cita.Estado = "Atendido";
            return true;
        }

        public bool CancelarCita(int codigoCita)
        {
            CCita cita = ListaCitas.Find(c => c.Codigo == codigoCita);

            if (cita == null)
            {
                return false;
            }

            cita.Estado = "Cancelado";

            CHorarioConsultor horario = ListaHorarios.Find(h => h.Codigo == cita.CodigoHorario);

            if (horario != null)
            {
                horario.Estado = "Libre";
            }

            return true;
        }

        public List<CCita> ListarCitasPorCliente(int codigoCliente)
        {
            return ListaCitas
                .Where(c => c.CodigoCliente == codigoCliente)
                .ToList();
        }

        public List<CCita> ListarCitasPorConsultor(int codigoConsultor)
        {
            var horariosDelConsultor = ListaHorarios
                .Where(h => h.CodigoConsultor == codigoConsultor)
                .Select(h => h.Codigo)
                .ToList();

            return ListaCitas
                .Where(c => horariosDelConsultor.Contains(c.CodigoHorario))
                .ToList();
        }

        public List<CHorarioConsultor> ListarHorariosLibres(int codigoConsultor)
        {
            return ListaHorarios
                .Where(h => h.CodigoConsultor == codigoConsultor && h.Estado == "Libre")
                .ToList();
        }

        private bool ExisteDni(string dni)
        {
            bool existeAdmin = ListaAdministradores.Any(a => a.Dni == dni);
            bool existeConsultor = ListaConsultores.Any(c => c.Dni == dni);
            bool existeCliente = ListaClientes.Any(c => c.Dni == dni);

            return existeAdmin || existeConsultor || existeCliente;
        }

        private int GenerarCodigoCliente()
        {
            if (ListaClientes.Count == 0)
            {
                return 1;
            }

            return ListaClientes.Max(c => c.Codigo) + 1;
        }

        private int GenerarCodigoConsultor()
        {
            if (ListaConsultores.Count == 0)
            {
                return 1;
            }

            return ListaConsultores.Max(c => c.Codigo) + 1;
        }

        private int GenerarCodigoHorario()
        {
            if (ListaHorarios.Count == 0)
            {
                return 1;
            }

            return ListaHorarios.Max(h => h.Codigo) + 1;
        }

        private int GenerarCodigoCita()
        {
            if (ListaCitas.Count == 0)
            {
                return 1;
            }

            return ListaCitas.Max(c => c.Codigo) + 1;
        }
    }
}
