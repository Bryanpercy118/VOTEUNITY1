using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService(string filePath)
        {
            this.usuarioRepository = new UsuarioRepository(filePath);
        }

        // Lógica de negocio para agregar un nuevo usuario
        public void AgregarUsuario(Usuario usuario)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            usuarioRepository.AgregarUsuario(usuario);
        }

        // Lógica de negocio para obtener todos los usuarios
        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return usuarioRepository.ObtenerTodosLosUsuarios();
        }

        // Lógica de negocio para obtener un usuario por su Id
        public Usuario ObtenerUsuarioPorId(int usuarioId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return usuarioRepository.ObtenerUsuarioPorId(usuarioId);
        }

        // Lógica de negocio para actualizar información de un usuario
        public void ActualizarUsuario(Usuario usuario)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            usuarioRepository.ActualizarUsuario(usuario);
        }

        // Lógica de negocio para eliminar un usuario por su Id
        public void EliminarUsuario(int usuarioId)
        {
            // Puedes agregar lógica adicional aquí si es necesario
            usuarioRepository.EliminarUsuario(usuarioId);
        }
    }
}
