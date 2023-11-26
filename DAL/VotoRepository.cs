using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VotoRepository
    {
        private readonly string filePath;

        public VotoRepository(string filePath)
        {
            this.filePath = filePath;

            // Verificar si el archivo existe, si no, crearlo
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Create: Agregar un nuevo voto al archivo
        public void AgregarVoto(Voto voto)
        {
            List<Voto> votos = ObtenerTodosLosVotos().ToList();
            votos.Add(voto);
            GuardarVotosEnArchivo(votos);
        }

        // Read: Obtener todos los votos del archivo
        public IEnumerable<Voto> ObtenerTodosLosVotos()
        {
            List<Voto> votos = new List<Voto>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Voto voto = new Voto
                        {
                            Id = int.Parse(parts[0]),
                            IdUsuario = int.Parse(parts[1]),
                            IdOpcion = int.Parse(parts[2]),
                            FechaVoto = DateTime.Parse(parts[3])
                        };
                        votos.Add(voto);
                    }
                }
            }

            return votos;
        }

        // Read: Obtener un voto por su Id
        public Voto ObtenerVotoPorId(int votoId)
        {
            return ObtenerTodosLosVotos().FirstOrDefault(v => v.Id == votoId);
        }

        // Update: Actualizar información de un voto en el archivo
        public void ActualizarVoto(Voto voto)
        {
            List<Voto> votos = ObtenerTodosLosVotos().ToList();
            Voto votoExistente = votos.FirstOrDefault(v => v.Id == voto.Id);

            if (votoExistente != null)
            {
                votos.Remove(votoExistente);
                votos.Add(voto);
                GuardarVotosEnArchivo(votos);
            }
        }

        // Delete: Eliminar un voto por su Id
        public void EliminarVoto(int votoId)
        {
            List<Voto> votos = ObtenerTodosLosVotos().ToList();
            Voto votoExistente = votos.FirstOrDefault(v => v.Id == votoId);

            if (votoExistente != null)
            {
                votos.Remove(votoExistente);
                GuardarVotosEnArchivo(votos);
            }
        }

        // Método auxiliar para guardar votos en el archivo
        private void GuardarVotosEnArchivo(IEnumerable<Voto> votos)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var voto in votos)
                {
                    writer.WriteLine($"{voto.Id},{voto.IdUsuario},{voto.IdOpcion},{voto.FechaVoto}");
                }
            }
        }
    }
}
