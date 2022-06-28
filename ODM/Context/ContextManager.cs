using Microsoft.EntityFrameworkCore;
using System;

namespace ODM.Context
{
    public class ContextManager : DbContext
    {
        private const string DATABASEFILE = "database.db";

        public string DbPath {get;}
        public ContextManager()
        {
            var path = @"full/path/to/your/project";
            DbPath = Path.Join(path, DATABASEFILE);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
	}
}

