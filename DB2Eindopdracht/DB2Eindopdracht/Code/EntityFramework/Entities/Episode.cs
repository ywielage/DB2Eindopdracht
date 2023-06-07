using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.Entities
{
    public class Episode
    {
        [Key]
        public int episodeId { get; set; }
        public int seasonId { get; set; }
        public int contentId { get; set; }
        public string title { get; set; }
        public int episodeNumber { get; set; }
        public int creditStartTime  { get; set; }
    }
}
