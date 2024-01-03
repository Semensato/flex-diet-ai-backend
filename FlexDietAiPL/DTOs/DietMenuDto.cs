using FlexDietAiDAL.Models;

namespace FlexDietAiPL.DTOs
{
    public class DietMenuDto
    {
        public int DietMenuId { get; set; }
        public string Name { get; set; } = null!;
        public string Menu { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Kcal { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public static List<DietMenuDto> FromDietMenu(ICollection<DietMenu> dietMenus)
        {
            List<DietMenuDto> dietMenuDtos = new List<DietMenuDto>();

            foreach(var dietMenu in dietMenus)
            {
                dietMenuDtos.Add(new DietMenuDto { 
                    DietMenuId = dietMenu.DietMenuId,
                    Name = dietMenu.Name,
                    Menu = dietMenu.Menu,
                    Date = DateTime.Now,
                    Kcal = dietMenu.Kcal,
                    InitialDate = DateTime.Now,
                    FinishDate = DateTime.Now,
                });
            }

            return dietMenuDtos;
        }
    }
}
