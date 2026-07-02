using System.ComponentModel.DataAnnotations;

namespace Matapi.Models
{
    public class Mat
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Namnet får vara max 100 tecken.")]
        public string Namn { get; set; }

        [StringLength(500, ErrorMessage = "Beskrivningen får vara max 500 tecken.")]
        public string Beskrivning { get; set; }

        [Required(ErrorMessage = "Kategori är obligatoriskt.")]
        public string Kategori { get; set; }

        [Required(ErrorMessage = "Pris är obligatoriskt.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Priset måste vara större än 0.")]
        public decimal Pris { get; set; }
    }
}
