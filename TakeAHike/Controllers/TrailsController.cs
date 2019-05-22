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

    [HttpGet("/trail/new")]
    public ActionResult New()
    {
      return View();
    }

  }
}
