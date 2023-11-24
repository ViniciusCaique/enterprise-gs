using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreatheApp.Models
{
    public class Diagnostico
    {
        [Key]
        public int DiagnosticoId { get; set; }

        [ForeignKey(name: "Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set;}

        [ForeignKey(name: "Doenca")]
        public int DoencaId { get; set; }
        public virtual Doenca Doenca { get; set;}
    }
}