using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class Trail
  {
    private string _name;
    private int _id;
    private int _difficulty;
    private float _distance;
    private bool _waterfalls;
    private bool _summits;
    private bool _wildlife;
    private bool _dogs;

    public Trail (string name, int difficulty, float distance, bool waterfalls = false, bool summits = false, bool wildlife =false, bool dogs = false, int id = 0)
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO trails (name, difficulty, distance, waterfalls, summits, wildlife, dogs) VALUES (@trailName, @trailDifficulty, @trailDistance, @trailWaterfalls, @trailSummits, @trailWildlife, @trailDogs);";

      MySqlParameter trailName = new MySqlParameter();
      trailName.ParameterName = "@trailName";
      trailName.Value = this._name;
      cmd.Parameters.Add(trailName);

      MySqlParameter trailDifficulty = new MySqlParameter();
      trailDifficulty.ParameterName = "@trailDifficulty";
      trailDifficulty.Value = this._difficulty;
      cmd.Parameters.Add(trailDifficulty);

      MySqlParameter trailDistance = new MySqlParameter();
      trailDistance.ParameterName = "@trailDistance";
      trailDistance.Value = this._distance;
      cmd.Parameters.Add(trailDistance);

      MySqlParameter trailWaterfalls = new MySqlParameter();
      trailWaterfalls.ParameterName = "@trailWaterfalls";
      trailWaterfalls.Value = this._waterfalls;
      cmd.Parameters.Add(trailWaterfalls);

      MySqlParameter trailSummits = new MySqlParameter();
      trailSummits.ParameterName = "@trailSummits";
      trailSummits.Value = this._summits;
      cmd.Parameters.Add(trailSummits);

      MySqlParameter trailWildlife = new MySqlParameter();
      trailWildlife.ParameterName = "@trailWildlife";
      trailWildlife.Value = this._wildlife;
      cmd.Parameters.Add(trailWildlife);

      MySqlParameter trailDogs = new MySqlParameter();
      trailDogs.ParameterName = "@trailDogs";
      trailDogs.Value = this._dogs;
      cmd.Parameters.Add(trailDogs);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Trail> GetAll()
    {
      List<Trail> allTrails = new List<Trail>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int Id = rdr.GetInt32(0);
        string Name = rdr.GetString(1);
        int Difficulty = rdr.GetInt32(2);
        float Distance = rdr.GetFloat(3);
        bool Waterfalls = rdr.GetBoolean(4);
        bool Summits = rdr.GetBoolean(5);
        bool Wildlife = rdr.GetBoolean(6);
        bool Dogs = rdr.GetBoolean(7);
        Trail newTrail = new Trail(Name, Difficulty, Distance, Waterfalls, Summits, Wildlife, Dogs, Id);
        allTrails.Add(newTrail);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allTrails;
    }

    public override bool Equals(System.Object otherTrail)
    {
      if(!(otherTrail is Trail))
      {
        return false;
      }
      else
      {
        Trail newTrail = (Trail) otherTrail;
        bool idEquality = this.GetId().Equals(newTrail.GetId());
        bool nameEquality = this.GetName().Equals(newTrail.GetName());
        bool difficultyEquality = this.GetDifficulty().Equals(newTrail.GetDifficulty());
        bool distanceEquality = this.GetDistance().Equals(newTrail.GetDistance());
        bool waterfallsEquality = this.GetWaterfalls().Equals(newTrail.GetWaterfalls());
        bool summitsEquality = this.GetSummits().Equals(newTrail.GetSummits());
        bool wildlifeEquality = this.GetWildlife().Equals(newTrail.GetWildlife());
        bool dogsEquality = this.GetDogs().Equals(newTrail.GetDogs());
        return (idEquality && nameEquality && difficultyEquality && distanceEquality && waterfallsEquality && summitsEquality && wildlifeEquality && dogsEquality);
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM trails;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if ( conn != null )
      {
        conn.Dispose();
      }
    }


  }
}
