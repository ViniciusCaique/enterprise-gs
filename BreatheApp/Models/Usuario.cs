using System.ComponentModel.DataAnnotations;

namespace BreatheApp.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(280)]
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
