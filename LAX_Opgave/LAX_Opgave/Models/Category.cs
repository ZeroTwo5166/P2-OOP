
using System.ComponentModel.DataAnnotations;

namespace LAX_Opgave.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Film_Titel { get; set; }
        public string Instruktør { get; set; }
        public int Årstal { get; set; }

    }
}
