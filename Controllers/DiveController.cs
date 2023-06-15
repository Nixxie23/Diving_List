using Microsoft.AspNetCore.Mvc;

namespace Diving_List.Controllers
{
    public class DiveController : Controller
    {
        private readonly IDiveRepository repo;

        public DiveController(IDiveRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var dives = repo.GetAllDives();
            return View(dives);
        }
        public IActionResult ViewDive(int id)
        {
            var dive = repo.GetDive(id);
            return View(dive);
        }
    }
}
