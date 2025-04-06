using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public interface PollRepositoryInterface
    {
        void CreatePoll(Poll poll);
        IEnumerable<Poll> GetAllPolls();
        void Vote(int pollId, int selectedOption);
    }
}
