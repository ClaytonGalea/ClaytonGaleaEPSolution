using DataAccess.DataContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
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
    }
}
