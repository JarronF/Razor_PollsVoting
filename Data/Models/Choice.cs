using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_PollsVoting.Data.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public int Count { get; set; }         
        public Poll Poll { get; set; }
        [NotMapped]
        public bool UserPicked { get; set; }
        [NotMapped]
        public double Percentage { get; set; }
    }
}
