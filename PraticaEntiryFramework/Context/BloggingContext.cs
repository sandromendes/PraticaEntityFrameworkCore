using Microsoft.EntityFrameworkCore;
using PraticaEntiryFramework.Model.OneToMany;
using System;
using System.Collections.Generic;
using System.Text;

namespace PraticaEntiryFramework.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=DBBlogging;Integrated Security=True");
        }
    }
}
