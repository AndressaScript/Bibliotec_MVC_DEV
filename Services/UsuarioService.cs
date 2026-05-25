using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;

namespace Bibliotec_MVC_DEV.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        //ctor atalho construtor
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> AutenticarUsuario(string email, string senha)
        {
            return await _usuarioRepository.BuscarEmailSenha(email,senha);
        }
    }
}