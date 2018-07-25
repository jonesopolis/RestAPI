using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AG.Data.Model
{
    public class Hole : KeyedEntity
    {
        public long CourseId { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
        [MaxLength(50)]
        public string WistiaKey { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
