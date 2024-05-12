using Academico.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico.Negocio.Interfaces
{
    internal interface IDocenteRepositorio
    {
        void Agregar(Docente docente);
        void Actualizar(Docente docente);
        List<Docente> ListarDocentes();
        Docente Buscar(int Id);
        List<Docente> ListarDocentesXNombre(string Nombre);
    }
}
