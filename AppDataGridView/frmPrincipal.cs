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
        private DataTableHospital dbHelper;

        public frmPrincipal()
        {
            InitializeComponent();
            dbHelper = new DataTableHospital();
        }

        // Método que actualiza el DataGridView con las estadísticas
        private void RefrescarGrid()
        {
            // Limpiamos el DataSource para forzar una actualización completa
            dgvResumen.DataSource = null;

            // Creamos una lista de objetos anónimos para mostrar las estadísticas
            List<object> estadisticas = new List<object>();

            // Obtenemos los datos necesarios desde la base de datos
            DataTable dtPacientes = dbHelper.ObtenerPacientes();
            DataTable dtIngresos = dbHelper.ObtenerTodosLosIngresos();

            // Variables para calcular las estadísticas
            int totalPacientes = dtPacientes.Rows.Count;
            int totalIngresos = dtIngresos.Rows.Count;
            int pacientesHospitalizados = 0;
            int sumaEdades = 0;

            // Recorremos todos los pacientes para calcular las estadísticas
            // Utilizamos DataRow porque no tenemos modelos
            foreach (DataRow row in dtPacientes.Rows)
            {
                // Sumamos las edades para calcular el promedio después
                sumaEdades += Convert.ToInt32(row["edad"]);
            }
            // Verificamos si el paciente tiene algún ingreso sin fecha de alta (está hospitalizado)
            foreach (DataRow row in dtIngresos.Rows)
            {
                // Si encontramos un ingreso sin fecha de alta, contamos al paciente y salimos del bucle
                if (row["fecha_alta"] == DBNull.Value)
                {
                    pacientesHospitalizados++;
                }
            }
            // Calculamos la edad promedio
            double edadPromedio = 0;
            if (totalPacientes > 0)
            {
                edadPromedio = (double)sumaEdades / totalPacientes;
            }
            // Agregamos las estadísticas a la lista
            estadisticas.Add(new { Estadísticas = "Total de pacientes", Hospital = totalPacientes.ToString() });
            estadisticas.Add(new { Estadísticas = "Total de ingresos", Hospital = totalIngresos.ToString() });
            estadisticas.Add(new { Estadísticas = "Pacientes hospitalizados", Hospital = pacientesHospitalizados.ToString() });
            estadisticas.Add(new { Estadísticas = "Edad promedio", Hospital = edadPromedio.ToString("0.0") + " años" });

            // Asignamos la lista de estadísticas al datagrid
            dgvResumen.DataSource = estadisticas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Mostramos las estadísticas iniciales
            RefrescarGrid();
        }

        private void Pacientes_Click(object sender, EventArgs e)
        {
            // Abrimos el formulario de gestión de pacientes
            frmPaciente formPaciente = new frmPaciente();
            formPaciente.ShowDialog();
            RefrescarGrid();
        }
    }
}