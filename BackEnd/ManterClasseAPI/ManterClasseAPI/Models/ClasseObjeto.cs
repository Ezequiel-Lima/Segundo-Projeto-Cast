using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManterClasseAPI.Models
{
    public class ClasseObjeto
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; } = true;
    }
}
