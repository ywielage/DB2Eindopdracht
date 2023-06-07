using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class KijkwijzerContent
    {
        [Key]
        public int KijkwijzerId { get; set; }
        public int ContenId { get; set; }
    }
}
