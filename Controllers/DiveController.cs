using Microsoft.AspNetCore.Mvc;
using Diving_List.Models;

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
        public IActionResult UpdateNotes(int id)
        {
            Dive dive = repo.GetDive(id);
            if (dive == null)
            {
                return View("DiveNotFound");
            }
            return View(dive);
        }
        public IActionResult UpdateNotesToDatabase(Dive dive)
        {
            repo.UpdateNotes(dive);

            return RedirectToAction("ViewDive", new { id = dive.DiveNo });
        }
        public IActionResult InsertDive(Dive newDive)
        {
            return View(newDive);
        }
        public IActionResult InsertDiveToDatabase(Dive newDive)
        {
       
                try
                {
                    repo.InsertDive(newDive);
                    return RedirectToAction("Index");
                    

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
            return View("DivesInUse");
                }
           
        }
    }
}
