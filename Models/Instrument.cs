using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inchiriere_Instrumente.Models
{
    public class Instrument
    {
        public int ID { get; set; }

        [Display(Name = "Instrument Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$",
            ErrorMessage = "Numele trebuie sa inceapa cu majuscula"),
            Required, StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? OwnerID { get; set; }
        public Owner? Owner { get; set; } //navigation property

        public ICollection<InstrumentCategory>? InstrumentCategories { get; set; }
    }
}
