using FlexDietAiDAL.Models;

namespace FlexDietAiPL.DTOs
{
    public class UserDietDto
    {
        public int UserDietId { get; set; }
        public string Name { get; set; } = null!;
        public string Goal { get; set; } = null!;
        public DateTime InitialDate { get; set; }
        public DateTime FinishDate { get; set; }

        public static List<UserDietDto> FromUserDiet(ICollection<UserDiet> userDiets)
        {
            List<UserDietDto> userDietDtos = new List<UserDietDto>();

            foreach(var userDiet in userDiets)
            {
                userDietDtos.Add(new UserDietDto { 
                    UserDietId = userDiet.UserDietId,
                    Name = userDiet.Name,
                    Goal = userDiet.Goal,
                    InitialDate = userDiet.InitialDate,
                    FinishDate = userDiet.FinishDate,
                });
            }

            return userDietDtos;
        }
    }
}
