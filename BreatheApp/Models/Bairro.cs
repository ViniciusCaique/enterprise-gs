using System.ComponentModel.DataAnnotations;

namespace BreatheApp.Models
{
    public class Bairro
    {
        [Key]
        public int BairroId { get; set; }

        public string Nome { get; set; }
        public string Zona { get; set; }

        public virtual ICollection<Logradouro> Logradouros { get; set; }
    }
}
