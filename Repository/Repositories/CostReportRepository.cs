using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Repository.Models;
using Dapper;

namespace Repository.Repositories
{
    public class CostReportRepository
    {
        public static List<CostReport> ReadAll()
        {
            List<CostReport> costs = new List<CostReport>();
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
                foreach(var Project in ProjectRepository.ReadAll())
                    foreach(var hoursSum in db.Query<int>(@"SELECT sum(DATEDIFF(hour, [start], [end])) as TotalHours
                                                         FROM timerecord tr
                                                         where tr.ProjectID = @ProjectId
                                                         group by tr.projectId", new { ProjectID = Project.ProjectID }))
                        costs.Add(new CostReport() { CustomerName = Project.CustomerName, ProjectName = Project.Name, TotalHours = hoursSum, TotalCost = hoursSum * Project.CostPerHour });
            return costs;
        }

        public static List<CostReport> ReadById(int id)
        {
            List<CostReport> costs = new List<CostReport>();
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
                foreach (var Project in ProjectRepository.ReadAll())
                    foreach (var hoursSum in db.Query<int>(@"SELECT sum(DATEDIFF(hour, [start], [end])) as TotalHours
                                                         FROM timerecord tr
                                                         where tr.ProjectID = @ProjectId and tr.UserId = @UserId
                                                         group by tr.projectId", new { ProjectID = Project.ProjectID, UserId = id }))
                        costs.Add(new CostReport() { CustomerName = Project.CustomerName, ProjectName = Project.Name, TotalHours = hoursSum, TotalCost = hoursSum * Project.CostPerHour });

            return costs;
        }
    }
}
