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
        // Propiedad pública que recibe la lista de pacientes desde el formulario principal
        // Esta lista se comparte entre formularios
        public List<Paciente> Pacientes { get; set; }

        public frmPaciente()
        {
            InitializeComponent();
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

            // Creamos una lista de objetos anónimos para mostrar en el grid
            // No mostramos el objeto Paciente directamente para tener control sobre qué columnas mostrar
            List<object> datosPacientes = new List<object>();

            // Recorremos todos los pacientes
            foreach (Paciente p in Pacientes)
            {
                // Contamos cuántos ingresos tiene cada paciente
                int numeroIngresos = p.Ingresos.Count;

                // Creamos un objeto anónimo con los datos que queremos mostrar
                datosPacientes.Add(new
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Edad = p.Edad,
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
                        // Creamos un nuevo paciente
                        Paciente nuevoPaciente = new Paciente();
                        nuevoPaciente.Nombre = txtNombre.Text;
                        nuevoPaciente.Apellido = txtApellido.Text;
                        nuevoPaciente.Edad = edad;

                        // Agregamos el paciente a la lista
                        Pacientes.Add(nuevoPaciente);

                        // Actualizamos el DataGridView
                        RefrescarGrid();

                        // Limpiamos los campos para poder agregar otro paciente
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

                        // Buscamos el paciente en la lista por su ID
                        foreach (Paciente p in Pacientes)
                        {
                            if (p.Id == idSeleccionado)
                            {
                                // Actualizamos los datos del paciente
                                p.Nombre = txtNombre.Text;
                                p.Apellido = txtApellido.Text;
                                p.Edad = edad;
                                break; 
                                // Salimos del bucle
                            }
                        }

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
                Paciente pacienteAEliminar = null;

                // Buscamos el paciente en la lista por su ID
                foreach (Paciente p in Pacientes)
                {
                    if (p.Id == idSeleccionado)
                    {
                        pacienteAEliminar = p;
                        break;
                    }
                }

                // Si encontramos el paciente
                if (pacienteAEliminar != null)
                {
                    // Pedimos confirmación al usuario
                    DialogResult resultado = MessageBox.Show(
                        "¿Está seguro de eliminar al paciente " + pacienteAEliminar.Nombre + " " + pacienteAEliminar.Apellido + "?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo);

                    // Si el usuario confirmó la eliminación
                    if (resultado == DialogResult.Yes)
                    {
                        // Eliminamos el paciente de la lista
                        Pacientes.Remove(pacienteAEliminar);

                        // Actualizamos el DataGridView
                        RefrescarGrid();

                        // Mostramos mensaje de confirmación
                        MessageBox.Show("Paciente eliminado correctamente.");
                    }
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
                Paciente pacienteSeleccionado = null;

                // Buscamos el paciente en la lista por su ID
                foreach (Paciente p in Pacientes)
                {
                    if (p.Id == idSeleccionado)
                    {
                        pacienteSeleccionado = p;
                        break;
                    }
                }

                // Si encontramos el paciente
                if (pacienteSeleccionado != null)
                {
                    // Creamos el formulario de ingresos pasándole el paciente seleccionado
                    frmIngresos formIngresos = new frmIngresos(pacienteSeleccionado);

                    // Mostramos el formulario como diálogo modal
                    formIngresos.ShowDialog();

                    // Cuando se cierra el formulario de ingresos, actualizamos el grid
                    RefrescarGrid();
                }
            }
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
