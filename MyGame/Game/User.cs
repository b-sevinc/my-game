using System;

namespace MyGame.Game
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; } = "";
        public string PhoneNumber { get; set; }
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public int UserType { get; set; } = (int)Enums.UserType.User;
        public int HighestScore { get; set; }
    }
}