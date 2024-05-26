using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Entidades
{
    public class Asistencia
    {
        public string NumDocumento { get; set; }
        public string Nombres { get; set; }
        public string Fecha { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
    }
}
