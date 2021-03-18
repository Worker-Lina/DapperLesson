using Dapper;
using DapperLesson.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DapperLesson.Data
{
    public class TeamDataAccess :DbDataAccess<Team>
    {
        /*public List<Team> GetAll()
        {
            using(var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server = DESKTOP-6543DI3; Database = EFCoreStartLesson; Trusted_Connection=true;";
                //connection.Open(); - в dapper это необязательно, он сам откроет подключение где ему нужно

                var sql = "select * from Teams";
                // создавать SqlCommand не надо 
                return connection.Query<Team>(sql).ToList();
                
            }
        }*/    

        public override ICollection<Team> Select()
        {
            var sql = "select * from Teams";
            return connection.Query<Team>(sql).ToList();
        }

        public override void Insert(Team team)
        {
            connection.Execute("Insert into teams (Id, Name) values (@Id, @Name)");
        }

        public override void Update(Team team)
        {
            var sql = "UPDATE Teams SET Name = @Name where id = @id";
            connection.Execute(sql,team);
        }

        public override void Delete(Guid teamId)
        {
            var sql = "Delete from teams where id = @id";
            connection.Execute(sql, new { teamId });
        }
    }
}
