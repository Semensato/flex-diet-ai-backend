using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Models
{
    [Table("UsersDiets")]
    public class UserDiet
    {
        [Key]
        public int UserDietId { get; set; }
        public string Name { get; set; } = null!;
        public string Goal { get; set; } = null!;
        public DateTime InitialDate { get; set; }
        public DateTime FinishDate { get; set; }

        // User FK.
        public Guid UserId { get; set; }
        public User User { get; set; }

        // DietMenu FK.
        public ICollection<DietMenu> DietMenu { get; set; }
    }
}
