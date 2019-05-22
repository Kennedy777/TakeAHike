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
    private int _summits;
    private bool _streams;
    private bool _mountainViews;
    private bool _meadows;
    private bool _lakes;
    private bool _dogs;

    public Trail (string name, int difficulty, float distance, int summits, bool waterfalls, bool streams, bool mountainViews, bool meadows, bool lakes, bool dogs, int id = 0)
    {
      _name = name;
      _id = id;
      _difficulty = difficulty;
      _distance = distance;
      _waterfalls = waterfalls;
      _summits = summits;
      _streams = streams;
      _mountainViews = mountainViews;
      _meadows = meadows;
      _lakes = lakes;
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

    public int GetSummits()
    {
      return _summits;
    }

    public bool GetStreams()
    {
      return _streams;
    }
    public bool GetMountainViews()
    {
      return _streams;
    }
    public bool GetMeadows()
    {
      return _streams;
    }
    public bool GetLakes()
    {
      return _streams;
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
      cmd.CommandText = @"INSERT INTO trails (name, difficulty, distance, waterfalls, summits, streams, mountainViews, meadows, lakes, dogs) VALUES (@trailName, @trailDifficulty, @trailDistance, @trailSummits, @trailWaterfalls, @trailStreams, @trailMountainViews, @trailMeadows, @trailLakes @trailDogs);";

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

      MySqlParameter trailStreams = new MySqlParameter();
      trailStreams.ParameterName = "@trailStreams";
      trailStreams.Value = this._streams;
      cmd.Parameters.Add(trailStreams);

      MySqlParameter trailMountainViews = new MySqlParameter();
      trailMountainViews.ParameterName = "@trailMountainViews";
      trailMountainViews.Value = this._mountainViews;
      cmd.Parameters.Add(trailMountainViews);

      MySqlParameter trailmeadows = new MySqlParameter();
      trailmeadows.ParameterName = "@trailmeadows";
      trailmeadows.Value = this._meadows;
      cmd.Parameters.Add(trailmeadows);

      MySqlParameter trailLakes = new MySqlParameter();
      trailLakes.ParameterName = "@trailLakes";
      trailLakes.Value = this._lakes;
      cmd.Parameters.Add(trailLakes);

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

    public static List<Trail> GetAll()
    {
      List<Trail> allTrails = new List<Trail>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int TrailId = rdr.GetInt32(0);
        string TrailName = rdr.GetString(1);
        int TrailDifficulty = rdr.GetInt32(2);
        float TrailDistance = rdr.GetFloat(3);
        int TrailSummits = rdr.GetInt32(4);
        bool TrailWaterfalls = rdr.GetBoolean(5);
        bool TrailStreams = rdr.GetBoolean(6);
        bool TrailMountainViews = rdr.GetBoolean(7);
        bool TrailMeadows = rdr.GetBoolean(8);
        bool TrailLakes = rdr.GetBoolean(9);
        bool TrailDogs = rdr.GetBoolean(10);

        Trail newTrail = new Trail(TrailName, TrailDifficulty, TrailDistance, TrailSummits, TrailWaterfalls, TrailStreams, TrailMountainViews, TrailMeadows, TrailLakes, TrailDogs, TrailId);
        allTrails.Add(newTrail);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allTrails;
    }

    public static List<Trail> GetFiltered(int inputtedDifficulty, float inputtedDistance, bool inputtedWaterfalls, int inputtedSummits, bool inputtedStreams, bool inputtedMountainViews, bool inputtedMeadows, bool inputtedLakes, bool inputtedWildlife, bool inputtedDogs)
    {
      List<Trail> filteredTrails = new List<Trail>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails WHERE difficulty = @difficulty AND distance = @distance AND waterfalls = @waterfalls AND summits = @summits AND streams = @streams AND mountainViews = @mountainViews AND meadows = @meadows AND lakes = @lakes AND wildlife = @wildlife AND dogs = @dogs;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@trailId";
      thisId.Value = this.GetId();
      cmd.Parameters.Add(thisId);

      MySqlParameter difficultyFilter = new MySqlParameter();
      difficultyFilter.ParameterName = "@difficulty";
      difficultyFilter.Value = inputtedDifficulty;
      cmd.Parameters.Add(difficultyFilter);

      MySqlParameter distanceFilter = new MySqlParameter();
      distanceFilter.ParameterName = "@distance";
      distanceFilter.Value = inputtedDistance;
      cmd.Parameters.Add(distanceFilter);

      MySqlParameter waterfallsFilter = new MySqlParameter();
      waterfallsFilter.ParameterName = "@waterfalls";
      waterfallsFilter.Value = inputtedWaterfalls;
      cmd.Parameters.Add(waterfallsFilter);

      MySqlParameter summitsFilter = new MySqlParameter();
      summitsFilter.ParameterName = "@summits";
      summitsFilter.Value = inputtedSummits;
      cmd.Parameters.Add(summitsFilter);

      MySqlParameter streamsFilter = new MySqlParameter();
      streamsFilter.ParameterName = "@streams";
      streamsFilter.Value = inputtedStreams;
      cmd.Parameters.Add(streamsFilter);

      MySqlParameter mountainFilter = new MySqlParameter();
      mountainFilter.ParameterName = "@mountainViews";
      mountainFilter.Value = inputtedMountainViews;
      cmd.Parameters.Add(mountainFilter);

      MySqlParameter meadowFilter = new MySqlParameter();
      meadowFilter.ParameterName = "@meadows";
      meadowFilter.Value = inputtedMeadows;
      cmd.Parameters.Add(meadowFilter);

      MySqlParameter lakeFilter = new MySqlParameter();
      lakeFilter.ParameterName = "@lakes";
      lakeFilter.Value = inputtedLakes;
      cmd.Parameters.Add(lakeFilter);

      MySqlParameter wildlifeFilter = new MySqlParameter();
      wildlifeFilter.ParameterName = "@wildlife";
      wildlifeFilter.Value = inputtedWildlife;
      cmd.Parameters.Add(wildlifeFilter);

      MySqlParameter wildlifeFilter = new MySqlParameter();
      dogsFilter.ParameterName = "@dogs";
      dogsFilter.Value = inputtedDogs;
      cmd.Parameters.Add(dogsFilter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int TrailId = rdr.GetInt32(0);
        string TrailName = rdr.GetString(1);
        int TrailDifficulty = rdr.GetInt32(2);
        float TrailDistance = rdr.GetFloat(3;
        bool TrailWaterfalls = rdr.GetBoolean(4);
        bool TrailSummits = rdr.GetInt32(5);
        bool TrailStreams = rdr.GetBoolean(6);
        bool trailMountainViews = rdr.GetBoolean(7);
        bool trailMeadows = rdr.GetBoolean(8);
        bool trailLakes = rdr.GetBoolean(9);
        bool TrailWildlife = rdr.GetBoolean(10);
        bool TrailDogs = rdr.GetBoolean(11);

        Trail newTrail = new Trail(TrailName, TrailDifficulty, TrailDistance, TrailWaterfalls, TrailSummits, trailStreams, trailMountainViews, trailMeadows, trailLakes, TrailWildlife, TrailDogs, TrailId);
        allTrails.Add(newTrail);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return filteredTrails;
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
        bool idEquality = this.GetId() == newTrail.GetId();
        bool nameEquality = this.GetName() == newTrail.GetName();
        bool difficultyEquality = this.GetDifficulty() == newTrail.GetDifficulty();
        bool distanceEquality = this.GetDistance() == newTrail.GetDistance();
        bool waterfallsEquality = this.GetWaterfalls() == newTrail.GetWaterfalls();
        bool summitsEquality = this.GetSummits() == newTrail.GetSummits();
        bool streamsEquality = this.GetSteams() == newTrail.GetSteams();
        bool mountainViewsEquality = this.GetMountainViews() == newTrail.GetMountainViews();
        bool meadowsEquality = this.GetMeadows() == newTrail.GetMeadows();
        bool lakesEquality = this.GetLakes() == newTrail.GetLakes();
        bool dogsEquality = this.GetDogs() == newTrail.GetDogs();
        return (idEquality && nameEquality && difficultyEquality && distanceEquality && waterfallsEquality && summitsEquality && streamsEquality && mountainViewsEquality && lakesEquality && meadowsEquality && dogsEquality);
      }
    }

    public static Trail Find(int trailId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails WHERE id = (@id);";
      MySqlParameter id = new MySqlParameter("@id", trailId);
      cmd.Parameters.Add(id);
      MySqlDataReader rdr = cmd .ExecuteReader() as MySqlDataReader;
      int readId = 0;
      string readName = "";
      int readDifficulty = 0;
      float readDistance = 0;
      int readSummits = 0;
      bool readWaterfalls = false;
      bool readStreams = false;
      bool readMountainViews = false;
      bool readMeadows = false;
      bool readLakes = false;
      bool readDogs = false;
      while(rdr.Read())
      {
        readId = rdr.GetInt32(0);
        readName = rdr.GetString(1);
        readDifficulty = rdr.GetInt32(2);
        readDistance = rdr.GetFloat(3);
        readSummits = rdr.GetBoolean(4);
        readWaterfalls = rdr.GetBoolean(5);
        readStreams = rdr.GetBoolean(6);
        readMountainViews = rdr.GetBoolean(7);
        readMeadows = rdr.GetBoolean(8);
        readLakes = rdr.GetBoolean(9);
        readDogs = rdr.GetBoolean(10);
      }
      Trail foundTrail = new Trail(readName, readDifficulty, readDistance, readSummits, readWaterfalls, readStreams, readMountainViews, readMountainViews, readMeadows, readLakes, readDogs, readId);
      return foundTrail;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM trails WHERE id = @trailsId; DELETE FROM users_trails WHERE trail_id = @trailId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@trailId";
      thisId.Value = this.GetId();
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
       conn.Close();
      }
    }

    public List<User> GetUsers()
    {
      List<User> allUsers = new List<User>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT users.* FROM trails
        JOIN users_trails ON (trails.id = users_trails.trail_id)
        JOIN users ON (users_trails.user_id = users.id)
        WHERE trails.id = @trailId;";
      MySqlParameter trailId = new MySqlParameter("@trailId", _id);
      cmd.Parameters.Add(trailId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int UserId = rdr.GetInt32(0);
        string UserUserName = rdr.GetString(1);
        string UserFirstName = rdr.GetString(2);
        string UserLastName = rdr.GetString(3);
        int UserZip = rdr.GetInt32(4);
        string UserPhone = rdr.GetString(5);
        string UserEmail = rdr.GetString(6);
        int UserGender = rdr.GetInt32(7);
        int UserCar = rdr.GetInt32(8);
        User newUser = new User(UserUserName, UserFirstName, UserLastName, UserZip, UserPhone, UserEmail, UserGender, UserCar, UserId);
        allUsers.Add(newUser);
      }
      conn.Close();
      if(conn != null)
      {
       conn.Dispose();
      }
      return allUsers;
    }

  }
}
