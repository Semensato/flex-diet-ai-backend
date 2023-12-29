using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Models
{
    [Table("UsersData")]
    public class UserData
    {
        [Key]
        public int UserDataId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Dof { get; set; }
        public string Somatotype { get; set; } = null!;

        // User FK.
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
