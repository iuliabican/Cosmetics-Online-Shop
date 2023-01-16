using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Cosmetics_Online_Shop.Models
{
    public class Cosmetics
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Cosmetic Type")]
        [Required]
        public int CosmeticTypeId { get; set; }
        [ForeignKey("CosmeticTypeId")]
        public CosmeticTypes CosmeticTypes { get; set; }
        [Display(Name = "Specific Class")]
        [Required]
        public int SpecificClassId { get; set; }
        [ForeignKey("SpecificClassId")]
        public SpecificClass SpecificClass { get; set; }
    }
}
