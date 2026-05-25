using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bibliotec_MVC_DEV.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataReserva { get; set; }

        public DateTime? DataEmprestimo { get; set; }

        public DateTime? DataPrevistaDevolucao { get; set; }

        public string? DanoLivro { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; } = null!;
        //opcoes: status = e (em espera), status = p (livro em posse do aluno), status = a (em atraso), status = f (finalizado, devolvido)

        public int AlunoId { get; set; }
        [ForeignKey("AlunoId")]

        public Usuario Aluno { get; set; } = null!;

        public int LivroId { get; set; }
        [ForeignKey("LivroId")]

        public Livro Livro { get; set; } = null!;
    }
}