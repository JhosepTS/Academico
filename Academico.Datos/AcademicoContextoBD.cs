using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Academico.Entidades;
namespace Academico.Datos
    
{
    public class AcademicoContextoBD : DbContext
    {
        public AcademicoContextoBD() : base("CadenaConnexion1")
        { 
        }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
    }
}
