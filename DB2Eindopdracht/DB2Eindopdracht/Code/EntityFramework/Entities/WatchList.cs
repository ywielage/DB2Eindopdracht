using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class WatchList
    {
        [Key]
        public int ProfileId { get; set; }
        public int ContentId { get; set; }
    }
}
