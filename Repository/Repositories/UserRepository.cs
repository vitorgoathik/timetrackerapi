using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Repository.Models;
using Dapper;

namespace Repository.Repositories
{
    public class UserRepository
    {
        public static bool Create(User item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Execute("INSERT [User](name) VALUES(@name)", new { name = item.Name }) > 0;
            }
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute("DELETE FROM [User] WHERE UserID = @ID ", new { ID = id });
            }
        }

        public static List<User> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<User>("SELECT * FROM [User]").ToList();
            }
        }

        public static User ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<User>("SELECT * FROM [User] WHERE UserID = @ID", new { ID = id }).Single();
            }
        }

        public static void Update(User item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute("UPDATE [User] SET name=@name WHERE UserID=@UserId", new { name = item.Name, UserId = item.UserID});
            }
        }
    }
}
