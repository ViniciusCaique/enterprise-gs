using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreatheApp.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        public string Cep { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:-MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Ponto de Referência")]
        public string PontoDeReferencia { get; set; }

        public virtual ICollection<Usuario> Usuarios {  get; set; }
        /*public Logradouro Logradouro { get; set; }*/
    }
}
