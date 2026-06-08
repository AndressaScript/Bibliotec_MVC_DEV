using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;

namespace Bibliotec_MVC_DEV.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task<IEnumerable<Reserva>> BuscarReservasAsync()
        {
            return await _reservaRepository.BuscarReservasComDetalhes();
        }

        public async Task<IEnumerable<Reserva>> BuscarReservasPorUsuarioAsync(int alunoId)
        {
           return await _reservaRepository.BuscarReservaPorUsuarioId(alunoId);
        }
    }
}