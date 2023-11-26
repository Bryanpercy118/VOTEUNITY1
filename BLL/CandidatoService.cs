using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CandidatoService
    {
        private readonly CandidatoRepository candidatoRepository;

        public CandidatoService(string filePath)
        {
            this.candidatoRepository = new CandidatoRepository(filePath);
        }

        // Lógica de negocio para agregar un nuevo candidato
        public void AgregarCandidato(Candidato candidato)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            candidatoRepository.AgregarCandidato(candidato);
        }

        // Lógica de negocio para obtener todos los candidatos
        public IEnumerable<Candidato> ObtenerTodosLosCandidatos()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return candidatoRepository.ObtenerTodosLosCandidatos();
        }

        // Lógica de negocio para obtener un candidato por su Id
        public Candidato ObtenerCandidatoPorId(int candidatoId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return candidatoRepository.ObtenerCandidatoPorId(candidatoId);
        }

        // Lógica de negocio para actualizar información de un candidato
        public void ActualizarCandidato(Candidato candidato)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            candidatoRepository.ActualizarCandidato(candidato);
        }

        // Lógica de negocio para eliminar un candidato por su Id
        public void EliminarCandidato(int candidatoId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            candidatoRepository.EliminarCandidato(candidatoId);
        }
    }
}
