using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AG.Data.Model
{
    public class Course : KeyedEntity
    {
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string ImagePath { get; set; }
        
        public virtual List<Hole> Holes { get; set; }
        public virtual CourseAddress Address { get; set; }
        public virtual CourseContactInfo ContactInfo { get; set; }
        public virtual CourseTextContent TextContent { get; set; }
    }
}
