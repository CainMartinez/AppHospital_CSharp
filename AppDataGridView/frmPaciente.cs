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
    // Formulario para gestionar los pacientes del sistema (agregar, editar, eliminar y ver sus ingresos)
    public partial class frmPaciente : Form
    {
        private DataTableHospital dtHospital;

        public frmPaciente()
        {
            InitializeComponent();
            dtHospital = new DataTableHospital();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            // Cargamos los pacientes en el DataGridView
            RefrescarGrid();
        }

        // Método que actualiza el DataGridView con la información de los pacientes
        private void RefrescarGrid()
        {
            // Limpiamos el DataSource para forzar una actualización completa
            dgvPacientes.DataSource = null;

            // Obtenemos los datos de pacientes e ingresos de la base de datos
            DataTable dtPacientes = dtHospital.ObtenerPacientes();
            DataTable dtIngresos = dtHospital.ObtenerTodosLosIngresos();

            // Creamos una lista para almacenar los datos que se mostrarán en el DataGridView
            List<object> datosPacientes = new List<object>();

            // Recorremos cada paciente para contar sus ingresos y preparar los datos
            foreach (DataRow row in dtPacientes.Rows)
            {
                int idPaciente = Convert.ToInt32(row["id"]);
                int numeroIngresos = 0;

                foreach (DataRow ingreso in dtIngresos.Rows)
                {
                    // Contamos los ingresos asociados al paciente actual
                    if (Convert.ToInt32(ingreso["id_paciente"]) == idPaciente)
                    {
                        numeroIngresos++;
                    }
                }

                // Agregamos un objeto anónimo con los datos del paciente y su número de ingresos
                datosPacientes.Add(new
                {
                    Id = idPaciente,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    Edad = Convert.ToInt32(row["edad"]),
                    Ingresos = numeroIngresos
                });
            }

            // Asignamos la lista al DataGridView
            dgvPacientes.DataSource = datosPacientes;
        }

        // Evento del botón "Agregar" para crear un nuevo paciente
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos que los inputs no estén vacíos
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.");
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                MessageBox.Show("La edad es obligatoria.");
            }
            // Si todas las validaciones pasaron, continuamos
            else
            {
                int edad = 0;

                // Intentamos convertir el texto de edad a un número entero
                if (int.TryParse(txtEdad.Text, out edad))
                {
                    // Validamos que la edad esté en un rango válido
                    if (edad < 0 || edad > 110)
                    {
                        MessageBox.Show("La edad debe estar entre 0 y 110 años.");
                    }
                    else
                    {
                        // Agregamos el nuevo paciente a la base de datos
                        dtHospital.AgregarPaciente(txtNombre.Text, txtApellido.Text, edad);
                        RefrescarGrid();
                        txtNombre.Clear();
                        txtApellido.Clear();
                        txtEdad.Clear();
                        // Mostramos mensaje de confirmación
                        MessageBox.Show("Paciente agregado correctamente.");
                    }
                }
                else
                {
                    // Si no se pudo convertir a número, mostramos error
                    MessageBox.Show("La edad debe ser un número válido.");
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Validamos que haya una fila seleccionada
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para editar.");
            }
            // Validamos que los campos no estén vacíos
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.");
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                MessageBox.Show("La edad es obligatoria.");
            }
            // Si todas las validaciones pasaron, continuamos
            else
            {
                int edad = 0;

                // Intentamos convertir el texto de edad a un número
                if (int.TryParse(txtEdad.Text, out edad))
                {
                    // Validamos que la edad esté en un rango válido
                    if (edad < 0 || edad > 110)
                    {
                        MessageBox.Show("La edad debe estar entre 0 y 110 años.");
                    }
                    else
                    {
                        // Obtenemos el ID del paciente seleccionado en el DataGridView
                        int idSeleccionado = (int)dgvPacientes.CurrentRow.Cells["Id"].Value;
                        dtHospital.EditarPaciente(idSeleccionado, txtNombre.Text, txtApellido.Text, edad);
                        // Actualizamos el DataGridView
                        RefrescarGrid();

                        // Mostramos mensaje de confirmación
                        MessageBox.Show("Paciente actualizado correctamente.");
                    }
                }
                else
                {
                    // Si no se pudo convertir a número, mostramos error
                    MessageBox.Show("La edad debe ser un número válido.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validamos que haya una fila seleccionada
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.");
            }
            else
            {
                // Obtenemos el ID del paciente seleccionado
                int idSeleccionado = (int)dgvPacientes.CurrentRow.Cells["Id"].Value;
                string nombre = dgvPacientes.CurrentRow.Cells["Nombre"].Value.ToString();
                string apellido = dgvPacientes.CurrentRow.Cells["Apellido"].Value.ToString();

                // Pedimos confirmación al usuario
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de eliminar al paciente " + nombre + " " + apellido + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo);

                // Si el usuario confirmó la eliminación
                if (resultado == DialogResult.Yes)
                {
                    dtHospital.EliminarPaciente(idSeleccionado);
                    // Actualizamos el DataGridView
                    RefrescarGrid();

                    // Mostramos mensaje de confirmación
                    MessageBox.Show("Paciente eliminado correctamente.");
                }
            }
        }
        // Evento que se ejecuta cuando cambia la fila seleccionada en el DataGridView
        private void dgvPacientes_SelectionChanged(object sender, EventArgs e)
        {
            // Verificamos que haya una fila seleccionada
            if (dgvPacientes.CurrentRow != null)
            {
                // Cargamos los datos del paciente seleccionado en los controles del formulario
                txtNombre.Text = dgvPacientes.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvPacientes.CurrentRow.Cells["Apellido"].Value.ToString();
                txtEdad.Text = dgvPacientes.CurrentRow.Cells["Edad"].Value.ToString();
            }
        }

        private void btnVerIngresos_Click(object sender, EventArgs e)
        {
            // Validamos que haya un paciente seleccionado
            if (dgvPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente primero.");
            }
            else
            {
                // Obtenemos el ID del paciente seleccionado
                int idSeleccionado = (int)dgvPacientes.CurrentRow.Cells["Id"].Value;
                frmIngresos formIngresos = new frmIngresos(idSeleccionado);
                formIngresos.ShowDialog();
                RefrescarGrid();
            }
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
