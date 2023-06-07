using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        public int ContentTypeId { get; set; }
    }
}
