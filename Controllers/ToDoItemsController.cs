using Microsoft.AspNetCore.Mvc;
using TaskToDoList.Data;
using TaskToDoList.Models;
using TaskToDoList.ViewModels;
namespace TaskToDoList.Controllers
{
    public class ToDoItemsController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SaveCreate(string Name)
        {
            return RedirectToAction("Items", new { name = Name });
        }


        public IActionResult Items(string Name)
        {
            ViewData["Name"] = Name;
            var Result = Context.Lists.ToList();
            return View(Result);
        }

        public IActionResult CreateNew(string Name)
        {
            return View();
        }
        public IActionResult SaveNew(string Name , ListVM listvm)
        {
            listvm.Name = Name;

            if(ModelState.IsValid)
            {
                List list = new List()
                {
                    Deadline = listvm.Deadline,
                    Description = listvm.Description,
                    Title = listvm.Title,
                    Id = listvm.Id,
                    Name = listvm.Name
                };

                Context.Lists.Add(list);
                Context.SaveChanges();
                return RedirectToAction("items");
            }
            return View("CreateNew");
        }
        public IActionResult Edit(int id)
        {
            var result = Context.Lists.Find(id);
            return View(result);
        }

        public IActionResult SaveEdit(List list)
        {
            Context.Lists.Update(list);
            Context.SaveChanges();
            return RedirectToAction("items");
        }
        public IActionResult Delete(int id)
        {
            var result = Context.Lists.Find(id);
                Context.Lists.Remove(result);
                Context.SaveChanges();

            return RedirectToAction("items");
        }
    }
}
