using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EleccionRepository
    {
        private readonly string filePath;

        public EleccionRepository(string filePath)
        {
            this.filePath = filePath;

            // Verificar si el archivo existe, si no, crearlo
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Create: Agregar una nueva elección al archivo
        public void AgregarEleccion(Eleccion eleccion)
        {
            List<Eleccion> elecciones = ObtenerTodasLasElecciones().ToList();
            elecciones.Add(eleccion);
            GuardarEleccionesEnArchivo(elecciones);
        }

        // Read: Obtener todas las elecciones del archivo
        public IEnumerable<Eleccion> ObtenerTodasLasElecciones()
        {
            List<Eleccion> elecciones = new List<Eleccion>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 4)
                    {
                        Eleccion eleccion = new Eleccion
                        {
                            Id = int.Parse(parts[0]),
                            Titulo = parts[1],
                            FechaInicio = DateTime.Parse(parts[2]),
                            FechaFin = DateTime.Parse(parts[3])
                        };

                        // Puedes agregar lógica adicional para cargar opciones u otros detalles según tus necesidades
                        elecciones.Add(eleccion);
                    }
                }
            }

            return elecciones;
        }

        // Read: Obtener una elección por su Id
        public Eleccion ObtenerEleccionPorId(int eleccionId)
        {
            return ObtenerTodasLasElecciones().FirstOrDefault(e => e.Id == eleccionId);
        }


        // Update: Actualizar información de una elección en el archivo
        public void ActualizarEleccion(Eleccion eleccion)
        {
            List<Eleccion> elecciones = ObtenerTodasLasElecciones().ToList();
            Eleccion eleccionExistente = elecciones.FirstOrDefault(e => e.Id == eleccion.Id);

            if (eleccionExistente != null)
            {
                elecciones.Remove(eleccionExistente);
                elecciones.Add(eleccion);
                GuardarEleccionesEnArchivo(elecciones);
            }
        }

        // Delete: Eliminar una elección por su Id
        public void EliminarEleccion(int eleccionId)
        {
            List<Eleccion> elecciones = ObtenerTodasLasElecciones().ToList();
            Eleccion eleccionExistente = elecciones.FirstOrDefault(e => e.Id == eleccionId);

            if (eleccionExistente != null)
            {
                elecciones.Remove(eleccionExistente);
                GuardarEleccionesEnArchivo(elecciones);
            }
        }

        // Método auxiliar para guardar elecciones en el archivo
        private void GuardarEleccionesEnArchivo(IEnumerable<Eleccion> elecciones)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var eleccion in elecciones)
                {
                    writer.WriteLine($"{eleccion.Id},{eleccion.Titulo},{eleccion.FechaInicio},{eleccion.FechaFin}");
                    // Puedes agregar lógica adicional para escribir opciones u otros detalles según tus necesidades
                }
            }
        }
    }
}
