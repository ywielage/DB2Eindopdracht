using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Quality
    {
        [Key]
        public int QualityId { get; set; }
        public string Name { get; set; }
    }
}
