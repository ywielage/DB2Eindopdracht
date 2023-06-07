using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Preference
    {
        [Key]
        public int ProfileId { get; set; }
        public int KijkwijzerId { get; set; }
    }
}
