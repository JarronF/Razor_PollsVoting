using Microsoft.EntityFrameworkCore;
using Razor_PollsVoting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_PollsVoting.Data.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly PollContext _db;
        
        public PollRepository(PollContext db)
        {
            _db = db;
        }

        public async Task<List<Poll>> GetPollsAsync(string clientIP)
        {
            List<Poll> pollList = new List<Poll>();
            pollList = await _db.Poll.ToListAsync();
                //.Where(p => p.ExpirationDate > DateTime.Now).ToListAsync();
                //.OrderByDescending(p => p.DateEntered).ToListAsync();

            return pollList;
        }        
    }
}
