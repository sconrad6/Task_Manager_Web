using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_List_Manager.Models;

namespace Task_List_Manager.Controllers
{
    public class TasksController : Controller
    {
        private readonly TasksDbContext _context;

        public TasksController(TasksDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Login(string password)
        {
            UserInformation found = _context.UserInformation.Find(password);
            if (found != null)
            {
                var foundUser = _context.UserInformation;
                return RedirectToAction("Welcome"); 
            }
            return View();
        }


        public IActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(UserInformation newUser)
        {
            if (ModelState.IsValid)
            {
                _context.UserInformation.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Models.Task newTask)
        {
            if (ModelState.IsValid)
            {
                _context.Task.Add(newTask);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult ViewTasks(Models.Task task)
        {
            return View(task);
        }

        public IActionResult Welcome()
        {
            return View();
        }

      
    }
}