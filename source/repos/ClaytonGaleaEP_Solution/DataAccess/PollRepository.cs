using DataAccess.DataContext;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PollRepository
    {
        private PollDbContext _context;
        public PollRepository(PollDbContext context)
        {
            _context = context;
        }
        public void CreatePoll(Poll poll)
        {
            poll.Option1VotesCount = 0;
            poll.Option2VotesCount = 0;
            poll.Option3VotesCount = 0;
            poll.DateCreated = DateTime.Now;

            _context.Polls.Add(poll);
            _context.SaveChanges();
        }

        public IEnumerable<Poll> GetAllPolls()
        {
            return _context.Polls;
        }

        public void Vote(int pollId, int selectedOption)
        {
            var poll = _context.Polls.FirstOrDefault(p => p.Id == pollId);
            if (poll == null)
            {
                return;
            }

            switch (selectedOption)
            {
                case 1:
                    poll.Option1VotesCount++;
                    break;
                case 2:
                    poll.Option2VotesCount++;
                    break;
                case 3:
                    poll.Option3VotesCount++;
                    break;
                default:
                    return;
            }
            _context.SaveChanges();
        }
    }
}
