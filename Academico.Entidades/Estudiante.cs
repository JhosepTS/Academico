using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        public String num_doc { get; set; }
        public String nombres { get; set; }
        public String email { get; set; }
        public bool Estado { get; set; }

    }
}
