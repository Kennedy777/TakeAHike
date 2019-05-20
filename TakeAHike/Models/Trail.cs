using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class Hike
  {
    private string _name;
    private int _id;
    private int _difficulty;
    private float _distance;
    private bool _waterfalls;
    private bool _summits;
    private bool _wildlife;
    private bool _dogs;

    public Client (string name, int difficulty, float distance, bool waterfalls, bool summits, bool wildlife, bool dogs, int id = 0)
    {
      _name = name;
      _id = id;
      _difficulty = difficulty;
      _distance = distance;
      _waterfalls = waterfalls;
      _summits = summits;
      _wildlife = wildlife;
      _dogs = dogs;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetDifficulty()
    {
      return _difficulty;
    }

    public float GetDistance()
    {
      return _distance;
    }

    public bool GetWaterfalls()
    {
      return _waterfalls;
    }

    public bool GetSummits()
    {
      return _summits;
    }

    public bool GetWildlife()
    {
      return _wildlife;
    }

    public bool GetDogs()
    {
      return _dogs;
    }

  }
}
