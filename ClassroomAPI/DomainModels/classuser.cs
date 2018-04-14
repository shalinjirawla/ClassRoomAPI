using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomAPI.DomainModels
{
    [Table("Classuser")]
    public class Classuser
    {
        public Classuser()
        {
            this.IsActive = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("ClassID")]
        public Guid ClassID{ get; set; }
        public ClassRoom ClassRoom { get; set; }
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
