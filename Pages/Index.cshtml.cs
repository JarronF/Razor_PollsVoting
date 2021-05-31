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
        public IndexModel(IPollRepository pollRepo, IHttpContextAccessor httpContextAccessor)
        {
            _pollRepo = pollRepo;
            _accessor = httpContextAccessor;

            clientIP = _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        public async Task OnGetAsync()
        {
            Polls = await _pollRepo.GetPollsAsync(clientIP);
        }
    }
}
