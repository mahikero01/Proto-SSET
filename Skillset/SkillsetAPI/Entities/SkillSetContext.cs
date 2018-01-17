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
            Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<SetUsers> SetUsers { get; set; }
    }
}
