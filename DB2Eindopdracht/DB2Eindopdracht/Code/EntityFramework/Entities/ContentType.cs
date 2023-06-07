using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class ContentType
    {
        [Key]
        public int ContentTypeId { get; set; }
        public string Name { get; set; }
    }
}
