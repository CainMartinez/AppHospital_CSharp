using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppDataGridView
{
    // En esta service declaramos todos los métodos para interactuar con la base de datos
    public class DataTableHospital
    {
        // Creamos la variable que almacena la cadena de conexión
        private readonly string connectionString;

        public DataTableHospital()
        {
            // Obtenemos la cadena de conexión desde el archivo App.config (No publicado en github)
            connectionString = ConfigurationManager.ConnectionStrings["cadenaConn"].ConnectionString;
        }

        // Método para obtener todos los pacientes
        public DataTable ObtenerPacientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT id, nombre, apellido, edad FROM Pacientes ORDER BY id";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Método para obtener los ingresos de un paciente
        public DataTable ObtenerIngresosPorPaciente(int idPaciente)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT id, fecha_ingreso, fecha_alta, motivo, especialidad, habitacion, id_paciente 
                               FROM Ingresos 
                               WHERE id_paciente = @idPaciente 
                               ORDER BY fecha_ingreso DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Método para obtener todos los ingresos
        public DataTable ObtenerTodosLosIngresos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT id, fecha_ingreso, fecha_alta, motivo, especialidad, habitacion, id_paciente FROM Ingresos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Método para agregar un paciente
        public void AgregarPaciente(string nombre, string apellido, int edad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Pacientes (nombre, apellido, edad) VALUES (@nombre, @apellido, @edad)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@edad", edad);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para editar un paciente
        public void EditarPaciente(int id, string nombre, string apellido, int edad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Pacientes SET nombre = @nombre, apellido = @apellido, edad = @edad WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@edad", edad);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para eliminar un paciente
        public void EliminarPaciente(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Probamos las transacciones en el delete, ya que si borro un paciente sus ingresos deben quitarse también
                SqlTransaction transaction = conn.BeginTransaction();
                
                try
                {
                    // Primero eliminamos los ingresos del paciente
                    string queryIngresos = "DELETE FROM Ingresos WHERE id_paciente = @id";
                    SqlCommand cmdIngresos = new SqlCommand(queryIngresos, conn, transaction);
                    cmdIngresos.Parameters.AddWithValue("@id", id);
                    cmdIngresos.ExecuteNonQuery();

                    // Luego eliminamos el paciente
                    string queryPaciente = "DELETE FROM Pacientes WHERE id = @id";
                    SqlCommand cmdPaciente = new SqlCommand(queryPaciente, conn, transaction);
                    cmdPaciente.Parameters.AddWithValue("@id", id);
                    cmdPaciente.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    MessageBox.Show("Eliminación fallida. Cambios revertidos.");
                    throw;
                }
            }
        }

        // Método para agregar un ingreso
        public void AgregarIngreso(DateTime fechaIngreso, DateTime? fechaAlta, string motivo, string especialidad, string habitacion, int idPaciente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Ingresos (fecha_ingreso, fecha_alta, motivo, especialidad, habitacion, id_paciente) 
                               VALUES (@fechaIngreso, @fechaAlta, @motivo, @especialidad, @habitacion, @idPaciente)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fechaIngreso", fechaIngreso);
                cmd.Parameters.AddWithValue("@fechaAlta", (object)fechaAlta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@motivo", motivo);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                cmd.Parameters.AddWithValue("@habitacion", habitacion);
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para editar un ingreso
        public void EditarIngreso(int id, DateTime fechaIngreso, DateTime? fechaAlta, string motivo, string especialidad, string habitacion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Ingresos 
                               SET fecha_ingreso = @fechaIngreso, fecha_alta = @fechaAlta, motivo = @motivo, 
                                   especialidad = @especialidad, habitacion = @habitacion 
                               WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fechaIngreso", fechaIngreso);
                cmd.Parameters.AddWithValue("@fechaAlta", (object)fechaAlta ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@motivo", motivo);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                cmd.Parameters.AddWithValue("@habitacion", habitacion);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para eliminar un ingreso
        public void EliminarIngreso(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Ingresos WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
