using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class ContentWatched
    {
        [Key]
        public int ProfileId { get; set; }
        public int ContentId { get; set; }
        public int TimesWatched { get; set; }
    }
}
