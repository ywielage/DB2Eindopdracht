using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Kijkwijzer
    {
        [Key]
        public int KijkwijzerId { get; set; }
        public string Name { get; set; }
    }
}
