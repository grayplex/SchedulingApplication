using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingApplication.Models
{
    public class Address : BaseEntity
    {
        [Key]
        [Column("addressId")]
        public int AddressId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("address")]
        public string AddressLine { get; set; }

        [StringLength(50)]
        [Column("address2")]
        public string AddressLine2 { get; set; }

        [Required]
        [Column("cityId")]
        public int CityId { get; set; }

        [StringLength(10)]
        [Column("postalCode")]
        public string PostalCode { get; set; }

        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        // Navigation Properties
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}