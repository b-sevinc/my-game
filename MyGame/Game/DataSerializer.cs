using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MyGame.Game
{
    public static class DataSerializer
    {
        public static void JsonSerialize(List<User> userList, string path)
        {
            if (File.Exists(path)) File.Delete(path);
            var userListJson = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(path, userListJson);
        }
        
        public static object JsonDeserialize(string path)
        {
            var jsonString = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<User>>(jsonString);
        }
    }
}