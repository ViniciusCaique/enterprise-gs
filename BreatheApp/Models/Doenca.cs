using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreatheApp.Models
{
    public class Doenca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoencaId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(280)]
        public string Descricao { get; set; }
        public string Recomendacoes { get; set; }
        public virtual ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}