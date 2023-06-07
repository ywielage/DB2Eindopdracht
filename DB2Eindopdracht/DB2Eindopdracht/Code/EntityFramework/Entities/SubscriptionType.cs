using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class SubscriptionType
    {
        [Key]
        public int SubscriptionTypeId { get; set; }
        public string Name  { get; set; }
        public double Price { get; set; }
    }
}
