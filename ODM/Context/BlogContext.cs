using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ODM.Models;
namespace ODM.Context
{
	public class BlogContext : ContextManager
	{

		public BlogContext():base()
		{
		}
        public DbSet<Blog>? Blogs { get; set;}

	}
}

