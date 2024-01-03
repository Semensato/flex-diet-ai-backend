using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Email { get; set; } = null!;
        public string BashPassword { get; set; } = null!;
        public DateTime CreationDate { get; set; }

        // UserData FK.
        public int UserDataId { get; set; }
        public UserData? UserData { get; set; }

        // UserHealth FK.
        public ICollection<UserHealth>? UserHealth { get; set; }

        // UserDiet FK.
        public ICollection<UserDiet>? UserDiet { get; set; }
    }
}
