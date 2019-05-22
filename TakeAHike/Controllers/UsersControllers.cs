using Microsoft.AspNetCore.Mvc;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Controllers
{
  public class UsersController : Controller
  {
    [Route("/users")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/users/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/users/show")]
    public ActionResult Show()
    {
      return View();
    }

    

    //This method creates a user and then returns the user to the Show page
    // [HttpPost("/users")]
    // public ActionResult Create(string userName, string firstName, string lastName, string phone, string email, string gender, string car, int id)
    // {
    //   return RedirectToAction("Show");
    // }

    // [HttpPost("/users/{userId}/trails")]
    // public ActionResult Create(string userName, int trailId, int id)
    // {
    //   User user = User.Find(userId);
    //   Trail trail = new Trail(name, trailId, id);
    //   trail.Save();
    //   return View("Show", user);
    // }






  }
}
