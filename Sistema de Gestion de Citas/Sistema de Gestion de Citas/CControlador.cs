using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Citas
{
    public class CCitaDetallada
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Consultor { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }

    public class CControlador
    {
        public static bool ValidarDni(string dni)
        {
            if (dni.Length < 8)
            {
                return false;
            }

            foreach (char c in dni)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

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
                    "Masculino",
                    "999000000",
                    "admin@sistema.com",
                    "1"
                ));
            }
            if (ListaClientes.Count == 0)
            {
                ListaClientes.Add(new CCliente(1, "Kevin", "111", "Masculino", "999111222", "kevin@gmail.com", "123"));
                ListaClientes.Add(new CCliente(2, "Guiso", "22222222", "Masculino", "999333444", "guiso@gmail.com", "123"));
                ListaClientes.Add(new CCliente(3, "Lucia", "33333333", "Femenino", "999555666", "lucia@gmail.com", "123"));
                ListaClientes.Add(new CCliente(4, "Maria", "44441111", "Femenino", "999777888", "maria@gmail.com", "123"));
            }
            
            if (ListaConsultores.Count == 0)
            {
                ListaConsultores.Add(new CConsultor(1, "Pedro Ramos", "4", "Masculino", "988111222", "pedro@gmail.com", "Legal", "Abogado especialista en derecho civil", "4", 100));
                ListaConsultores.Add(new CConsultor(2, "Ana Torres", "5", "Femenino", "988333444", "ana@gmail.com", "Contable", "Contadora especializada en impuestos", "5", 150));
                ListaConsultores.Add(new CConsultor(3, "Carlos Vega", "66666666", "Masculino", "988555666", "carlos@gmail.com", "Psicologia", "Psicologo clinico", "123", 120));
                ListaConsultores.Add(new CConsultor(4, "Rosa Flores", "77777777", "Femenino", "988777888", "rosa@gmail.com", "Tecnologico", "Consultora en sistemas", "123", 200));
                ListaConsultores.Add(new CConsultor(5, "Luis Pena", "88888888", "Masculino", "988999000", "luis@gmail.com", "Legal", "Asesor legal empresarial", "123", 100));
                ListaConsultores.Add(new CConsultor(6, "Maria Gutierrez", "99999999", "Femenino", "987654321", "maria.g@gmail.com", "Docencia", "Tutora y docente universitaria", "123", 80));
            }
            if (ListaHorarios.Count == 0)
            {
                int ultimoID = GenerarIDHorario();
                foreach (CConsultor consultor in ListaConsultores)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        ultimoID = consultor.GenerarHorarios(DateTime.Today.AddDays(i), ultimoID);
                    }
                    
                    ultimoID = consultor.GenerarHorarios(DateTime.Today.AddDays(-1), ultimoID);
                    ultimoID = consultor.GenerarHorarios(DateTime.Today.AddDays(-2), ultimoID);

                    foreach (CHorarioConsultor h in consultor.ListaHorarios)
                    {
                        if (ListaHorarios.Contains(h) == false)
                        {
                            ListaHorarios.Add(h);
                        }
                    }
                }
            }

            if (ListaCitas.Count == 0)
            {
                AgregarCitaHistorica(1, 1, 100, "Asesoria Marzo 1", new DateTime(2026, 3, 10, 10, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Marzo 2", new DateTime(2026, 3, 15, 11, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Marzo 3", new DateTime(2026, 3, 20, 12, 0, 0));

                AgregarCitaHistorica(1, 1, 100, "Asesoria Abril", new DateTime(2026, 4, 10, 10, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Mayo 1", new DateTime(2026, 5, 5, 11, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Mayo 2", new DateTime(2026, 5, 15, 12, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Junio 1", new DateTime(2026, 6, 1, 10, 0, 0));
                AgregarCitaHistorica(1, 1, 100, "Asesoria Junio 2", new DateTime(2026, 6, 10, 11, 0, 0));

                AgregarCitaFicticiaPorConsultor(2, 2, 150, "Consulta contable", "Atendido");
                AgregarCitaFicticiaPorConsultor(3, 3, 120, "Orientacion psicologica", "Atendido");

                AgregarCitaHistorica(1, 6, 80, "Tutoria academica 1", new DateTime(2026, 3, 5, 9, 0, 0));
                AgregarCitaHistorica(2, 6, 80, "Tutoria academica 2", new DateTime(2026, 4, 12, 10, 0, 0));
                AgregarCitaHistorica(3, 6, 80, "Tutoria academica 3", new DateTime(2026, 5, 20, 11, 0, 0));
                AgregarCitaFicticiaPorConsultor(4, 4, 200, "Soporte tecnologico", "Atendido");
            }

            ActualizarListaRubros();
        }

        private void AgregarCitaHistorica(int IDCliente, int IDConsultor, decimal monto, string descripcion, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            CCliente cliente = ListaClientes.Find(delegate (CCliente c)
            {
                return c.ID == IDCliente;
            });

            if (consultor == null)
            {
                return;
            }

            if (cliente == null)
            {
                return;
            }

            int idHorario = GenerarIDHorario();
            CHorarioConsultor horario = new CHorarioConsultor(idHorario, IDConsultor, fecha, fecha.AddHours(1), "Ocupado");
            ListaHorarios.Add(horario);
            consultor.ListaHorarios.Add(horario);

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

        private void ActualizarListaRubros()
        {
            ListaRubros.Clear();
            foreach (CConsultor consultor in ListaConsultores)
            {
                CRubro rubro = ListaRubros.Find(delegate (CRubro r)
                {
                    return r.Nombre == consultor.Rubro;
                });

                if (rubro == null)
                {
                    rubro = new CRubro(consultor.Rubro);
                    ListaRubros.Add(rubro);
                }
                
                if (rubro.ListaConsultores.Contains(consultor) == false)
                {
                    rubro.ListaConsultores.Add(consultor);
                }
            }
        }

        public object Login(string dni, string contrasena)
        {
            CAdministrador admin = ListaAdministradores.Find(delegate (CAdministrador a)
            {
                return a.Dni == dni && a.Contrasena == contrasena;
            });

            if (admin != null)
            {
                return admin;
            }

            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.Dni == dni && c.Contrasena == contrasena;
            });

            if (consultor != null)
            {
                return consultor;
            }

            CCliente cliente = ListaClientes.Find(delegate (CCliente c)
            {
                return c.Dni == dni && c.Contrasena == contrasena;
            });

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

            CRubro rubro = ListaRubros.Find(delegate (CRubro r)
            {
                return r.Nombre == consultor.Rubro;
            });

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
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == id;
            });

            if (consultor == null)
            {
                return false;
            }

            consultor.Estado = "Eliminado";

            return true;
        }

        public bool HabilitarConsultor(int id)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == id;
            });

            if (consultor == null)
            {
                return false;
            }

            consultor.Estado = "Activo";

            return true;
        }

        public List<CConsultor> BuscarConsultoresPorRubro(string nombreRubro)
        {
            CRubro rubro = ListaRubros.Find(delegate (CRubro r)
            {

                string nombreR = r.Nombre.ToLower();
                string nombreB = nombreRubro.ToLower();
                return nombreR.Contains(nombreB);
            });

            if (rubro != null)
            {
                return rubro.ListaConsultores;
            }
            else
            {
                return new List<CConsultor>();
            }
        }

        public void GenerarHorarios(int IDConsultor, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            if (consultor != null)
            {
                int ultimoID = GenerarIDHorario();
                ultimoID = consultor.GenerarHorarios(fecha, ultimoID);
                
                foreach (CHorarioConsultor h in consultor.ListaHorarios)
                {
                    if (ListaHorarios.Contains(h) == false)
                    {
                        ListaHorarios.Add(h);
                    }
                }
            }
        }

        public bool ReservarCita(CCita cita)
        {
            CHorarioConsultor horario = ListaHorarios.Find(delegate (CHorarioConsultor h)
            {
                return h.ID == cita.IDHorario;
            });

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

            CCliente cliente = ListaClientes.Find(delegate (CCliente c)
            {
                return c.ID == cita.IDCliente;
            });

            if (cliente != null)
            {
                cliente.AgregarCita(cita);
                horario.Reservar(cita, cliente);
            }

            return true;
        }

        public bool MarcarCitaComoAtendida(int idCita)
        {
            CCita cita = ListaCitas.Find(delegate (CCita c)
            {
                return c.ID == idCita;
            });

            if (cita == null)
            {
                return false;
            }

            cita.Atender();
            return true;
        }

        public bool CancelarCita(int idCita)
        {
            CCita cita = ListaCitas.Find(delegate (CCita c)
            {
                return c.ID == idCita;
            });

            if (cita == null)
            {
                return false;
            }

            cita.Cancelar();

            CHorarioConsultor horario = ListaHorarios.Find(delegate (CHorarioConsultor h)
            {
                return h.ID == cita.IDHorario;
            });

            if (horario != null)
            {
                horario.Liberar();
            }

            return true;
        }

        public List<CCita> ListarCitasPorCliente(int IDCliente)
        {
            CCliente cliente = ListaClientes.Find(delegate (CCliente c)
            {
                return c.ID == IDCliente;
            });

            if (cliente != null)
            {
                return cliente.ListarCitas();
            }
            else
            {
                return new List<CCita>();
            }
        }

        public List<object> ListarCitasDetalladasPorCliente(int IDCliente)
        {
            List<object> reporte = new List<object>();

            foreach (CCita cita in ListaCitas)
            {
                if (cita.IDCliente == IDCliente)
                {
                   
                    CHorarioConsultor horarioEncontrado = null;
                    foreach (CHorarioConsultor horario in ListaHorarios)
                    {
                        if (horario.ID == cita.IDHorario)
                        {
                            horarioEncontrado = horario;
                            break;
                        }
                    }

                    if (horarioEncontrado != null)
                    {
                        
                        CConsultor consultorEncontrado = null;
                        foreach (CConsultor consultor in ListaConsultores)
                        {
                            if (consultor.ID == horarioEncontrado.IDConsultor)
                            {
                                consultorEncontrado = consultor;
                                break;
                            }
                        }

                        if (consultorEncontrado != null)
                        {
                            CCitaDetallada item = new CCitaDetallada();
                            item.ID = cita.ID;
                            item.Fecha = horarioEncontrado.FechaHoraInicio;
                            item.Consultor = consultorEncontrado.Nombre;
                            item.Monto = cita.Monto;
                            item.Descripcion = cita.Descripcion;
                            item.Estado = cita.Estado;

                            reporte.Add(item);
                        }
                    }
                }
            }

            return reporte;
        }

        public List<CCita> ListarCitasPorConsultor(int IDConsultor)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            if (consultor != null)
            {
                return consultor.ListarCitas();
            }
            else
            {
                return new List<CCita>();
            }
        }

        public List<CHorarioConsultor> ListarHorariosLibres(int IDConsultor)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            if (consultor != null)
            {
                return consultor.ListarHorariosLibres();
            }
            else
            {
                return new List<CHorarioConsultor>();
            }
        }


        public List<CHorarioConsultor> ListarHorariosLibres(int IDConsultor, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            if (consultor != null)
            {
                return consultor.ListarHorariosLibres(fecha);
            }
            else
            {
                return new List<CHorarioConsultor>();
            }
        }

        public List<CHorarioConsultor> ListarTodosLosHorarios(int IDConsultor)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            if (consultor != null)
            {
                return consultor.ListaHorarios;
            }
            else
            {
                return new List<CHorarioConsultor>();
            }
        }

        public List<CHorarioConsultor> ListarTodosLosHorarios(int IDConsultor, DateTime fecha)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            List<CHorarioConsultor> listaFiltrada = new List<CHorarioConsultor>();

            if (consultor == null)
            {
                return listaFiltrada;
            }

            foreach (CHorarioConsultor h in consultor.ListaHorarios)
            {
                if (h.FechaHoraInicio.Date == fecha.Date)
                {
                    listaFiltrada.Add(h);
                }
            }

            return listaFiltrada;
        }

        private bool ExisteDni(string dni)
        {
            bool existe = false;

            foreach (CAdministrador a in ListaAdministradores)
            {
                if (a.Dni == dni)
                {
                    existe = true;
                }
            }

            foreach (CConsultor c in ListaConsultores)
            {
                if (c.Dni == dni)
                {
                    existe = true;
                }
            }

            foreach (CCliente c in ListaClientes)
            {
                if (c.Dni == dni)
                {
                    existe = true;
                }
            }

            return existe;
        }

        private int GenerarIDCliente()
        {
            if (ListaClientes.Count == 0)
            {
                return 1;
            }

            int maxID = 0;
            foreach (CCliente c in ListaClientes)
            {
                if (c.ID > maxID)
                {
                    maxID = c.ID;
                }
            }

            return maxID + 1;
        }

        private int GenerarIDConsultor()
        {
            if (ListaConsultores.Count == 0)
            {
                return 1;
            }

            int maxID = 0;
            foreach (CConsultor c in ListaConsultores)
            {
                if (c.ID > maxID)
                {
                    maxID = c.ID;
                }
            }

            return maxID + 1;
        }

        private int GenerarIDHorario()
        {
            if (ListaHorarios.Count == 0)
            {
                return 1;
            }

            int maxID = 0;
            foreach (CHorarioConsultor h in ListaHorarios)
            {
                if (h.ID > maxID)
                {
                    maxID = h.ID;
                }
            }

            return maxID + 1;
        }

        private int GenerarIDCita()
        {
            if (ListaCitas.Count == 0)
            {
                return 1;
            }

            int maxID = 0;
            foreach (CCita c in ListaCitas)
            {
                if (c.ID > maxID)
                {
                    maxID = c.ID;
                }
            }

            return maxID + 1;
        }
        
        private void AgregarCitaFicticiaPorConsultor(int IDCliente, int IDConsultor, decimal monto, string descripcion, string estado)
        {
            CConsultor consultor = ListaConsultores.Find(delegate (CConsultor c)
            {
                return c.ID == IDConsultor;
            });

            if (consultor == null)
            {
                return;
            }

            CHorarioConsultor horarioEncontrado = null;
            foreach (CHorarioConsultor h in ListaHorarios)
            {
                if (h.IDConsultor == IDConsultor)
                {
                    if (h.Estado == "Libre")
                    {
                        horarioEncontrado = h;
                        break;
                    }
                }
            }

            if (horarioEncontrado == null)
            {
                return;
            }

            CCita cita = new CCita();

            cita.ID = GenerarIDCita();
            cita.IDCliente = IDCliente;
            cita.IDHorario = horarioEncontrado.ID;
            cita.Monto = consultor.Monto; 
            cita.Descripcion = descripcion;
            cita.Estado = estado;

            ListaCitas.Add(cita);

            CCliente cliente = ListaClientes.Find(delegate (CCliente c)
            {
                return c.ID == IDCliente;
            });

            if (cliente != null)
            {
                cliente.AgregarCita(cita);
                horarioEncontrado.Reservar(cita, cliente);
            }
        }
    }
}
