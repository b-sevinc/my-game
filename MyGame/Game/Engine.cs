using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace MyGame.Game
{
    public class Engine
    {
        private static Engine _instance;
        private static List<User> _userList;
        private const string Filepath = "../../Users.xml";        
        public static User CurrentUser { get; set; }
        public static Engine Instance => _instance ?? (_instance = new Engine());
        private static XmlSerializer _serializer = new XmlSerializer(typeof(List<User>));

        private Engine()
        {
            CreateUsersXml();
        }
        
        private static void CreateUsersXml()
        {
            if (File.Exists(Filepath)) return;
            
            _userList = new List<User>();
            _userList.Add(new User() {Username = "user", Password = ToSha256("user"), UserType = 0});  // pre-registered
            _userList.Add(new User() {Username = "admin", Password = ToSha256("admin"), UserType = 9});  // pre-registered
            UpdateUserList(_userList);
        }
        
        public static List<User> ReadUsersXml()
        {
            using (var fs = new FileStream(Filepath, FileMode.Open, FileAccess.Read))
            {
                _userList = _serializer.Deserialize(fs) as List<User>;
            }

            return _userList;
        }

        public static void SaveUser(User user)
        {
            _userList.Add(user);
            UpdateUserList(_userList);
        }

        public static void UpdateUser(User newUser)
        {
            if (_userList.All(x => x.Username != newUser.Username)) return;

            User user = _userList.Find(x => x.Username == newUser.Username);

            _userList[_userList.IndexOf(user)] = newUser;

            UpdateUserList(_userList);
        }
        
        public static void UpdateUserList(List<User> userList)
        {
            using (var fs = new FileStream(Filepath, FileMode.Open, FileAccess.Write))
            {
                _serializer.Serialize(fs, userList);
            }
        }
        
        public static string ToSha256(string s)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
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