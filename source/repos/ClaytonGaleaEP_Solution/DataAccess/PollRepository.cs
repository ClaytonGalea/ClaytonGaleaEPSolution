using DataAccess.DataContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PollRepository
    {
        private readonly PollDbContext _context;

        public PollRepository(PollDbContext context)
        {
            _context = context;
        }

        public void CreatePoll(
            string title,
            string option1Text,
            string option2Text,
            string option3Text)
        {
            var poll = new Poll();
            poll.Title = title;
            poll.Option1Text = option1Text;
            poll.Option2Text = option2Text;
            poll.Option3Text = option3Text;

            poll.Option1VotesCount = 0;
            poll.Option2VotesCount = 0;
            poll.Option3VotesCount = 0;

            poll.DateCreated = DateTime.Now;

            _context.Polls.Add(poll);
            _context.SaveChanges();
        }
    }
}
