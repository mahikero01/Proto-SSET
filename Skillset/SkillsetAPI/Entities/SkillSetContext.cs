using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsetAPI.Entities
{
    public class SkillSetContext : DbContext
    {
        public SkillSetContext(DbContextOptions<SkillSetContext> options) : base(options)
        {
            //This is only used for testing not for production
            //Database.EnsureCreated();

            //Comment below for using add-migration or changing the tables
            Database.Migrate();
        }

        public DbSet<SetUser> SetUsers { get; set; }
    }
}
