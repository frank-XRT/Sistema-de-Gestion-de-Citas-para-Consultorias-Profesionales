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
        public static List<CRubro> ListaRubros = new List<CRubro>();

        public CControlador()
        {
            CargarAdministradorInicial();
        }

        private void CargarAdministradorInicial()
        {
            // ADMINISTRADOR
            if (ListaAdministradores.Count == 0)
            {
                ListaAdministradores.Add(new CAdministrador(
                    1,
                    "Administrador",
                    "1",
                    "1"
                ));
            }
            
            
            

            // CLIENTES
            if (ListaClientes.Count == 0)
            {
                ListaClientes.Add(new CCliente(1, "Kevin", "111", "Masculino", "999111222", "kevin@gmail.com", "123"));
                ListaClientes.Add(new CCliente(2, "Guiso", "22222222", "Masculino", "999333444", "guiso@gmail.com", "123"));
                ListaClientes.Add(new CCliente(3, "Lucía", "33333333", "Femenino", "999555666", "lucia@gmail.com", "123"));
                ListaClientes.Add(new CCliente(4, "María", "44441111", "Femenino", "999777888", "maria@gmail.com", "123"));
            }
            

            // CONSULTORES
            if (ListaConsultores.Count == 0)
            {
                ListaConsultores.Add(new CConsultor(1, "Pedro Ramos", "4", "Masculino", "988111222", "pedro@gmail.com", "Legal", "Abogado especialista en derecho civil", "4", 100));
                ListaConsultores.Add(new CConsultor(2, "Ana Torres", "5", "Femenino", "988333444", "ana@gmail.com", "Contable", "Contadora especializada en impuestos", "5", 150));
                ListaConsultores.Add(new CConsultor(3, "Carlos Vega", "66666666", "Masculino", "988555666", "carlos@gmail.com", "Psicología", "Psicólogo clínico", "123", 120));
                ListaConsultores.Add(new CConsultor(4, "Rosa Flores", "77777777", "Femenino", "988777888", "rosa@gmail.com", "Tecnológico", "Consultora en sistemas", "123", 200));
                ListaConsultores.Add(new CConsultor(5, "Luis Peña", "88888888", "Masculino", "988999000", "luis@gmail.com", "Legal", "Asesor legal empresarial", "123", 100));
            }

            // HORARIOS
            if (ListaHorarios.Count == 0)
            {
                int ultimoCodigo = GenerarCodigoHorario();
                foreach (CConsultor consultor in ListaConsultores)
                {
                    // Generar horarios para los próximos 30 días
                    for (int i = 0; i < 30; i++)
                    {
                        consultor.GenerarHorarios(DateTime.Today.AddDays(i), ref ultimoCodigo);
                    }
                    
                    // También generar para un par de días pasados por si acaso hay citas registradas ahí
                    consultor.GenerarHorarios(DateTime.Today.AddDays(-1), ref ultimoCodigo);
                    consultor.GenerarHorarios(DateTime.Today.AddDays(-2), ref ultimoCodigo);

                    // Sincronizar con la lista global (para compatibilidad)
                    foreach (var h in consultor.ListaHorarios)
                    {
                        if (!ListaHorarios.Contains(h)) ListaHorarios.Add(h);
                    }
                }
            }

            // CITAS FICTICIAS PARA REPORTES
            if (ListaCitas.Count == 0)
            {
                AgregarCitaFicticiaPorConsultor(1, 1, 100, "Asesoría legal civil", "Atendido");
                AgregarCitaFicticiaPorConsultor(2, 2, 150, "Consulta contable", "Atendido");
                AgregarCitaFicticiaPorConsultor(3, 3, 120, "Orientación psicológica", "Atendido");
                AgregarCitaFicticiaPorConsultor(4, 4, 200, "Soporte tecnológico", "Atendido");

                AgregarCitaFicticiaPorConsultor(1, 1, 100, "Contrato empresarial", "Pendiente");
                AgregarCitaFicticiaPorConsultor(2, 2, 150, "Declaración de impuestos", "Atendido");
                AgregarCitaFicticiaPorConsultor(3, 3, 120, "Consulta de ansiedad", "Pendiente");
                AgregarCitaFicticiaPorConsultor(4, 4, 200, "Configuración de software", "Atendido");

                AgregarCitaFicticiaPorConsultor(1, 5, 100, "Problema legal familiar", "Atendido");
                AgregarCitaFicticiaPorConsultor(2, 2, 150, "Revisión de balances", "Cancelado");
            }

            // MULTILISTA: Organizar rubros e inicializar sus listas
            ActualizarListaRubros();
        }

        private void ActualizarListaRubros()
        {
            ListaRubros.Clear();
            foreach (var consultor in ListaConsultores)
            {
                CRubro rubro = ListaRubros.Find(r => r.Nombre == consultor.Rubro);
                if (rubro == null)
                {
                    rubro = new CRubro(consultor.Rubro);
                    ListaRubros.Add(rubro);
                }
                if (!rubro.ListaConsultores.Contains(consultor))
                {
                    rubro.ListaConsultores.Add(consultor);
                }
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

            // MULTILISTA: Agregar al rubro correspondiente
            CRubro rubro = ListaRubros.Find(r => r.Nombre == consultor.Rubro);
            if (rubro == null)
            {
                rubro = new CRubro(consultor.Rubro);
                ListaRubros.Add(rubro);
            }
            rubro.AgregarConsultor(consultor);

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

            // MULTILISTA: Eliminar del rubro
            CRubro rubro = ListaRubros.Find(r => r.Nombre == consultor.Rubro);
            if (rubro != null)
            {
                rubro.ListaConsultores.Remove(consultor);
            }

            ListaHorarios.RemoveAll(h => h.CodigoConsultor == codigo);

            return true;
        }

        public List<CConsultor> BuscarConsultoresPorRubro(string nombreRubro)
        {
            // MULTILISTA: Buscar directamente en la lista del rubro
            CRubro rubro = ListaRubros.Find(r => r.Nombre.ToLower().Contains(nombreRubro.ToLower()));
            return rubro != null ? rubro.ListaConsultores : new List<CConsultor>();
        }

        public void GenerarHorarios(int codigoConsultor, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            if (consultor != null)
            {
                int ultimoCodigo = GenerarCodigoHorario();
                consultor.GenerarHorarios(fecha, ref ultimoCodigo);
                
                // Sincronizar lista global
                foreach (var h in consultor.ListaHorarios)
                {
                    if (!ListaHorarios.Contains(h)) ListaHorarios.Add(h);
                }
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

            // MULTILISTA y DELEGACIÓN: Agregar a la lista del cliente y vincular
            CCliente cliente = ListaClientes.Find(c => c.Codigo == cita.CodigoCliente);
            if (cliente != null)
            {
                cliente.AgregarCita(cita);
                horario.Reservar(cita, cliente);
            }

            return true;
        }

        public bool MarcarCitaComoAtendida(int codigoCita)
        {
            CCita cita = ListaCitas.Find(c => c.Codigo == codigoCita);

            if (cita == null)
            {
                return false;
            }

            // DELEGACIÓN: La cita sabe cómo marcarse como atendida
            cita.Atender();
            return true;
        }

        public bool CancelarCita(int codigoCita)
        {
            CCita cita = ListaCitas.Find(c => c.Codigo == codigoCita);

            if (cita == null)
            {
                return false;
            }

            // DELEGACIÓN: La cita sabe cancelarse
            cita.Cancelar();

            CHorarioConsultor horario = ListaHorarios.Find(h => h.Codigo == cita.CodigoHorario);

            if (horario != null)
            {
                // DELEGACIÓN: El horario sabe liberarse
                horario.Liberar();
            }

            return true;
        }

        public List<CCita> ListarCitasPorCliente(int codigoCliente)
        {
            // DELEGACIÓN: El cliente sabe listar sus citas
            CCliente cliente = ListaClientes.Find(c => c.Codigo == codigoCliente);
            return cliente != null ? cliente.ListarCitas() : new List<CCita>();
        }

        public List<object> ListarCitasDetalladasPorCliente(int codigoCliente)
        {
            var reporte = from cita in ListaCitas
                          join horario in ListaHorarios
                          on cita.CodigoHorario equals horario.Codigo
                          join consultor in ListaConsultores
                          on horario.CodigoConsultor equals consultor.Codigo
                          where cita.CodigoCliente == codigoCliente
                          select new
                          {
                              Fecha = horario.FechaHoraInicio,
                              Consultor = consultor.Nombre,
                              Monto = cita.Monto,
                              Descripcion = cita.Descripcion,
                              Estado = cita.Estado
                          };

            return reporte.Cast<object>().ToList();
        }

        public List<CCita> ListarCitasPorConsultor(int codigoConsultor)
        {
            // DELEGACIÓN: El consultor sabe listar sus citas
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            return consultor != null ? consultor.ListarCitas() : new List<CCita>();
        }

        public List<CHorarioConsultor> ListarHorariosLibres(int codigoConsultor)
        {
            // DELEGACIÓN: El consultor sabe listar sus horarios libres
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            return consultor != null ? consultor.ListarHorariosLibres() : new List<CHorarioConsultor>();
        }


        public List<CHorarioConsultor> ListarHorariosLibres(int codigoConsultor, DateTime fecha)
        {
            // DELEGACIÓN: El consultor sabe listar sus horarios libres por fecha
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            return consultor != null ? consultor.ListarHorariosLibres(fecha) : new List<CHorarioConsultor>();
        }





        public List<CHorarioConsultor> ListarTodosLosHorarios(int codigoConsultor)
        {
            // MULTILISTA: Obtener de la lista del consultor
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            return consultor != null ? consultor.ListaHorarios : new List<CHorarioConsultor>();
        }

        public List<CHorarioConsultor> ListarTodosLosHorarios(int codigoConsultor, DateTime fecha)
        {
            // MULTILISTA: Obtener de la lista del consultor
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            if (consultor == null) return new List<CHorarioConsultor>();

            return consultor.ListaHorarios
                .Where(h => h.FechaHoraInicio.Date == fecha.Date)
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
        private void AgregarCitaFicticiaPorConsultor(int codigoCliente, int codigoConsultor, decimal monto, string descripcion, string estado)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.Codigo == codigoConsultor);
            if (consultor == null) return;

            CHorarioConsultor horario = ListaHorarios.FirstOrDefault(h =>
                h.CodigoConsultor == codigoConsultor &&
                h.Estado == "Libre");

            if (horario == null)
            {
                return;
            }


            CCita cita = new CCita();

            cita.Codigo = GenerarCodigoCita();
            cita.CodigoCliente = codigoCliente;
            cita.CodigoHorario = horario.Codigo;
            cita.Monto = consultor.Monto; // Usar el monto del consultor
            cita.Descripcion = descripcion;
            cita.Estado = estado;

            ListaCitas.Add(cita);

            // MULTILISTA y DELEGACIÓN: Vincular cita con el horario y el cliente
            CCliente cliente = ListaClientes.Find(c => c.Codigo == codigoCliente);
            if (cliente != null)
            {
                cliente.AgregarCita(cita);
                horario.Reservar(cita, cliente);
            }
        }
    }
}
