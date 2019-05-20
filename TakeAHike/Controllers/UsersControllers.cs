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
  }
}
