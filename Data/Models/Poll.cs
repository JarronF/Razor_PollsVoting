using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razor_PollsVoting.Data.Models
{
    public class Poll
    {
        public int PollId { get; set; }
        [Display(Name = "Question")]
        public string PollQuestion { get; set; }        
        public DateTime DateEntered { get; set; }
        [Display(Name = "Expires")]
        public DateTime ExpirationDate { get; set; }
        public ICollection<Choice> Choices { get; set; }

        [NotMapped]
        public bool BeenAnswered { get; set; }
    }
}
