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
    public ActionResult Create(string name, int difficulty, int summits, bool waterfalls, bool streams, bool mountainViews, bool meadows, bool lakes, string location, int id)
    {
      Trail newTrail = new Trail(name, difficulty, summits, waterfalls, streams, mountainViews, meadows, lakes, location);
      newTrail.Save();
      Trail.GetAll();
      return View("Show", newTrail);
    }

    [HttpGet("/trails/{id}")]
    public ActionResult Show(int id)
    {
      Trail foundTrail = Trail.Find(id);
      return View(foundTrail);
    }

    [HttpGet("/trails/find")]
    public ActionResult Find()
    {
      return View();
    }

    [HttpGet("/trails/results")]
    public ActionResult Results(int difficulty, int summits, bool waterfalls, bool streams, bool mountainViews, bool meadows, bool lakes)
    {
      List<Trail> exactMatches = Trail.GetMatches(difficulty, summits, waterfalls, streams, mountainViews, meadows, lakes);
      List<Trail> partialMatches = Trail.GetPartialMatches(difficulty, summits, waterfalls, streams, mountainViews, meadows, lakes);
      Dictionary<string, object> model = new Dictionary<string, object> ();
      model.Add("partialMatches", partialMatches);
      model.Add("exactMatches", exactMatches);
      return View(model);
    }
  }
}
