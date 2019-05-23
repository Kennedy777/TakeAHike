using Microsoft.AspNetCore.Mvc;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Controllers
{
  public class TrailsController : Controller
  {
    [Route("/trails")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/trails/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/trails/create")]
    public ActionResult Create(string name, int difficulty, int summits, bool waterfalls, bool streams, bool mountainViews, bool meadows, bool lakes, bool dogs, int id)
    {
      Trail newTrail = new Trail(name, difficulty, summits, waterfalls, streams, mountainViews, meadows, lakes, dogs);
      newTrail.Save();
      Trail.GetAll();
      return View("Show", newTrail);
    }

    [HttpGet("/trails/find")]
    public ActionResult Find()
    {
      return View();
    }
  }
}
