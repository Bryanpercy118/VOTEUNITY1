using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EleccionService
    {

        private readonly EleccionRepository eleccionRepository;

        public EleccionService(string filePath)
        {
            this.eleccionRepository = new EleccionRepository(filePath);
        }

        // Lógica de negocio para agregar una nueva elección
        public void AgregarEleccion(Eleccion eleccion)
        {
            if (eleccion != null)
                // Puedes agregar lógica adicional aquí si es necesario
                eleccionRepository.AgregarEleccion(eleccion);
        }

        // Lógica de negocio para obtener todas las elecciones
        public IEnumerable<Eleccion> ObtenerTodasLasElecciones()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return eleccionRepository.ObtenerTodasLasElecciones();
        }

        // Lógica de negocio para obtener una elección por su Id
        public Eleccion ObtenerEleccionPorId(int eleccionId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return eleccionRepository.ObtenerEleccionPorId(eleccionId);
        }

        // Lógica de negocio para actualizar información de una elección
        public void ActualizarEleccion(Eleccion eleccion)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            eleccionRepository.ActualizarEleccion(eleccion);
        }

        // Lógica de negocio para eliminar una elección por su Id
        public void EliminarEleccion(int eleccionId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            eleccionRepository.EliminarEleccion(eleccionId);

        }
    }
}
