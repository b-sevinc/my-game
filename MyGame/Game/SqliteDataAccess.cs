using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace MyGame.Game
{
    public static class SqliteDataAccess
    {
        public static List<User> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>("SELECT * from User", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into User (Username, Password, FullName, PhoneNumber, City, Country, Email, Address, UserType) " +
                            " values (@Username, @Password, @FullName, @PhoneNumber, @City, @Country, @Email, @Address, @UserType)", user);
            }
        }

        public static void RemoveUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("delete from user where Username='"+ user.Username + "'");
            }
        }
        
        public static void UpdateUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "update user set Fullname='" + user.FullName + "', PhoneNumber='" + user.PhoneNumber
                             + "', City='" + user.City + "', Country='" + user.Country + "', Email='" + user.Email
                             + "', Address='" + user.Address + "', UserType='" + user.UserType + "', HighestScore='"
                             + user.HighestScore + "' where Username='" + user.Username + "'";
                cnn.Execute(sql);
            }
        }
        
        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}