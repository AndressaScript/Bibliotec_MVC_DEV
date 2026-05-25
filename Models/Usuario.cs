
using System.ComponentModel.DataAnnotations;

namespace Bibliotec_MVC_DEV.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)] //limitando quant de caracteres
        public string Matricula { get; set; } = null!; // null! está deixando claro que ele irá ser preenchido em algum momento diferente de string?

        public bool Ativo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Senha { get; set; } = null!;

        [Required]
        [StringLength(11)]
        public string NumCel { get; set; } = null!;

        public bool TipoBib { get; set; } // 0 ou false = aluno, 1 ou true = bibliotecaria

        public ICollection <Reserva> Reservas { get; set; } = new List<Reserva>(); //Icollection = array

    }
}