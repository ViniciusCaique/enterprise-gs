using System.ComponentModel.DataAnnotations;

namespace BreatheApp.Models
{
    public class Logradouro
    {
        [Key]
        public int LogradouroId { get; set; }
        public string Cep { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

    }
}