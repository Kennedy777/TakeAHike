using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class Hike
  {
    private string _name;
    private int _difficulty;
    private float _distance;
    private int _id;

    public Client (string name, int difficulty, float distance, int id = 0)
    {
      _name = name;
      _difficulty = difficulty;
      _distance = distance;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetDifficulty()
    {
      return _difficulty;
    }
    public void SetDifficulty( int newDifficulty)
    {
      _difficulty = newDifficulty;
    }

    public float GetDistance()
    {
      return _distance;
    }
    public void SetDistance(float newDistance)
    {
      _distance = newDistance;
    }

    public int GetId()
    {
      return _id;
    }

  }
}
