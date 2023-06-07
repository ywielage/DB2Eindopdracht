using System.ComponentModel.DataAnnotations;

namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public int Age { get; set; }
        public int LanguageId { get; set; }
    }
}
