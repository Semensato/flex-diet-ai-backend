using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Models
{
    [Table("UsersHealth")]
    public class UserHealth
    {
        [Key]
        public int UsersHealthId { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }

        // User FK.
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
