using FlexDietAiDAL.Models;

namespace FlexDietAiPL.DTOs
{
    public class UserDataDto
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Dof { get; set; }
        public string Somatotype { get; set; } = null!;

        public static UserDataDto FromUserData(UserData userData)
        {
            return new UserDataDto
            {
                Name = userData.Name,
                LastName = userData.LastName,
                Dof = userData.Dof,
                Somatotype = userData.Somatotype,
            };
        }
    }
}
