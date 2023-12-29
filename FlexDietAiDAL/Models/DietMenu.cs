using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Models
{
    [Table("DietsMenus")]
    public class DietMenu
    {
        [Key]
        public int DietMenuId { get; set; }
        public string Name { get; set; } = null!;
        public string Menu { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Kcal { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinishDate { get; set; }

        // UserDiet FK.
        public int UserDietId { get; set; }
        public UserDiet UserDiet { get; set; }
    }
}
