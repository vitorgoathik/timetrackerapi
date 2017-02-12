using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using Repository.Models;
using Dapper;

namespace Repository.Repositories
{
    public class TimeRecordRepository
    {
        public static bool Create(TimeRecord item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Execute(@"INSERT TimeRecord(userid, projectid, [start], [end], comments) 
                                    VALUES(@userid,@projectid,@start,@end,@comments)", 
                                    new { userid = item.UserID, projectid = item.ProjectID, start = item.Start, end = item.End, Comments = item.Comments }) > 0;
            }
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute("DELETE FROM TimeRecord WHERE TimeRecordID = @ID ", new { ID = id });
            }
        }

        public static List<TimeRecord> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<TimeRecord>(@"SELECT tr.TimeRecordID, u.[Name] as UserName, p.[Name] as ProjectName, tr.[start], tr.[end], tr.comments, tr.UserID, tr.ProjectID 
                                                FROM TimeRecord tr
                                                INNER JOIN [User] u 
                                                ON tr.UserID = u.UserID
                                                INNER JOIN Project p
                                                ON tr.ProjectID = p.ProjectID").ToList();
            }
        }

        public static TimeRecord ReadById(int id)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                return db.Query<TimeRecord>(@"SELECT tr.TimeRecordID, u.[Name] as UserName, p.[Name] as ProjectName, tr.[start], tr.[end], tr.comments, tr.UserID, tr.ProjectID 
                                                FROM TimeRecord tr
                                                INNER JOIN [User] u 
                                                ON tr.UserID = u.UserID
                                                INNER JOIN Project p
                                                ON tr.ProjectID = p.ProjectID WHERE TimeRecordID = @ID", new { ID = id }).Single();
            }
        }

        public static void Update(TimeRecord item)
        {
            using (IDbConnection db = new SqlConnection(DatabaseConnectionManager.ConnectionString))
            {
                db.Execute(@"UPDATE TimeRecord 
                    SET userid=@userid, projectid=@projectid, [start]=@start, [end]=@end, comments=@comments 
                    WHERE TimeRecordID=@TimeRecordId", 
                    new { userid = item.UserID, projectid = item.ProjectID, start = item.Start, end = item.End, comments = item.Comments, TimeRecordId = item.TimeRecordID});
            }
        }
    }
}
