using DataAccess;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PollController : Controller
    {
        private PollRepository _repository;

        //Constructor injection
        public PollController(PollRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Create()
        {
            return View();
        }

        //Method injection of poll
        [HttpPost]
        public IActionResult Create(Poll poll)
        {    
            _repository.CreatePoll(poll);
            return RedirectToAction("Index");
        }
    }
}
