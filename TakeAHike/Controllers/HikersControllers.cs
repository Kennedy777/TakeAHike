using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TakeAHike.Models;
using System;

namespace TakeAHike.Controllers
{
  public class HikersController : Controller
  {
    [Route("/hikers")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/hikers/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/hikers/show")]
    public ActionResult Show()
    {
      return View();
    }

    [HttpGet("/hikers/{id}/edit")]
    public ActionResult Edit(int hikerId)
    {
      Hiker newHiker = Hiker.Find(hikerId);
      return View(newHiker);
    }

    [HttpPost("/hikers/{id}/edit")]
    public ActionResult Update(int hikerId, string hikerName, string firstName, string lastName, int zip, string phone, string email, int gender, int car)
    {
      Hiker newHiker = Hiker.Find(hikerId);
      newHiker.Edit(hikerName, firstName, lastName, zip, phone, email, gender, car);
      return RedirectToAction("Index");
    }

    [HttpPost("/hikers/{id}/delete")]
    public ActionResult Delete(int hikerId)
    {
      Hiker newHiker = Hiker.Find(hikerId);
      newHiker.Delete();
      return RedirectToAction("Index");
    }


    //This method creates a hiker and then returns the hiker to the Show page
    // [HttpPost("/hikers")]
    // public ActionResult Create(string hikerName, string firstName, string lastName, string phone, string email, string gender, string car, int id)
    // {
    //   return RedirectToAction("Show");
    // }

    // [HttpPost("/hikers/{hikerId}/trails")]
    // public ActionResult Create(string hikerName, int trailId, int id)
    // {
    //   Hiker hiker = Hiker.Find(hikerId);
    //   Trail trail = new Trail(name, trailId, id);
    //   trail.Save();
    //   return View("Show", hiker);
    // }






  }
}
