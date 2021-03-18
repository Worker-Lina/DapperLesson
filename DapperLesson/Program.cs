using DapperLesson.Data;
using DapperLesson.Models;
using DapperLesson.Service;
using System;

namespace DapperLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            InitConfiguration();

            var player = new Player
            {
                FullName = "Maks",
                Number = 23,
                TeamId = new Guid("7E7E5C30-7B47-4A8E-A4E4-14664A83A55D")
            };
            
            using(var context = new PlayerDataAccess())
            {
                context.Insert(player);
                var players = context.Select();

                foreach(var plaer in players)
                {
                    Console.WriteLine($"{plaer.FullName}");
                }

                
            }
        }

        private static void InitConfiguration()
        {
            ConfigurationService.Init();
        }
    }
}
