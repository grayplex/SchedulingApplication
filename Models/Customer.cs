using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingApplication.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        [Column("customerId")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(45)]
        [Column("customerName")]
        public string CustomerName { get; set; }

        [Required]
        [Column("addressId")]
        public int AddressId { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        // Navigation Properties
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
