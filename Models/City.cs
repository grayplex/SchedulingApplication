using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingApplication.Models
{
    public class City : BaseEntity
    {
        [Key]
        [Column("cityId")]
        public int CityId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("city")]
        public string CityName { get; set; }

        [Required]
        [Column("countryId")]
        public int CountryId { get; set; }

        // Navigation Properties
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
