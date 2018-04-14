using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomAPI.DomainModels
{
    [Table("ClassRoom")]
    public class ClassRoom
    {
        public ClassRoom()
        {
            this.IsActive = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string ClassCode { get; set; }
        public string Subject { get; set; }
        [ForeignKey("User")]
        public Guid CreatedBy{ get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
