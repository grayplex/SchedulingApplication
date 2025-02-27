using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingApplication.Models
{
    public class Country : BaseEntity
    {
        [Key]
        [Column("countryId")]
        public int CountryId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("country")]
        public string CountryName { get; set; }

        // Navigation Properties
        public virtual ICollection<City> Cities { get; set; }
    }
}
