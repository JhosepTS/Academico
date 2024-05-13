using Academico.Datos;
using Academico.Entidades;
using Academico.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Negocio
{
    public class DocenteNegocio : IDocenteRepositorio
    {
        AcademicoContextoBD db = new AcademicoContextoBD();

        public void Actualizar(Docente docente)
        {
            db.Entry(docente).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Agregar(Docente docente)
        {
            db.Docente.Add(docente);
            db.SaveChanges();
        }

        public Docente Buscar(int Id)
        {
            var busqueda = db.Docente.Find(Id);
            return busqueda;
        }

        public List<Docente> ListarDocentes()
        {
            var query = from x in db.Docente
                        orderby x.Id
                        select x;
            return query.ToList();
            //return db.Estudiante.ToList();
        }

        public List<Docente> ListarDocentesXNombre(string Nombre)
        {
            var query = from x in db.Docente
                        orderby x.Nombre.Contains(Nombre)
                        select x;
            return query.ToList();
            //return db.Estudiante.ToList();
        }
    }
}
