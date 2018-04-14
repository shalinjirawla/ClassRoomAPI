using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomAPI.DomainModels
{
    [Table("User")]
    public class User
    {
        public User(){
            this.IsActive = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("UserRoleID")]
        public Guid UserRoleID { get; set; }
        public UserRole UserRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
