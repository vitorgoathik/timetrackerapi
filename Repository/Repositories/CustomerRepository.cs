using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Repository.Models;
using Dapper;

namespace Repository.Repositories
{
    public class CustomerRepository
    {
        public static bool Create(Customer item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Execute("INSERT Customer(name, address,phone,email) VALUES(@name,@address,@phone,@email)", new { name = item.Name, address = item.Address, phone = item.Phone, email = item.Email }) > 0;
            }
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute("DELETE FROM Customer WHERE CustomerID = @ID ", new { ID = id });
            }
        }

        public static List<Customer> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<Customer>("SELECT * FROM Customer").ToList();
            }
        }

        public static Customer ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<Customer>("SELECT * FROM Customer WHERE CustomerID = @ID", new { ID = id }).Single();
            }
        }

        public static void Update(Customer item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute("UPDATE Customer SET name=@name, address=@address, phone=@phone, email=@email WHERE customerID=@customerId", new { name = item.Name, address = item.Address, phone = item.Phone, email = item.Email, customerId = item.CustomerID});
            }
        }
    }
}
