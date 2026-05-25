
using Bibliotec_MVC_DEV.Contexts;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC_DEV.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BbDbContext _context;

        public UsuarioRepository(BbDbContext context)
        {
            _context = context;
        }
        
        //procuando email e senha validos que estejam no banco de dados
        public async Task<Usuario?> BuscarEmailSenha(string email, string senha)
        {
            return await _context.Usuario.FirstOrDefaultAsync( u => u.Email == email && u.Senha == senha);
        }
    }
}