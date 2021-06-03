using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_PollsVoting.Data.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public int PollId { get; set; }
        public string IPAddress { get; set; }
        public int ChoiceId { get; set; }
        public DateTime DateEntered { get; set; }
    }
}
