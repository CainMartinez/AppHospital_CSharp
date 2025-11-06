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
    // Formulario para gestionar los ingresos hospitalarios de un paciente
    public partial class frmIngresos : Form
    {
        // Variable que guarda el paciente del cual vamos a ver y modificar sus ingresos
        private Paciente pacienteSeleccionado;

        // Constructor vacío necesario para que funcione el diseñador de Visual Studio
        public frmIngresos()
        {
            InitializeComponent();
        }

        // Constructor que recibe un paciente como parámetro
        // El ": this()" llama primero al constructor vacío para inicializar el formulario
        public frmIngresos(Paciente paciente) : this()          
        {
            // Guardamos el paciente que nos pasaron
            pacienteSeleccionado = paciente;
        }

        // Evento que se ejecuta cuando el formulario se carga por primera vez
        private void frmIngresos_Load(object sender, EventArgs e)
        {
            // Cargamos los ingresos del paciente en el DataGridView
            RefrescarGridIngresos();
        }

        // Método que actualiza el DataGridView con los ingresos del paciente
        private void RefrescarGridIngresos()
        {
            // Primero limpiamos el DataSource para que se actualice correctamente
            dgvIngresos.DataSource = null;

            // Si hay un paciente seleccionado, mostramos sus ingresos
            if (pacienteSeleccionado != null)
            {
                dgvIngresos.DataSource = pacienteSeleccionado.Ingresos;
            }
        }

        // Evento del botón "Agregar Ingreso"
        private void btnAgregarIngreso_Click(object sender, EventArgs e)
        {
            // Validamos que haya un paciente seleccionado
            if (pacienteSeleccionado == null)
            {
                MessageBox.Show("No hay un paciente seleccionado.");
            }
            // Validamos que el campo motivo no esté vacío
            else if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("El motivo es obligatorio.");
            }
            // Validamos que el campo especialidad no esté vacío
            else if (string.IsNullOrEmpty(txtEspecialidad.Text))
            {
                MessageBox.Show("La especialidad es obligatoria.");
            }
            // Validamos que el campo habitación no esté vacío
            else if (string.IsNullOrEmpty(txtHabitacion.Text))
            {
                MessageBox.Show("La habitación es obligatoria.");
            }
            // Si todas las validaciones pasaron, creamos el nuevo ingreso
            else
            {
                // Creamos un nuevo objeto Ingreso
                Ingreso nuevoIngreso = new Ingreso();
                
                // Asignamos los valores de los controles del formulario al nuevo ingreso
                nuevoIngreso.FechaIngreso = dtpFechaIngreso.Value;
                nuevoIngreso.Motivo = txtMotivo.Text;
                nuevoIngreso.Especialidad = txtEspecialidad.Text;
                nuevoIngreso.Habitacion = txtHabitacion.Text;

                // Si el checkbox de "Dar Alta" está marcado, guardamos la fecha de alta
                if (chkDarAlta.Checked)
                {
                    nuevoIngreso.FechaAlta = dtpFechaAlta.Value;
                }
                // Si no está marcado, la fecha de alta es null (el paciente sigue hospitalizado)
                else
                {
                    nuevoIngreso.FechaAlta = null;
                }

                // Agregamos el nuevo ingreso a la lista de ingresos del paciente
                pacienteSeleccionado.Ingresos.Add(nuevoIngreso);
                
                // Actualizamos el DataGridView para mostrar el nuevo ingreso
                RefrescarGridIngresos();

                // Limpiamos los campos del formulario para poder agregar otro ingreso
                txtMotivo.Clear();
                txtEspecialidad.Clear();
                txtHabitacion.Clear();
                chkDarAlta.Checked = false;

                // Mostramos mensaje de confirmación
                MessageBox.Show("Ingreso agregado correctamente.");
            }
        }

        // Evento del botón "Editar Ingreso"
        private void btnEditarIngreso_Click(object sender, EventArgs e)
        {
            // Validamos que haya una fila seleccionada en el DataGridView
            if (dgvIngresos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un ingreso para editar.");
            }
            // Validamos que el campo motivo no esté vacío
            else if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("El motivo es obligatorio.");
            }
            // Validamos que el campo especialidad no esté vacío
            else if (string.IsNullOrEmpty(txtEspecialidad.Text))
            {
                MessageBox.Show("La especialidad es obligatoria.");
            }
            // Validamos que el campo habitación no esté vacío
            else if (string.IsNullOrEmpty(txtHabitacion.Text))
            {
                MessageBox.Show("La habitación es obligatoria.");
            }
            // Si todas las validaciones pasaron, editamos el ingreso
            else
            {
                // Obtenemos el ingreso seleccionado en el DataGridView
                Ingreso ingresoSeleccionado = (Ingreso)dgvIngresos.CurrentRow.DataBoundItem;
                
                // Actualizamos los valores del ingreso con los valores de los controles
                ingresoSeleccionado.FechaIngreso = dtpFechaIngreso.Value;
                ingresoSeleccionado.Motivo = txtMotivo.Text;
                ingresoSeleccionado.Especialidad = txtEspecialidad.Text;
                ingresoSeleccionado.Habitacion = txtHabitacion.Text;

                // Si el checkbox de "Dar Alta" está marcado, actualizamos la fecha de alta
                if (chkDarAlta.Checked)
                {
                    ingresoSeleccionado.FechaAlta = dtpFechaAlta.Value;
                }
                // Si no está marcado, ponemos la fecha de alta en null
                else
                {
                    ingresoSeleccionado.FechaAlta = null;
                }

                // Actualizamos el DataGridView para mostrar los cambios
                RefrescarGridIngresos();
                
                // Mostramos mensaje de confirmación
                MessageBox.Show("Ingreso actualizado correctamente.");
            }
        }

        // Evento del botón "Eliminar Ingreso"
        private void btnEliminarIngreso_Click(object sender, EventArgs e)
        {
            // Validamos que haya una fila seleccionada en el DataGridView
            if (dgvIngresos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un ingreso para eliminar.");
            }
            else
            {
                // Obtenemos el ingreso seleccionado
                Ingreso ingresoSeleccionado = (Ingreso)dgvIngresos.CurrentRow.DataBoundItem;

                // Mostramos un cuadro de diálogo para confirmar la eliminación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de eliminar el ingreso por " + ingresoSeleccionado.Motivo + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo);

                // Si el usuario confirmó la eliminación
                if (resultado == DialogResult.Yes)
                {
                    // Eliminamos el ingreso de la lista del paciente
                    pacienteSeleccionado.Ingresos.Remove(ingresoSeleccionado);
                    
                    // Actualizamos el DataGridView
                    RefrescarGridIngresos();
                    
                    // Limpiamos los controles del formulario
                    LimpiarControles();
                
                    // Mostramos mensaje de confirmación
                    MessageBox.Show("Ingreso eliminado correctamente.");
                }
            }
        }

        // Evento que se ejecuta cuando cambia la fila seleccionada en el DataGridView
        private void dgvIngresos_SelectionChanged(object sender, EventArgs e)
        {
            // Obtenemos la lista de ingresos del DataSource
            var ingresos = dgvIngresos.DataSource as List<Ingreso>;

            // Verificamos que haya una fila seleccionada, que tenga datos y que la lista no esté vacía
            if (ingresos != null && ingresos.Count > 0 && dgvIngresos.CurrentRow != null && dgvIngresos.CurrentRow.DataBoundItem != null)
            {
                try
                {
                    // Obtenemos el ingreso de la fila seleccionada
                    Ingreso ingreso = (Ingreso)dgvIngresos.CurrentRow.DataBoundItem;
                    
                    // Cargamos los datos del ingreso en los controles del formulario
                    dtpFechaIngreso.Value = ingreso.FechaIngreso;
                    txtMotivo.Text = ingreso.Motivo;
                    txtEspecialidad.Text = ingreso.Especialidad;
                    txtHabitacion.Text = ingreso.Habitacion;

                    // Si el ingreso tiene fecha de alta (el paciente fue dado de alta)
                    if (ingreso.FechaAlta != null)
                    {
                        chkDarAlta.Checked = true;
                        dtpFechaAlta.Value = ingreso.FechaAlta.Value;
                    }
                    // Si no tiene fecha de alta (el paciente sigue hospitalizado)
                    else
                    {
                        chkDarAlta.Checked = false;
                        dtpFechaAlta.Value = DateTime.Now;
                    }
                }
                catch (Exception)
                {
                    // Si ocurre algún error (por ejemplo, índice fuera de rango), limpiamos los controles
                    LimpiarControles();
                }
            }
            else
            {
                // Si no hay ninguna fila seleccionada o la lista está vacía, limpiamos los controles
                LimpiarControles();
            }
        }

        // Método que limpia todos los controles del formulario y los pone en sus valores por defecto
        private void LimpiarControles()
        {
            dtpFechaIngreso.Value = DateTime.Now;
            txtMotivo.Clear();
            txtEspecialidad.Clear();
            txtHabitacion.Clear();
            chkDarAlta.Checked = false;
            dtpFechaAlta.Value = DateTime.Now;
        }

        // Evento que se ejecuta cuando cambia el estado del checkbox "Dar Alta"
        private void chkDarAlta_CheckedChanged(object sender, EventArgs e)
        {
            // Si el checkbox está marcado, habilitamos el DateTimePicker de fecha de alta
            // Si no está marcado, lo deshabilitamos
            dtpFechaAlta.Enabled = chkDarAlta.Checked;
        }

        private void Pacientes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
