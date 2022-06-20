using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ODM.Models;
namespace ODM.Context
{
	public class BlogContext : DbContext
	{
        private const string DatabaseFile = "database.db";

        public string DbPath {get;}
		public BlogContext()
		{

            var path = @"full/path/to/your/project";
            DbPath = System.IO.Path.Join(path, DatabaseFile);
		}
        public DbSet<Blog> Blogs { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
	}
}

