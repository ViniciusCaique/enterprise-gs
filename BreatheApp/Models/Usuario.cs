using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(60)]
        public string Sobrenome { get; set; }
        [Required]
        [MaxLength(280)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        /*public Endereco Endereco { get; set; }*/
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; } 
    }
}
