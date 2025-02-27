using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingApplication.Models
{
    public class User : BaseEntity
    {
        [Key]
        [Column("userId")]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("userName")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("password")]
        public string Password { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        // Navigation Properties
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
