using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyGame.Game
{
    public class Engine
    {
        private static Engine _instance;
        private static List<User> _userList;
        private const string FilepathJson = "../../Users.json";
        public static User CurrentUser { get; set; }
        public static Engine Instance => _instance ?? (_instance = new Engine());

        private Engine()
        {
            CreateUsersJson();
        }

        private static void CreateUsersJson()
        {
            if (File.Exists(FilepathJson)) return;
            
            _userList = new List<User>  // pre-registered users
            {
                new User {Username = "user", Password = ToSha256("user"), UserType = 0},
                new User {Username = "admin", Password = ToSha256("admin"), UserType = 9},
            };
            
            UpdateUserList();
        }

        public static List<User> ReadUsersJson()
        {
            _userList = DataSerializer.JsonDeserialize(FilepathJson) as List<User>;
            return _userList;
        }

        public static void AddUser(User user)
        {
            _userList.Add(user);
            UpdateUserList();
        }

        public static void UpdateUser(User newUser)
        {
            if (_userList.All(x => x.Username != newUser.Username)) return;

            var user = _userList.Find(x => x.Username == newUser.Username);

            _userList[_userList.IndexOf(user)] = newUser;

            UpdateUserList();
        }
        
        public static void RemoveUser(User targetUser)
        {
            if (_userList.All(x => x.Username != targetUser.Username)) return;
            var user = _userList.Find(x => x.Username == targetUser.Username);
            _userList.Remove(user);
            UpdateUserList();
        }

        public static void UpdateUserList()
        {
            DataSerializer.JsonSerialize(_userList, FilepathJson);
        }

        public static string ToSha256(string s)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                var sb = new StringBuilder();
                foreach (var t in bytes)
                {
                    sb.Append(t.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static bool IsPasswordCorrect(string s)
        {
            if (CurrentUser is null) return false;
            
            return CurrentUser.Password == ToSha256(s);
        }
    }
}