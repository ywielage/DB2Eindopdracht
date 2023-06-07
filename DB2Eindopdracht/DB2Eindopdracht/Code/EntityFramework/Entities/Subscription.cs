using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
