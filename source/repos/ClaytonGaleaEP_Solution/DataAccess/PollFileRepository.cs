using Domain.Models;
using System.Text.Json;

namespace DataAccess
{
    public class PollFileRepository
    {
        private string _filePath = "polls.json";

        public void CreatePoll(Poll poll)
        {
            var polls = GetPolls().ToList();

            // This line is aggasning a new ID
            //Gets the highest id and adss 1 to id every time
            //Else its the first 1 therefore 1 is the id
            poll.Id = polls.Any() ? polls.Max(p => p.Id) + 1 : 1;
            poll.DateCreated = DateTime.Now;

            
            poll.Option1VotesCount = 0;
            poll.Option2VotesCount = 0;
            poll.Option3VotesCount = 0;

            polls.Add(poll);

            var json = JsonSerializer.Serialize(polls, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<Poll> GetPolls()
        {
            if (!File.Exists(_filePath))
                return new List<Poll>();

            var json = File.ReadAllText(_filePath);

            var polls = JsonSerializer.Deserialize<List<Poll>>(json);

            return polls ?? new List<Poll>();
        }
    }
}
