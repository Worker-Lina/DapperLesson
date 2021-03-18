using Dapper;
using DapperLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperLesson.Data
{
    public class PlayerDataAccess : DbDataAccess<Player>
    {
        public override ICollection<Player> Select()
        {
            var sql = "select * from Players";
            return connection.Query<Player>(sql).ToList();
        }

        public override void Insert(Player player)
        {
            connection.Execute("Insert into players (Id, FullName, Number,TeamId) values (@Id, @FullName, @Number, @TeamId)",player);
        }

        public override void Update(Player player)
        {
            var sql = "UPDATE players SET FullName = @FullName where id = @id";
            connection.Execute(sql, player);
        }

        public override void Delete(Guid playerId)
        {
            var sql = "Delete from players where id = @id";
            connection.Execute(sql, new { playerId });
        }
    }
}
