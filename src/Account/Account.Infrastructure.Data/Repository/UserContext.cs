using Microsoft.EntityFrameworkCore;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Data.Repository
{
    public class UserContext : DbContext
    {
        public UserContext()
        {

        }

        public UserContext(DbContextOptions<UserContext> options) 
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("User.InMemory");
            }
        }
    }
}
