using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataGridView
{
    public class Paciente
    {
        private static int contadorId = 1; // contador global para todos los pacientes
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public List<Ingreso> Ingresos { get; set; } = new List<Ingreso>();

        // Id autoincremental
        public Paciente()
        {
            Id = contadorId++;
        }
    }

}
