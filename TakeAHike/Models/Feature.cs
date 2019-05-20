using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class Feature
  {
    private string _description;
    private bool _waterfalls;
    private bool _summits;
    private bool _wildlife;
    private bool _dogs;
    private int _id;

    public Feature(string description, int id = 0)
    {
      _description = description;
      _id = id;
    }

    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public bool GetWaterfalls()
    {
      return _waterfalls;
    }
    public void SetWaterfalls(bool hasWaterfalls)
    {
      _waterfalls = hasWaterfalls;
    }

    public bool GetSummits()
    {
      return _summits;
    }
    public void SetSummits(bool hasSummits)
    {
      _summits = hasSummits;
    }

    public bool GetWildlife()
    {
      return _wildlife;
    }
    public void SetWildlife(bool hasWildlife)
    {
      _wildlife = hasWildlife;
    }

    public bool GetDogs()
    {
      return _dogs;
    }
    public void SetDogs(bool isDogFriendly)
    {
      _dogs = isDogFriendly;
    }
    
  }
}
