using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDataGridView
{
    // Formulario principal que muestra estadísticas generales del hospital
    public partial class frmPrincipal : Form
    {
        // Lista principal que almacena todos los pacientes del sistema
        // Readonly para evitar que se reasigne la referencia
        private readonly List<Paciente> Pacientes = new List<Paciente>();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Método que actualiza el DataGridView con las estadísticas
        private void RefrescarGrid()
        {
            // Limpiamos el DataSource para forzar una actualización completa
            dgvResumen.DataSource = null;

            // Creamos una lista de objetos anónimos para mostrar las estadísticas
            List<object> estadisticas = new List<object>();

            // Variables para calcular las estadísticas
            int totalPacientes = Pacientes.Count;
            int totalIngresos = 0;
            int pacientesHospitalizados = 0;
            int sumaEdades = 0;

            // Recorremos todos los pacientes para calcular las estadísticas
            foreach (Paciente p in Pacientes)
            {
                // Sumamos todos los ingresos de todos los pacientes
                totalIngresos = totalIngresos + p.Ingresos.Count;

                // Sumamos las edades para calcular el promedio después
                sumaEdades = sumaEdades + p.Edad;

                // Verificamos si el paciente tiene algún ingreso sin fecha de alta (está hospitalizado)
                foreach (Ingreso ing in p.Ingresos)
                {
                    // Si encontramos un ingreso sin fecha de alta, contamos al paciente y salimos del bucle
                    if (ing.FechaAlta == null)
                    {
                        pacientesHospitalizados++;
                        break;
                    }
                }
            }

            // Calculamos la edad promedio
            double edadPromedio = 0;
            if (totalPacientes > 0)
            {
                edadPromedio = (double)sumaEdades / totalPacientes;
            }

            // Agregamos cada estadística como un objeto anónimo le he puesto nombres a las columnas para evitar usar un título
            estadisticas.Add(new { Estadísticas = "Total de pacientes", Hospital = totalPacientes.ToString() });
            estadisticas.Add(new { Estadísticas = "Total de ingresos", Hospital = totalIngresos.ToString() });
            estadisticas.Add(new { Estadísticas = "Pacientes hospitalizados", Hospital = pacientesHospitalizados.ToString() });
            estadisticas.Add(new { Estadísticas = "Edad promedio", Hospital = edadPromedio.ToString("0.0") + " años" });

            // Asignamos la lista de estadísticas al datagrid
            dgvResumen.DataSource = estadisticas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cargamos dummies
            CargarDummies();

            // Mostramos las estadísticas iniciales
            RefrescarGrid();
        }

        private void CargarDummies()
        {
            Pacientes.Add(new Paciente
            {
                Nombre = "Carlos",
                Apellido = "Fernández",
                Edad = 45,
                Ingresos = new List<Ingreso>
                {
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-5),
                        FechaAlta = null, // Sin fecha de alta, sigue hospitalizado
                        Motivo = "Neumonía",
                        Especialidad = "Neumología",
                        Habitacion = "305B"
                    },
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-60),
                        FechaAlta = DateTime.Now.AddDays(-55),
                        Motivo = "Cirugía de rodilla",
                        Especialidad = "Traumatología",
                        Habitacion = "Quirófano 2"
                    }
                }
            });

            Pacientes.Add(new Paciente
            {
                Nombre = "Sofía",
                Apellido = "Martínez",
                Edad = 32,
                Ingresos = new List<Ingreso>
                {
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-2),
                        FechaAlta = null,
                        Motivo = "Embarazo de alto riesgo",
                        Especialidad = "Ginecología",
                        Habitacion = "208C"
                    },
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-90),
                        FechaAlta = DateTime.Now.AddDays(-88),
                        Motivo = "Control prenatal",
                        Especialidad = "Obstetricia",
                        Habitacion = "Consulta 15"
                    }
                }
            });

            Pacientes.Add(new Paciente
            {
                Nombre = "Miguel",
                Apellido = "Torres",
                Edad = 67,
                Ingresos = new List<Ingreso>
                {
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-10),
                        FechaAlta = DateTime.Now.AddDays(-3),
                        Motivo = "Infarto agudo de miocardio",
                        Especialidad = "Cardiología",
                        Habitacion = "UCI 4"
                    },
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-120),
                        FechaAlta = DateTime.Now.AddDays(-118),
                        Motivo = "Revisión cardiovascular",
                        Especialidad = "Cardiología",
                        Habitacion = "Consulta 8"
                    }
                }
            });

            Pacientes.Add(new Paciente
            {
                Nombre = "Laura",
                Apellido = "González",
                Edad = 28,
                Ingresos = new List<Ingreso>
                {
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-1),
                        FechaAlta = null,
                        Motivo = "Apendicitis aguda",
                        Especialidad = "Cirugía General",
                        Habitacion = "412A"
                    },
                    new Ingreso
                    {
                        FechaIngreso = DateTime.Now.AddDays(-30),
                        FechaAlta = DateTime.Now.AddDays(-29),
                        Motivo = "Análisis de laboratorio",
                        Especialidad = "Medicina General",
                        Habitacion = "Consulta 5"
                    }
                }
            });
        }

        private void Pacientes_Click(object sender, EventArgs e)
        {
            // Creamos una nueva instancia del formulario de pacientes
            frmPaciente formPaciente = new frmPaciente();

            // Le pasamos la lista de pacientes para que pueda modificarla por atributo
            formPaciente.Pacientes = Pacientes;

            // Mostramos el formulario como modal
            formPaciente.ShowDialog();

            // Cuando se cierra el formulario de pacientes, actualizamos las estadísticas
            RefrescarGrid();
        }
    }
}