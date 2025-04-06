using DataAccess;
using DataAccess.DataContext;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PollController : Controller
    {
        //private PollRepository _repository;
        private PollRepositoryInterface _repository;

        //Constructor injection
        public PollController(PollRepositoryInterface repository)
        {
            _repository = repository;
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Vote(int id)
        {
            var poll = _repository.GetAllPolls().FirstOrDefault(p => p.Id == id);
            if(poll == null)
            {
                return View();
            }
            return View(poll);
        }
        [HttpPost]
        public IActionResult Vote(int id, int selectedOption)
        {
           
            _repository.Vote(id, selectedOption);
            TempData["SuccessMessage"] = "Your vote was submitted successfully!";
            return RedirectToAction("Index");
        }


        //Method injection of poll
        [HttpPost]
        public IActionResult Create(Poll poll)
        {    
            _repository.CreatePoll(poll);
            TempData["SuccessMessage"] = "Poll created successfully!";
            return RedirectToAction("Index");

        }

        public IActionResult Index()
        {
            var polls = _repository.GetAllPolls().OrderByDescending(p => p.DateCreated);
            
            return View(polls);
        }

        
    }
}
