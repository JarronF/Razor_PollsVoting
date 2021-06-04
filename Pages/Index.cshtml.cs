using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_PollsVoting.Data;
using Razor_PollsVoting.Data.Models;
using Razor_PollsVoting.Data.Repositories;

namespace Razor_PollsVoting.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPollRepository _pollRepo;
        private readonly IHttpContextAccessor _accessor;
        private string clientIP { get; set; }
        public List<Poll> Polls;
        [BindProperty]
        public int choiceSelected { get; set; }
        public string UserPickedClass { get; set; }
        public IndexModel(IPollRepository pollRepo, IHttpContextAccessor httpContextAccessor)
        {
            _pollRepo = pollRepo;
            _accessor = httpContextAccessor;

            clientIP = _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public async Task OnGetAsync()
        {
            Polls = await _pollRepo.GetPollsAsync(clientIP);
            foreach (var itm in Polls)
            {
                itm.Choices = await _pollRepo.LoadPollChoicesAsync(itm.PollId);

                double votesTotal = itm.Choices.Sum(c => c.Count);

                var choiceAnswered = await _pollRepo.LoadAnsweredStatusAsync(itm.PollId, clientIP);

                itm.BeenAnswered = choiceAnswered != null;

                foreach (var choice in itm.Choices)
                {
                    choice.UserPicked = choice.ChoiceId == choiceAnswered;
                    choice.Percentage = (choice.Count / votesTotal) * 100;
                }
            }
        }
        public async Task<IActionResult> OnPostAsync(int pollID)
        {
            Vote vote = new Vote()
            {
                IPAddress = clientIP,
                ChoiceId = choiceSelected,
                PollId = pollID,
                DateEntered = DateTime.Now
            };

            await _pollRepo.CreateVoteData(vote);

            return RedirectToPage("Index");
        }
    }
}
