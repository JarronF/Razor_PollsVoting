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
                //2.1  Choices to get back.
                itm.Choices = await _pollRepo.LoadPollChoicesAsync(itm.PollId);

                //2.2  If the IP address has answered then flag that.
                var choice_answered = await _pollRepo.LoadAnsweredStatusAsync(itm.PollId, clientIP);
                if (choice_answered == null)
                {
                    itm.BeenAnswered = false;
                }
                else
                {
                    itm.BeenAnswered = true;
                    // 2.3  Track down which choice was picked.                    
                    foreach (var choice in itm.Choices)
                    {
                        if (choice.ChoiceId == choice_answered)
                        {
                            choice.UserPicked = true;
                        }
                    }
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
//            await _pollRepo.UpdateChoiceCount(vote.ChoiceId);

            return RedirectToPage("Index");
        }
    }
}
