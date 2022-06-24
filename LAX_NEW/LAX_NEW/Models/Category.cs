using System.ComponentModel.DataAnnotations;

namespace LAX_NEW.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Film_Titel { get; set; }
        public string Instruktør { get; set; }
        public int Årstal { get; set; }
        public string Detaljer { get; set; }
    }
}
