using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomAPI.DomainModels
{
    [Table("UserRole")]
    public class UserRole
    {
        public UserRole()
        {
            this.IsActive = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
