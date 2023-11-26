using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{ 


    public class CandidatoRepository
    {
        private readonly string filePath;

        public CandidatoRepository(string filePath)
        {
            this.filePath = filePath;

            // Verificar si el archivo existe, si no, crearlo
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Create: Agregar un nuevo candidato al archivo
        public void AgregarCandidato(Candidato candidato)
        {
            List<Candidato> candidatos = ObtenerTodosLosCandidatos().ToList();
            candidatos.Add(candidato);
            GuardarCandidatosEnArchivo(candidatos);
        }

        // Read: Obtener todos los candidatos del archivo
        public IEnumerable<Candidato> ObtenerTodosLosCandidatos()
        {
            List<Candidato> candidatos = new List<Candidato>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 5)
                    {
                        Candidato candidato = new Candidato
                        {
                            Id = int.Parse(parts[0]),
                            Nombre = parts[1],
                            Apellidos = parts[2],
                            PartidoPolitico = parts[3],
                            Propuesta = parts[4]
                        };

                        candidatos.Add(candidato);
                    }
                }
            }

            return candidatos;
        }

        // Read: Obtener un candidato por su Id
        public Candidato ObtenerCandidatoPorId(int candidatoId)
        {
            return ObtenerTodosLosCandidatos().FirstOrDefault(c => c.Id == candidatoId);
        }

        // Update: Actualizar información de un candidato en el archivo
        public void ActualizarCandidato(Candidato candidato)
        {
            List<Candidato> candidatos = ObtenerTodosLosCandidatos().ToList();
            Candidato candidatoExistente = candidatos.FirstOrDefault(c => c.Id == candidato.Id);

            if (candidatoExistente != null)
            {
                candidatos.Remove(candidatoExistente);
                candidatos.Add(candidato);
                GuardarCandidatosEnArchivo(candidatos);
            }
        }

        // Delete: Eliminar un candidato por su Id
        public void EliminarCandidato(int candidatoId)
        {
            List<Candidato> candidatos = ObtenerTodosLosCandidatos().ToList();
            Candidato candidatoExistente = candidatos.FirstOrDefault(c => c.Id == candidatoId);

            if (candidatoExistente != null)
            {
                candidatos.Remove(candidatoExistente);
                GuardarCandidatosEnArchivo(candidatos);
            }
        }

        // Método auxiliar para guardar candidatos en el archivo
        private void GuardarCandidatosEnArchivo(IEnumerable<Candidato> candidatos)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var candidato in candidatos)
                {
                    writer.WriteLine($"{candidato.Id},{candidato.Nombre},{candidato.Apellidos},{candidato.PartidoPolitico},{candidato.Propuesta}");
                }
            }
        }
    }
}
