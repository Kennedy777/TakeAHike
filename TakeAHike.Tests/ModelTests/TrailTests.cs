using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Tests
{
  [TestClass]
  public class TrailTest : IDisposable
  {
    public TrailTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=takeahiketest;";
    }

    // public void Dispose()
    // {
    //   Client.ClearAll();
    // }

    [TestMethod]
    public void TrailConstructor_CreatesNewInstanceOfObject_Trail()
    {
    user newTrail = new Trail("Test Name");
    Asser.AreEqual(typeof(user), newTrail.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsTrailName_String()
    {
      string name = "Test Name";
      user newTrail = new Trail(name);
      string result = newTrail.GetName();
      Assert.AreEqual(name, result)
    }

  }
}
