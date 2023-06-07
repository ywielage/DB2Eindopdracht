using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Serie
    {
        [Key]
        public int SeriesId { get; set; }
        public int ContentId { get; set; }
        public string Title { get; set; }
    }
}
