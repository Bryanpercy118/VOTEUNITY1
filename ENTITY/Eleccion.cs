using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Eleccion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<Opcion> Opciones { get; set; } = new List<Opcion>();

    }
    public class Opcion
    {
        // Propiedades de la entidad Opcion
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Puedes agregar otras propiedades según los requisitos de tu aplicación
    }

}
