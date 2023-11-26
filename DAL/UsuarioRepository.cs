using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class UsuarioRepository
    {
        private readonly string filePath;

        public UsuarioRepository(string filePath)
        {
            this.filePath = filePath;
            // Verificar si el archivo existe, si no, crearlo
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Create: Agregar un nuevo usuario al archivo
        public void AgregarUsuario(Usuario usuario)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios().ToList();
            usuarios.Add(usuario);
            GuardarUsuariosEnArchivo(usuarios);
        }

        // Read: Obtener todos los usuarios del archivo
        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        Usuario usuario = new Usuario
                        {
                            Id = int.Parse(parts[0]),
                            Nombre = parts[1],
                            Apellidos = parts[2],
                            Contraseña = parts[3]
                        };
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }

        // Read: Obtener un usuario por su Id
        public Usuario ObtenerUsuarioPorId(int usuarioId)
        {
            return ObtenerTodosLosUsuarios().FirstOrDefault(u => u.Id == usuarioId);
        }

        // Update: Actualizar información de un usuario en el archivo
        public void ActualizarUsuario(Usuario usuario)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios().ToList();
            Usuario usuarioExistente = usuarios.FirstOrDefault(u => u.Id == usuario.Id);

            if (usuarioExistente != null)
            {
                usuarios.Remove(usuarioExistente);
                usuarios.Add(usuario);
                GuardarUsuariosEnArchivo(usuarios);
            }
        }

        // Delete: Eliminar un usuario por su Id
        public void EliminarUsuario(int usuarioId)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios().ToList();
            Usuario usuarioExistente = usuarios.FirstOrDefault(u => u.Id == usuarioId);

            if (usuarioExistente != null)
            {
                usuarios.Remove(usuarioExistente);
                GuardarUsuariosEnArchivo(usuarios);
            }
        }

        // Método auxiliar para guardar usuarios en el archivo
        private void GuardarUsuariosEnArchivo(IEnumerable<Usuario> usuarios)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var usuario in usuarios)
                {
                    writer.WriteLine($"{usuario.Id},{usuario.Nombre},{usuario.Apellidos},{usuario.Contraseña}");
                }
            }
        }
    }
}
