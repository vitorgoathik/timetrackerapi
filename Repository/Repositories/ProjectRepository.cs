using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Repository.Models;
using Dapper;

namespace Repository.Repositories
{
    public class ProjectRepository
    {
        public static bool Create(Project item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Execute(@"INSERT Project(name, customerId,costperhour) 
                    VALUES(@name,@customerId,@costperhour)", 
                    new { name = item.Name, customerId = item.CustomerID, CostPerHour = item.CostPerHour }) > 0;
            }
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute("DELETE FROM Project WHERE ProjectId= @ID ", new { ID = id });
            }
        }

        public static List<Project> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<Project>(@"SELECT p.ProjectID, p.Name, c.Name as CustomerName, p.CostPerHour, p.CustomerID
                                            FROM Project p
                                            INNER JOIN Customer c on p.CustomerID = c.CustomerID")
                                            .ToList();
            }
        }

        public static Project ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<Project>(@"SELECT p.ProjectID, p.Name, c.Name as CustomerName, p.CostPerHour, p.CustomerID
                                            FROM Project p
                                            INNER JOIN Customer c on p.CustomerID = c.CustomerID
                                            WHERE ProjectId = @ID", new { ID = id }).Single();
            }
        }

        public static void Update(Project item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute(@"UPDATE Project 
                    SET name=@name, customerid=@customerid, costperhour=@costperhour
                    WHERE ProjectId=@ProjectId", 
                    new { name = item.Name, customerId = item.CustomerID, costperhour = item.CostPerHour, ProjectId = item.ProjectID});
            }
        }
    }
}
