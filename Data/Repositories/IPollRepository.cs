using Razor_PollsVoting.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_PollsVoting.Data.Repositories
{
    public interface IPollRepository
    {
        public Task<List<Poll>> GetPollsAsync(string clientIP);
        public Task CreatePollAsync(Poll poll);
        public Task CreateVoteData(Vote vote);
        public Task<List<Choice>> LoadPollChoicesAsync(int pollId);
        public Task<int?> LoadAnsweredStatusAsync(int pollId, string clientIP);
    }
}
