using FlexDietAiDAL.Models;

namespace FlexDietAiPL.DTOs
{
    public class UserHealthDto
    {
        public int UsersHealthId { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }

        public static List<UserHealthDto> FromUserHealth(ICollection<UserHealth> userHealths)
        {
            List<UserHealthDto> userHealthsDto = new List<UserHealthDto>();

            foreach (var userHealth in userHealths)
            {
                userHealthsDto.Add(new UserHealthDto {
                    UsersHealthId = userHealth.UsersHealthId,
                    Height = userHealth.Height,
                    Weight = userHealth.Weight,
                    Age = userHealth.Age,
                    Date = userHealth.Date,
                });
            }

            return userHealthsDto;
        }
    }
}
