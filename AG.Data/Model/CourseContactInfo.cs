using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AG.Data.Model
{
    public class CourseContactInfo : KeyedEntity
    {
        public long CourseId { get; set; }

        [MaxLength(100)]
        public string Website { get; set; }
        [EmailAddress]
        [MaxLength(100)]
        public string ContactEmail { get; set; }
        [Phone]
        [MaxLength(25)]
        public string ContactPhone { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
