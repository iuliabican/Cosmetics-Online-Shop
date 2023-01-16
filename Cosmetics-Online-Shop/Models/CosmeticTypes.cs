using System.ComponentModel.DataAnnotations;

namespace Cosmetics_Online_Shop.Models
{
    public class CosmeticTypes
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cosmetic Type")]
        public string CosmeticType { get; set; }
    }
}
