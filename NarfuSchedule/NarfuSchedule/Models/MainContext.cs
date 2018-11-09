using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NarfuSchedule.Models
{
    public class MainContext : DbContext
    {
        private static string _databasePath;

        public DbSet<Lesson> Lessons { get; set; }

        private MainContext() { }

        public static void SetPath(string dbpath)
        {
            _databasePath = dbpath;
        }

        private static MainContext _instance;

        public static MainContext GetInstance()
        {
            return _instance ?? (_instance = new MainContext());
        }

        public IEnumerable<IGrouping<string, Lesson>> GetGrouperLessons()
        {
            return Lessons.OrderBy(x => x.Time).GroupBy(x => x.Time.ToString("dd.MM.yyyy (dddd)"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}