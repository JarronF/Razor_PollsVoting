using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razor_PollsVoting.Data.Models;

namespace Razor_PollsVoting.Data
{
    public class PollContext : DbContext
    {
        public PollContext(DbContextOptions<PollContext> options) : base(options) { }
        public DbSet<Poll> Poll { get; set; }
        public DbSet<Choice> Choice { get; set; }
        public DbSet<Vote> Vote { get; set; }

        ////public Task<int> SaveChangesAsync()
        ////{
        ////    throw new NotImplementedException();
        ////}
    }
}
