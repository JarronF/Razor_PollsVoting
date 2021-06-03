﻿using Microsoft.EntityFrameworkCore;
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
            List<Poll> pollList = await _db.Poll
                .Where(p => p.ExpirationDate > DateTime.Now)
                .Include(p => p.Choices).ToListAsync();
            //.OrderByDescending(p => p.DateEntered).ToListAsync();

            return pollList;
        }
        public async Task CreatePollAsync(Poll poll)
        {
            _db.Add(poll);
            await _db.SaveChangesAsync();
        }

        public async Task CreateVoteData(VotingData vote)
        {
            _db.Add(vote);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Choice>> LoadPollChoicesAsync(int pollId)
        {
            List<Choice> choiceList = new List<Choice>();

            choiceList = await _db.Choice
                .Where(choice => choice.Poll.PollId == pollId).ToListAsync();

            return choiceList;
        }

        public async Task<int?> LoadAnsweredStatusAsync(int pollId, string clientIP)
        {
            var voted = await _db.VotingData
                .FirstOrDefaultAsync(vote => vote.PollId == pollId && vote.IPAddress == clientIP);

            if (voted != null) 
                return voted.ChoiceId;

            return null;
        }
    }
}
