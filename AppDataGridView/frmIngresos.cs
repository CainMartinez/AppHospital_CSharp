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
        // Variable que guarda el id del paciente del cual vamos a ver y modificar sus ingresos
        private int idPacienteSeleccionado;
        private DataTableHospital dtHospital;

        // Constructor vacío necesario para que funcione el diseñador de Visual Studio
        public frmIngresos()
        {
            InitializeComponent();
            dtHospital = new DataTableHospital();
        }
        // Constructor que recibe un paciente como parámetro
        // El ": this()" llama primero al constructor vacío para inicializar el formulario
        public frmIngresos(int idPaciente) : this()          
        {
            idPacienteSeleccionado = idPaciente;
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
            DataTable dtIngresos = dtHospital.ObtenerIngresosPorPaciente(idPacienteSeleccionado);
            dgvIngresos.DataSource = dtIngresos;
        }

        // Evento del botón "Agregar Ingreso"
        private void btnAgregarIngreso_Click(object sender, EventArgs e)
        {
            // Validamos que el campo motivo no esté vacío
            if (string.IsNullOrEmpty(txtMotivo.Text))
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
                // Obtenemos los datos del nuevo ingreso desde los controles del formulario
                DateTime fechaIngreso = dtpFechaIngreso.Value;
                DateTime? fechaAlta = null;
                // Si el checkbox de "Dar Alta" está marcado, guardamos la fecha de alta sino sigue en null
                if (chkDarAlta.Checked)
                {
                    fechaAlta = dtpFechaAlta.Value;
                }
                // Agregamos el nuevo ingreso a la lista de ingresos del paciente
                dtHospital.AgregarIngreso(fechaIngreso, fechaAlta, txtMotivo.Text, txtEspecialidad.Text, txtHabitacion.Text, idPacienteSeleccionado);
                // Actualizamos el DataGridView para mostrar el nuevo ingreso
                RefrescarGridIngresos();
                // Limpiamos los campos del formulario para poder agregar otro ingreso
                LimpiarControles();
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
                // Obtenemos el ingreso seleccionado en el DataGridView y sus datos
                int idIngreso = (int)dgvIngresos.CurrentRow.Cells["id"].Value;
                DateTime fechaIngreso = dtpFechaIngreso.Value;
                DateTime? fechaAlta = null;

                // Si el checkbox de "Dar Alta" está marcado, actualizamos la fecha de alta
                if (chkDarAlta.Checked)
                {
                    fechaAlta = dtpFechaAlta.Value;
                }
                // Actualizamos el ingreso del paciente si todo es válido
                dtHospital.EditarIngreso(idIngreso, fechaIngreso, fechaAlta, txtMotivo.Text, txtEspecialidad.Text, txtHabitacion.Text);
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
                // Obtenemos el ingreso seleccionado y el motivo
                int idIngreso = (int)dgvIngresos.CurrentRow.Cells["id"].Value;
                string motivo = txtMotivo.Text;

                // Mostramos un cuadro de diálogo para confirmar la eliminación
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro de eliminar el ingreso por " + motivo + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo);

                // Si el usuario confirmó la eliminación
                if (resultado == DialogResult.Yes)
                {
                    // Eliminamos el ingreso del paciente
                    dtHospital.EliminarIngreso(idIngreso);

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

            // Guardamos el DataTable asociado al DataGridView
            DataTable dt = dgvIngresos.DataSource as DataTable;

            // Verificamos que el DataTable no sea nulo y tenga filas, y que haya una fila seleccionada
            if (dt != null && dt.Rows.Count > 0 && dgvIngresos.CurrentRow != null && dgvIngresos.CurrentRow.DataBoundItem != null)
            {
                try
                {
                    // Como no tenemos ya la clase ingreso, creamos un DataRowView para obtener los datos de la fila seleccionada
                    // Puede que en un futuro haga las clases para que hagan de modelo y sea más legible el código
                    DataRowView rowView = (DataRowView)dgvIngresos.CurrentRow.DataBoundItem;
                    
                    dtpFechaIngreso.Value = Convert.ToDateTime(rowView["fecha_ingreso"]);
                    txtMotivo.Text = rowView["motivo"].ToString();
                    txtEspecialidad.Text = rowView["especialidad"].ToString();
                    txtHabitacion.Text = rowView["habitacion"].ToString();

                    // Si el ingreso tiene fecha de alta (el paciente fue dado de alta)
                    if (rowView["fecha_alta"] != DBNull.Value)
                    {
                        chkDarAlta.Checked = true;
                        dtpFechaAlta.Value = Convert.ToDateTime(rowView["fecha_alta"]);
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
