using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AG.Data.Model
{
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        [MaxLength(50)]
        public string Key { get; set; }

        [MaxLength(1000)]
        public string Value { get; set; }
    }
}
