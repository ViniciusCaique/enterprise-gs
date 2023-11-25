using System.ComponentModel.DataAnnotations;

namespace BreatheApp.Models
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        public string DDD { get; set; }
        public string Nome { get; set; }
        public string CodigoIBGE { get; set; }

        public virtual ICollection<Bairro> Bairros { get; set; }
    }
}
