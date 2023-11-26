using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ResultadoEleccionService
    {
        private readonly ResultadoEleccionRepository resultadoRepository;

        public ResultadoEleccionService(string filePath)
        {
            this.resultadoRepository = new ResultadoEleccionRepository(filePath);
        }

        // Lógica de negocio para agregar un nuevo resultado de elección
        public void AgregarResultadoEleccion(ResultadoEleccion resultado)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            resultadoRepository.AgregarResultadoEleccion(resultado);
        }

        // Lógica de negocio para obtener todos los resultados de elección
        public IEnumerable<ResultadoEleccion> ObtenerTodosLosResultados()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return resultadoRepository.ObtenerTodosLosResultados();
        }

        // Lógica de negocio para obtener un resultado de elección por su IdOpcion
        public ResultadoEleccion ObtenerResultadoPorIdOpcion(int idOpcion)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return resultadoRepository.ObtenerResultadoPorIdOpcion(idOpcion);
        }

        // Lógica de negocio para actualizar información de un resultado de elección
        public void ActualizarResultadoEleccion(ResultadoEleccion resultado)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            resultadoRepository.ActualizarResultadoEleccion(resultado);
        }

        // Lógica de negocio para eliminar un resultado de elección por su IdOpcion
        public void EliminarResultadoEleccion(int idOpcion)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            resultadoRepository.EliminarResultadoEleccion(idOpcion);
        }
    }
}
