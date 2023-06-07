using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.Entities
{
    public class Season
    {
        [Key]
        public int seasonId { get; set; }
        public string title { get; set; }
        /*[Maxlength]*/
        public int seasonNumber { get; set; }
    }
}
