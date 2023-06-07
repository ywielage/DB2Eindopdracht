using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class SubtitleLanguageContent
    {
        [Key]
        public int LanguageContentId { get; set; }
        public int LanguageId { get; set; } 
        public int ContentId { get; set; }
    }
}
