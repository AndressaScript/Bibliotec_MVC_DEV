using Bibliotec_MVC_DEV.Contexts;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC_DEV.Repositories
{
    public class ReservaRepository : IReservaRepository
    {

        private readonly BbDbContext _context;

        public ReservaRepository(BbDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Reserva>> BuscarReservaPorUsuarioId(int usuarioId)
        {
            return await _context.Reserva
            .Include(r => r.Livro)
            .Include(r=> r.Aluno)
            .Where(r => r.AlunoId == usuarioId)
            .OrderBy(r => r.DataReserva)
            .ToListAsync();
        }

        public async Task<IEnumerable<Reserva>> BuscarReservasComDetalhes()
        {
            return await _context.Reserva
            .Include(r => r.Livro)
            .Include(r=> r.Aluno)
            .OrderBy(r => r.DataReserva)
            .ToListAsync();
        }
    }
}