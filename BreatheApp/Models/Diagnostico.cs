using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreatheApp.Models
{
    public class Diagnostico
    {
        [Key]
        public int DiagnosticoId { get; set; }
        public string Descricao { get; set; }

        [ForeignKey(name: "Usuario")]
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set;}

        [ForeignKey(name: "Doenca")]
        [Display(Name = "Doença")]
        public int DoencaId { get; set; }
        public virtual Doenca Doenca { get; set;}
    }
}