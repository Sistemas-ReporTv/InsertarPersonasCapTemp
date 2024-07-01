using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPersonasCapTemp
{
    public class InfoMail
    {
        public InfoMail(string nombreProceso, int personasProcesadas, DateTime fechaInicio, DateTime fechaFinalizacion, TimeSpan duracion)
        {
            NombreProceso = nombreProceso;
            PersonasProcesadas = personasProcesadas;
            FechaInicio = fechaInicio;
            FechaFinalizacion = fechaFinalizacion;
            Duracion = duracion;
        }

        public string NombreProceso { get; set; }
        public int PersonasProcesadas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public TimeSpan Duracion { get; set; }
    }
}
