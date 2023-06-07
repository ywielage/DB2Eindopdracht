using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class SubtitleLanguage
    {
        [Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
