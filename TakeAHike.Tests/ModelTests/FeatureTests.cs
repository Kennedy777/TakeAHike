using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeAHike.Models;
using System.Collections.Generic;
using System;

namespace TakeAHike.Tests
{
  [TestClass]
  public class FeatureTest : IDisposable
  {
    public FeatureTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kevin_garvey_test;";
    }

    // public void Dispose()
    // {
    //   Client.ClearAll();
    // }

  }
}
