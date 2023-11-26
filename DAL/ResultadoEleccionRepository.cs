using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ResultadoEleccionRepository
    {
        private readonly string filePath;

        public ResultadoEleccionRepository(string filePath)
        {
            this.filePath = filePath;

            // Verificar si el archivo existe, si no, crearlo
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Create: Agregar un nuevo resultado de elección al archivo
        public void AgregarResultadoEleccion(ResultadoEleccion resultado)
        {
            List<ResultadoEleccion> resultados = ObtenerTodosLosResultados().ToList();
            resultados.Add(resultado);
            GuardarResultadosEnArchivo(resultados);
        }

        // Read: Obtener todos los resultados de elección del archivo
        public IEnumerable<ResultadoEleccion> ObtenerTodosLosResultados()
        {
            List<ResultadoEleccion> resultados = new List<ResultadoEleccion>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        ResultadoEleccion resultado = new ResultadoEleccion
                        {
                            IdOpcion = int.Parse(parts[0]),
                            NombreOpcion = parts[1],
                            CantidadVotos = int.Parse(parts[2])
                        };
                        resultados.Add(resultado);
                    }
                }
            }

            return resultados;
        }

        // Read: Obtener un resultado de elección por su IdOpcion
        public ResultadoEleccion ObtenerResultadoPorIdOpcion(int idOpcion)
        {
            return ObtenerTodosLosResultados().FirstOrDefault(r => r.IdOpcion == idOpcion);
        }

        // Update: Actualizar información de un resultado de elección en el archivo
        public void ActualizarResultadoEleccion(ResultadoEleccion resultado)
        {
            List<ResultadoEleccion> resultados = ObtenerTodosLosResultados().ToList();
            ResultadoEleccion resultadoExistente = resultados.FirstOrDefault(r => r.IdOpcion == resultado.IdOpcion);

            if (resultadoExistente != null)
            {
                resultados.Remove(resultadoExistente);
                resultados.Add(resultado);
                GuardarResultadosEnArchivo(resultados);
            }
        }

        // Método auxiliar para guardar resultados de elección en el archivo
        private void GuardarResultadosEnArchivo(IEnumerable<ResultadoEleccion> resultados)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var resultado in resultados)
                {
                    writer.WriteLine($"{resultado.IdOpcion},{resultado.NombreOpcion},{resultado.CantidadVotos}");
                }
            }
        }

        public void EliminarResultadoEleccion(int idOpcion)
        {
            throw new NotImplementedException();
        }
    }
}
