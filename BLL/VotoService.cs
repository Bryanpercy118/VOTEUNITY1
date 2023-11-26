using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VotoService
    {
        private readonly VotoRepository votoRepository;

        public VotoService(string filePath)
        {
            this.votoRepository = new VotoRepository(filePath);
        }

        // Lógica de negocio para agregar un nuevo voto
        public void AgregarVoto(Voto voto)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            if (voto == null)
            {
                throw new ArgumentNullException(nameof(voto), "El objeto Voto no puede ser nulo.");
            }
            if (voto.IdUsuario<=0)
            {
                throw new ArgumentException("La identificación del usuario no es valida", nameof(voto.IdUsuario));
            }
            try
            {
                votoRepository.AgregarVoto(voto);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Error al agregar el voto.", ex);
            }
        }

        // Lógica de negocio para obtener todos los votos
        public IEnumerable<Voto> ObtenerTodosLosVotos()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            try
            {
                var todosLosVotos = votoRepository.ObtenerTodosLosVotos();
                return todosLosVotos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener todos los votos de la elección", ex);
            }
            //return votoRepository.ObtenerTodosLosVotos();
        }

        // Lógica de negocio para obtener un voto por su Id
        public Voto ObtenerVotoPorId(int votoId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            try
            {
                Voto voto = votoRepository.ObtenerVotoPorId(votoId);
                return voto;
            }

            catch(Exception ex) 
            {
                throw new ApplicationException($"Error al intentar obtener el voto con la identificación del usuario", ex);
            }
            //return votoRepository.ObtenerVotoPorId(votoId);
        }

        // Lógica de negocio para actualizar información de un voto
        public void ActualizarVoto(Voto voto)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            if (voto == null) 
            {
                throw new ArgumentNullException(nameof(voto), "El voto no puede ser nulo");
            }
            if (voto.Id <= 0)
            {
                throw new ArgumentException("El id del usuario no es válida", nameof (voto.Id));
            }
            if (voto.IdUsuario <= 0)
            {
                throw new ArgumentException("La identificación del usuario no es válida", nameof(voto.IdUsuario));
            }

            try
            {
                Voto votoActual = votoRepository.ObtenerVotoPorId(voto.Id);

                if (votoActual == null)
                {
                    throw new InvalidOperationException($"No se encontró un voto con ese Id {voto.Id}");

                }
               votoRepository.ActualizarVoto(voto);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException($"Error al querer actualizar el voto con Id {voto.Id}", ex);
            }
            
        }

        // Lógica de negocio para eliminar un voto por su Id
        public void EliminarVoto(int votoId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            List<Voto> votos = (List<Voto>)ObtenerTodosLosVotos();
            Voto votoParaEliminar = votos.FirstOrDefault(v=>v.Id == votoId);
            if (votoParaEliminar != null)
            {
                votos.Remove(votoParaEliminar);
                GuardarVotosEnArchivo(votos);
                
            }
            else
            {
                throw new InvalidOperationException($"No se encontró un voto con Id {votoId}.");
            }
            votoRepository.EliminarVoto(votoId);
        }
        private void GuardarVotosEnArchivo(List<Voto> votos)
        {
            // Implementa la lógica para convertir la lista de votos a un formato de texto y escribirlo en el archivo
            // ...
        }
    }
}
