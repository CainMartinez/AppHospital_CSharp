using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataGridView
{
    public class Ingreso
    {
        private static int contadorId = 1; // contador global para todos los ingresos

        public int Id { get; private set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Motivo { get; set; }
        public string Especialidad { get; set; }
        public string Habitacion { get; set; }

        // Id autoincremental
        public Ingreso()
        {
            Id = contadorId++;
        }
    }
}
