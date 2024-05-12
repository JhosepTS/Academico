using Academico.Datos;
using Academico.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Negocio
{
    public class EstudianteNegocio : IEstudianteRepositorio
    {
        AcademicoContextoBD db = new AcademicoContextoBD();
        public void Actualizar(Estudiante estudiante)
        {
            db.Entry(estudiante).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Agregar(Estudiante estudiante)
        {
            db.Estudiante.Add(estudiante);
            db.SaveChanges();
        }

        public Estudiante Buscar(int Id)
        {
            var busqueda = db.Estudiante.Find(Id);
            return busqueda;
        }

        public List<Estudiante> ListarEstudiante()
        {
            var query = from x in db.Estudiante
                        orderby x.Id
                        select x;
            return query.ToList();
            //return db.Estudiante.ToList();
        }

        public List<Estudiante> ListarEstudianteXNombre(string Nombre)
        {
            var query = from x in db.Estudiante
                        orderby x.nombres.Contains(Nombre)
                        select x;
            return query.ToList();
            //return db.Estudiante.ToList(); 
        }
    }
}
