using System.ComponentModel;

namespace ManterClasseAPI.Models
{
    public class ClasseObjeto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; } = true;
    }
}
