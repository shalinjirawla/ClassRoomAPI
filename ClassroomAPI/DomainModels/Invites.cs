using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomAPI.DomainModels
{
    [Table("Invite")]
    public class Invite
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime InviteDate { get; set; }
        public DateTime AcceptedDate { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("InvitedBy")]
        public virtual User Invited { get; set; }
    }
}
