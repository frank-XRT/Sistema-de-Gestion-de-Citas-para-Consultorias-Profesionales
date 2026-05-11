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

        // ===========================================================================
        // SECCION: CARGA DE DATOS FICTICIOS (solo para pruebas y demostracion)
        // ===========================================================================
        private void CargarAdministradorInicial()
        {
            // ADMINISTRADOR
            if (ListaAdministradores.Count == 0)
            {
                ListaAdministradores.Add(new CAdministrador(
                    1,
                    "Administrador",
                    "1",
                    "Masculino",
                    "999000000",
                    "admin@sistema.com",
                    "1"
                ));
            }
            
            
            

            // CLIENTES
            if (ListaClientes.Count == 0)
            {
                ListaClientes.Add(new CCliente(1, "Kevin", "111", "Masculino", "999111222", "kevin@gmail.com", "123"));
                ListaClientes.Add(new CCliente(2, "Guiso", "22222222", "Masculino", "999333444", "guiso@gmail.com", "123"));
                ListaClientes.Add(new CCliente(3, "Lucia", "33333333", "Femenino", "999555666", "lucia@gmail.com", "123"));
                ListaClientes.Add(new CCliente(4, "Maria", "44441111", "Femenino", "999777888", "maria@gmail.com", "123"));
            }
            

            // CONSULTORES
            if (ListaConsultores.Count == 0)
            {
                ListaConsultores.Add(new CConsultor(1, "Pedro Ramos", "4", "Masculino", "988111222", "pedro@gmail.com", "Legal", "Abogado especialista en derecho civil", "4", 100));
                ListaConsultores.Add(new CConsultor(2, "Ana Torres", "5", "Femenino", "988333444", "ana@gmail.com", "Contable", "Contadora especializada en impuestos", "5", 150));
                ListaConsultores.Add(new CConsultor(3, "Carlos Vega", "66666666", "Masculino", "988555666", "carlos@gmail.com", "Psicologia", "Psicologo clinico", "123", 120));
                ListaConsultores.Add(new CConsultor(4, "Rosa Flores", "77777777", "Femenino", "988777888", "rosa@gmail.com", "Tecnologico", "Consultora en sistemas", "123", 200));
                ListaConsultores.Add(new CConsultor(5, "Luis Pena", "88888888", "Masculino", "988999000", "luis@gmail.com", "Legal", "Asesor legal empresarial", "123", 100));
                ListaConsultores.Add(new CConsultor(6, "Maria Gutierrez", "99999999", "Femenino", "987654321", "maria.g@gmail.com", "Docencia", "Tutora y docente universitaria", "123", 80));
            }

            // HORARIOS
            if (ListaHorarios.Count == 0)
            {
                int ultimoID = GenerarIDHorario();
                foreach (CConsultor consultor in ListaConsultores)
                {
                    // Generar horarios para los proximos 30 dias
                    for (int i = 0; i < 30; i++)
                    {
                        consultor.GenerarHorarios(DateTime.Today.AddDays(i), ref ultimoID);
                    }
                    
                    // Tambien generar para un par de dias pasados por si acaso hay citas registradas ahi
                    consultor.GenerarHorarios(DateTime.Today.AddDays(-1), ref ultimoID);
                    consultor.GenerarHorarios(DateTime.Today.AddDays(-2), ref ultimoID);

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
                // Trimestre 1: Marzo (3 citas)
                AgregarCitaHistorica(1, 1, 100, "Asesoria Marzo 1", new DateTime(2026, 3, 10, 10, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Marzo 2", new DateTime(2026, 3, 15, 11, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Marzo 3", new DateTime(2026, 3, 20, 12, 0, 0));

                // Trimestre 2: Abril, Mayo, Junio (5 citas)
                AgregarCitaHistorica(1, 1, 100, "Asesoria Abril", new DateTime(2026, 4, 10, 10, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Mayo 1", new DateTime(2026, 5, 5, 11, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Mayo 2", new DateTime(2026, 5, 15, 12, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Junio 1", new DateTime(2026, 6, 1, 10, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Junio 2", new DateTime(2026, 6, 10, 11, 0, 0));

                // Otras citas base
                AgregarCitaFicticiaPorConsultor(2, 2, 150, "Consulta contable", "Atendido");
                AgregarCitaFicticiaPorConsultor(3, 3, 120, "Orientacion psicologica", "Atendido");

                // Area de Educacion y Sociedad (3 citas para Maria Gutierrez)
                AgregarCitaHistorica(1, 6, 80, "Tutoria academica 1", new DateTime(2026, 3, 5, 9, 0, 0));
                AgregarCitaHistorica(2, 6, 80, "Tutoria academica 2", new DateTime(2026, 4, 12, 10, 0, 0));
                AgregarCitaHistorica(3, 6, 80, "Tutoria academica 3", new DateTime(2026, 5, 20, 11, 0, 0));
                AgregarCitaFicticiaPorConsultor(4, 4, 200, "Soporte tecnologico", "Atendido");
            }

            // MULTILISTA: Organizar rubros e inicializar sus listas
            ActualizarListaRubros();
        }

        // ===========================================================================
        // SECCION: METODOS AUXILIARES PARA DATOS FICTICIOS
        // Solo se usan en CargarAdministradorInicial() para crear datos de prueba
        // ===========================================================================
        private void AgregarCitaHistorica(int IDCliente, int IDConsultor, decimal monto, string descripcion, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            CCliente cliente = ListaClientes.Find(c => c.ID == IDCliente);
            if (consultor == null || cliente == null) return;

            // Crear horario en el pasado
            int idHorario = GenerarIDHorario();
            CHorarioConsultor horario = new CHorarioConsultor(idHorario, IDConsultor, fecha, fecha.AddHours(1), "Ocupado");
            ListaHorarios.Add(horario);
            consultor.ListaHorarios.Add(horario);

            // Crear cita atendida
            CCita cita = new CCita();
            cita.ID = GenerarIDCita();
            cita.IDCliente = IDCliente;
            cita.IDHorario = horario.ID;
            cita.Monto = monto;
            cita.Descripcion = descripcion;
            cita.Estado = "Atendido";
            
            ListaCitas.Add(cita);
            cliente.AgregarCita(cita);
            horario.Reservar(cita, cliente);
        }

        // ===========================================================================
        // SECCION: MULTILISTA - Organizacion de rubros
        // Se usa en la carga inicial y al registrar/eliminar consultores
        // ===========================================================================
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

        // ===========================================================================
        // SECCION: LOGIN (usado por Administrador, Consultor y Cliente)
        // ===========================================================================
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

        // ===========================================================================
        // SECCION: ADMINISTRADOR - Registro, eliminacion y busqueda
        // ===========================================================================
        public bool RegistrarCliente(CCliente cliente)
        {
            if (ExisteDni(cliente.Dni))
            {
                return false;
            }

            cliente.ID = GenerarIDCliente();
            ListaClientes.Add(cliente);
            return true;
        }

        public bool RegistrarConsultor(CConsultor consultor)
        {
            if (ExisteDni(consultor.Dni))
            {
                return false;
            }

            consultor.ID = GenerarIDConsultor();
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

        public bool EliminarConsultor(int id)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.ID == id);

            if (consultor == null)
            {
                return false;
            }

            consultor.Estado = "Eliminado";

            return true;
        }

        public bool HabilitarConsultor(int id)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.ID == id);

            if (consultor == null)
            {
                return false;
            }

            consultor.Estado = "Activo";

            return true;
        }

        public List<CConsultor> BuscarConsultoresPorRubro(string nombreRubro)
        {
            // MULTILISTA: Buscar directamente en la lista del rubro
            CRubro rubro = ListaRubros.Find(r => r.Nombre.ToLower().Contains(nombreRubro.ToLower()));
            return rubro != null ? rubro.ListaConsultores : new List<CConsultor>();
        }

        public void GenerarHorarios(int IDConsultor, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            if (consultor != null)
            {
                int ultimoID = GenerarIDHorario();
                consultor.GenerarHorarios(fecha, ref ultimoID);
                
                // Sincronizar lista global
                foreach (var h in consultor.ListaHorarios)
                {
                    if (!ListaHorarios.Contains(h)) ListaHorarios.Add(h);
                }
            }
        }



        // ===========================================================================
        // SECCION: CLIENTE - Reservar y cancelar citas
        // ===========================================================================
        public bool ReservarCita(CCita cita)
        {
            CHorarioConsultor horario = ListaHorarios.Find(h => h.ID == cita.IDHorario);

            if (horario == null)
            {
                return false;
            }

            if (horario.Estado != "Libre")
            {
                return false;
            }

            cita.ID = GenerarIDCita();
            cita.Estado = "Pendiente";

            ListaCitas.Add(cita);

            // MULTILISTA y DELEGACIoN: Agregar a la lista del cliente y vincular
            CCliente cliente = ListaClientes.Find(c => c.ID == cita.IDCliente);
            if (cliente != null)
            {
                cliente.AgregarCita(cita);
                horario.Reservar(cita, cliente);
            }

            return true;
        }

        // ===========================================================================
        // SECCION: CONSULTOR - Marcar citas y listar sus citas/horarios
        // ===========================================================================
        public bool MarcarCitaComoAtendida(int idCita)
        {
            CCita cita = ListaCitas.Find(c => c.ID == idCita);

            if (cita == null)
            {
                return false;
            }

            // DELEGACIoN: La cita sabe como marcarse como atendida
            cita.Atender();
            return true;
        }

        public bool CancelarCita(int idCita)
        {
            CCita cita = ListaCitas.Find(c => c.ID == idCita);

            if (cita == null)
            {
                return false;
            }

            // DELEGACIoN: La cita sabe cancelarse
            cita.Cancelar();

            CHorarioConsultor horario = ListaHorarios.Find(h => h.ID == cita.IDHorario);

            if (horario != null)
            {
                // DELEGACIoN: El horario sabe liberarse
                horario.Liberar();
            }

            return true;
        }

        // ===========================================================================
        // SECCION: CLIENTE - Listar citas del cliente
        // ===========================================================================
        public List<CCita> ListarCitasPorCliente(int IDCliente)
        {
            // DELEGACIoN: El cliente sabe listar sus citas
            CCliente cliente = ListaClientes.Find(c => c.ID == IDCliente);
            return cliente != null ? cliente.ListarCitas() : new List<CCita>();
        }

        public List<object> ListarCitasDetalladasPorCliente(int IDCliente)
        {
            var reporte = from cita in ListaCitas
                          join horario in ListaHorarios
                          on cita.IDHorario equals horario.ID
                          join consultor in ListaConsultores
                          on horario.IDConsultor equals consultor.ID
                          where cita.IDCliente == IDCliente
                          select new
                          {
                              ID = cita.ID,
                              Fecha = horario.FechaHoraInicio,
                              Consultor = consultor.Nombre,
                              Monto = cita.Monto,
                              Descripcion = cita.Descripcion,
                              Estado = cita.Estado
                          };

            return reporte.Cast<object>().ToList();
        }

        // ===========================================================================
        // SECCION: CONSULTOR - Listar citas y horarios del consultor
        // ===========================================================================
        public List<CCita> ListarCitasPorConsultor(int IDConsultor)
        {
            // DELEGACIoN: El consultor sabe listar sus citas
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            return consultor != null ? consultor.ListarCitas() : new List<CCita>();
        }

        public List<CHorarioConsultor> ListarHorariosLibres(int IDConsultor)
        {
            // DELEGACIoN: El consultor sabe listar sus horarios libres
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            return consultor != null ? consultor.ListarHorariosLibres() : new List<CHorarioConsultor>();
        }


        public List<CHorarioConsultor> ListarHorariosLibres(int IDConsultor, DateTime fecha)
        {
            // DELEGACIoN: El consultor sabe listar sus horarios libres por fecha
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            return consultor != null ? consultor.ListarHorariosLibres(fecha) : new List<CHorarioConsultor>();
        }





        public List<CHorarioConsultor> ListarTodosLosHorarios(int IDConsultor)
        {
            // MULTILISTA: Obtener de la lista del consultor
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            return consultor != null ? consultor.ListaHorarios : new List<CHorarioConsultor>();
        }

        public List<CHorarioConsultor> ListarTodosLosHorarios(int IDConsultor, DateTime fecha)
        {
            // MULTILISTA: Obtener de la lista del consultor
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            if (consultor == null) return new List<CHorarioConsultor>();

            return consultor.ListaHorarios
                .Where(h => h.FechaHoraInicio.Date == fecha.Date)
                .ToList();
        }

        // ===========================================================================
        // SECCION: METODOS PRIVADOS INTERNOS (generadores de ids y validacion)
        // ===========================================================================
        private bool ExisteDni(string dni)
        {
            bool existeAdmin = ListaAdministradores.Any(a => a.Dni == dni);
            bool existeConsultor = ListaConsultores.Any(c => c.Dni == dni);
            bool existeCliente = ListaClientes.Any(c => c.Dni == dni);

            return existeAdmin || existeConsultor || existeCliente;
        }

        private int GenerarIDCliente()
        {
            if (ListaClientes.Count == 0)
            {
                return 1;
            }

            return ListaClientes.Max(c => c.ID) + 1;
        }

        private int GenerarIDConsultor()
        {
            if (ListaConsultores.Count == 0)
            {
                return 1;
            }

            return ListaConsultores.Max(c => c.ID) + 1;
        }

        private int GenerarIDHorario()
        {
            if (ListaHorarios.Count == 0)
            {
                return 1;
            }

            return ListaHorarios.Max(h => h.ID) + 1;
        }

        private int GenerarIDCita()
        {
            if (ListaCitas.Count == 0)
            {
                return 1;
            }

            return ListaCitas.Max(c => c.ID) + 1;
        }
        // ===========================================================================
        // SECCION: METODO AUXILIAR PARA DATOS FICTICIOS
        // Solo se usa en CargarAdministradorInicial() para crear citas de prueba
        // ===========================================================================
        private void AgregarCitaFicticiaPorConsultor(int IDCliente, int IDConsultor, decimal monto, string descripcion, string estado)
        {
            CConsultor consultor = ListaConsultores.Find(c => c.ID == IDConsultor);
            if (consultor == null) return;

            CHorarioConsultor horario = ListaHorarios.FirstOrDefault(h =>
                h.IDConsultor == IDConsultor &&
                h.Estado == "Libre");

            if (horario == null)
            {
                return;
            }


            CCita cita = new CCita();

            cita.ID = GenerarIDCita();
            cita.IDCliente = IDCliente;
            cita.IDHorario = horario.ID;
            cita.Monto = consultor.Monto; // Usar el monto del consultor
            cita.Descripcion = descripcion;
            cita.Estado = estado;

            ListaCitas.Add(cita);

            // MULTILISTA y DELEGACIoN: Vincular cita con el horario y el cliente
            CCliente cliente = ListaClientes.Find(c => c.ID == IDCliente);
            if (cliente != null)
            {
                cliente.AgregarCita(cita);
                horario.Reservar(cita, cliente);
            }
        }
    }
}

