using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Voto
    {
        public int Id {  get; set; }
        public int IdUsuario { get; set; }
        public int IdOpcion { get; set; }
        public DateTime FechaVoto { get; set; }

        // Puedes agregar otras propiedades según los requisitos de tu aplicación

        // Constructor por defecto
        public Voto()
        {
            // Inicializar la fecha de voto con la fecha y hora actuales
            FechaVoto = DateTime.Now;
        }

    }
}
