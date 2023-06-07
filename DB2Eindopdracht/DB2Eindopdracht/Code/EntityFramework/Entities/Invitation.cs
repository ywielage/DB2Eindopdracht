using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Invitation
    {
        [Key]
        public int inviterId { get; set; }
        public int inviteeId { get; set; }
    }
}
