using System.ComponentModel.DataAnnotations.Schema;

namespace AG.Data.Model
{
    public class CourseTextContent : KeyedEntity
    {
        public long CourseId { get; set; }

        public string About { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
