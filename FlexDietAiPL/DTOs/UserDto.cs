using FlexDietAiDAL.Models;

namespace FlexDietAiPL.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string BashPassword { get; set; }

        static public UserDto FromUser(User user)
        {
            return new UserDto
            {
                Email = user.Email,
                BashPassword = user.BashPassword,
            };
        }
    }
}
