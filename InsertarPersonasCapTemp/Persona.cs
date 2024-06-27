using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPersonasCapTemp
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public int IdPersonaTipo { get; set; }
        public int IdPrograma { get; set; }
        public int IdProgramaCapitulo { get; set; }
        public int IdProgramaTemporada { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreAbreviado { get; set; }
        public int Orden { get; set; }
    }
}
