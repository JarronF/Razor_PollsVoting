using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_PollsVoting.Data.Repositories;
using Razor_PollsVoting.Data.Models;

namespace Razor_PollsVoting.Pages
{
    public class AdminModel : PageModel
    {   
        private readonly IHttpContextAccessor _accessor;
        private readonly IPollRepository _pollRepo;
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        [Display(Name = "Question")]
        public string Question { get; set; }
        [BindProperty]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [BindProperty]
        [Display(Name = "Choices")]
        public string Choices { get; set; }
        public AdminModel(IPollRepository pollRepo, IHttpContextAccessor httpContextAccessor)
        {

            _pollRepo = pollRepo;
            _accessor = httpContextAccessor;
            Message += $" {_accessor.HttpContext.Connection.RemoteIpAddress}";

            ExpirationDate = DateTime.Now.AddDays(3);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var tempChoices = Choices.Split(Environment.NewLine);
            var poll = new Poll
            {
                PollQuestion = Question,
                ExpirationDate = ExpirationDate,
                DateEntered = DateTime.Now,
                Choices = new List<Choice>()
            };

            foreach (string choice in tempChoices)
            {
                poll.Choices.Add(
                    new Choice
                    {
                        ChoiceText = choice
                    }
                    );
            }

            await _pollRepo.CreatePollAsync(poll);
            return RedirectToPage("Admin");
        }

    }
}
