using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
using Microsoft.AspNetCore.Mvc;


namespace Bibliotec_MVC_DEV.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        public async Task<IActionResult> Index()
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");
            int.TryParse(HttpContext.Session.GetString("UsuarioId"), out int usuarioId);
            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True"))
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Admin = adminSessao == "True" || adminSessao == "true";

            //criou a variavel para receber os dados vindo do banco
            IEnumerable<Reserva> reservas;

            if (ViewBag.Admin) //aqui sem comparação porque estamos comparando com true
            {
                reservas = await _reservaService.BuscarReservasAsync();
            }
            else
            { //nesse caso se for aluno listará apenas as reservas do aluno.
                reservas = await _reservaService.BuscarReservasPorUsuarioAsync(usuarioId);
            }

            return View(reservas);
        }
    }
}