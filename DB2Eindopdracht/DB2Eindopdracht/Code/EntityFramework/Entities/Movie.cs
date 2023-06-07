using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public int ContentId { get; set; }
        public string Title { get; set; }
        public int HighestQualityId { get; set; }
        public int CreditStartTime { get; set; }
    }
}
