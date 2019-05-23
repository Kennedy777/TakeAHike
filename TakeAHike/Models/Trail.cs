using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class Trail
  {
    private string _name;
    private int _id;
    private int _difficulty;
    private int _summits;
    private bool _waterfalls;
    private bool _streams;
    private bool _mountainViews;
    private bool _meadows;
    private bool _lakes;
    private string _location;

    public Trail (string name, int difficulty, int summits, bool waterfalls, bool streams, bool mountainViews, bool meadows, bool lakes, string location, int id = 0)
    {
      _name = name;
      _id = id;
      _difficulty = difficulty;
      _waterfalls = waterfalls;
      _summits = summits;
      _streams = streams;
      _mountainViews = mountainViews;
      _meadows = meadows;
      _lakes = lakes;
      _location = location;
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
      return _mountainViews;
    }
    public bool GetMeadows()
    {
      return _meadows;
    }
    public bool GetLakes()
    {
      return _lakes;
    }

    public string GetLocation()
    {
      return _location;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO trails (name, difficulty, distance, summits, waterfalls, streams, mountain_views, meadows, lakes) VALUES (@trailName, @trailDifficulty, @trailDistance, @trailSummits, @trailWaterfalls, @trailStreams, @trailMountainViews, @trailMeadows, @trailLakes);";

      MySqlParameter trailName = new MySqlParameter();
      trailName.ParameterName = "@trailName";
      trailName.Value = this._name;
      cmd.Parameters.Add(trailName);

      MySqlParameter trailDifficulty = new MySqlParameter();
      trailDifficulty.ParameterName = "@trailDifficulty";
      trailDifficulty.Value = this._difficulty;
      cmd.Parameters.Add(trailDifficulty);

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

      MySqlParameter trailLocation = new MySqlParameter();
      trailLocation.ParameterName = "@trailLocation";
      trailLocation.Value = this._location;
      cmd.Parameters.Add(trailLocation);

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
        int TrailSummits = rdr.GetInt32(3);
        bool TrailWaterfalls = rdr.GetBoolean(4);
        bool TrailStreams = rdr.GetBoolean(5);
        bool TrailMountainViews = rdr.GetBoolean(6);
        bool TrailMeadows = rdr.GetBoolean(7);
        bool TrailLakes = rdr.GetBoolean(8);
        string TrailLocation = rdr.GetString(9);

        Trail newTrail = new Trail(TrailName, TrailDifficulty, TrailSummits, TrailWaterfalls, TrailStreams, TrailMountainViews, TrailMeadows, TrailLakes, TrailLocation, TrailId);
        allTrails.Add(newTrail);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allTrails;
    }

    public static List<Trail> GetMatches(int inputtedDifficulty, int inputtedSummits, bool inputtedWaterfalls, bool inputtedStreams, bool inputtedMountainViews, bool inputtedMeadows, bool inputtedLakes)
    {
      List<Trail> filteredTrails = new List<Trail>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails WHERE difficulty = @difficulty
      AND waterfalls = @waterfalls AND summits = @summits AND streams = @streams AND mountain_views = @mountainViews AND lakes = @lakes;";

      // OR waterfalls is NULL) AND (summits = @summits OR summits is NULL) AND (streams = @streams OR streams is NULL) AND (mountain_views = @mountainViews or mountain_views is NULL) AND (meadows = @meadows OR meadows is NULL) AND (lakes = @lakes OR lakes is NULL);";

      MySqlParameter difficultyFilter = new MySqlParameter();
      difficultyFilter.ParameterName = "@difficulty";
      difficultyFilter.Value = inputtedDifficulty;
      cmd.Parameters.Add(difficultyFilter);

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

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int TrailId = rdr.GetInt32(0);
        string TrailName = rdr.GetString(1);
        int TrailDifficulty = rdr.GetInt32(2);
        int TrailSummits = rdr.GetInt32(3);
        bool TrailWaterfalls = rdr.GetBoolean(4);
        bool TrailStreams = rdr.GetBoolean(5);
        bool TrailMountainViews = rdr.GetBoolean(6);
        bool TrailMeadows = rdr.GetBoolean(7);
        bool TrailLakes = rdr.GetBoolean(8);
        string TrailLocation = rdr.GetString(9);

        Trail newTrail = new Trail(TrailName, TrailDifficulty, TrailSummits, TrailWaterfalls, TrailStreams, TrailMountainViews, TrailMeadows, TrailLakes, TrailLocation, TrailId);
        filteredTrails.Add(newTrail);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return filteredTrails;
    }

    public static List<Trail> GetPartialMatches(int inputtedDifficulty, int inputtedSummits, bool inputtedWaterfalls, bool inputtedStreams, bool inputtedMountainViews, bool inputtedMeadows, bool inputtedLakes)
    {
      List<Trail> filteredTrails = new List<Trail>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails WHERE difficulty = @difficulty AND waterfalls = @waterfalls OR summits = @summits OR streams = @streams OR mountain_views = @mountainViews OR meadows = @meadows OR lakes = @lakes;";

      MySqlParameter difficultyFilter = new MySqlParameter();
      difficultyFilter.ParameterName = "@difficulty";
      difficultyFilter.Value = inputtedDifficulty;
      cmd.Parameters.Add(difficultyFilter);

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

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int TrailId = rdr.GetInt32(0);
        string TrailName = rdr.GetString(1);
        int TrailDifficulty = rdr.GetInt32(2);
        int TrailSummits = rdr.GetInt32(3);
        bool TrailWaterfalls = rdr.GetBoolean(4);
        bool TrailStreams = rdr.GetBoolean(5);
        bool TrailMountainViews = rdr.GetBoolean(6);
        bool TrailMeadows = rdr.GetBoolean(7);
        bool TrailLakes = rdr.GetBoolean(8);
        string TrailLocation = rdr.GetString(9);

        Trail newTrail = new Trail(TrailName, TrailDifficulty, TrailSummits, TrailWaterfalls, TrailStreams, TrailMountainViews, TrailMeadows, TrailLakes, TrailLocation, TrailId);
        filteredTrails.Add(newTrail);
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
        bool waterfallsEquality = this.GetWaterfalls() == newTrail.GetWaterfalls();
        bool summitsEquality = this.GetSummits() == newTrail.GetSummits();
        bool streamsEquality = this.GetStreams() == newTrail.GetStreams();
        bool mountainViewsEquality = this.GetMountainViews() == newTrail.GetMountainViews();
        bool meadowsEquality = this.GetMeadows() == newTrail.GetMeadows();
        bool lakesEquality = this.GetLakes() == newTrail.GetLakes();
        bool locationEquality = this.GetLocation() == newTrail.GetLocation();
        return (idEquality && nameEquality && difficultyEquality &&  waterfallsEquality && summitsEquality && streamsEquality && mountainViewsEquality && lakesEquality && meadowsEquality && locationEquality);
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
      int readSummits = 0;
      bool readWaterfalls = false;
      bool readStreams = false;
      bool readMountainViews = false;
      bool readMeadows = false;
      bool readLakes = false;
      string readLocation = "";
      while(rdr.Read())
      {
        readId = rdr.GetInt32(0);
        readName = rdr.GetString(1);
        readDifficulty = rdr.GetInt32(2);
        readSummits = rdr.GetInt32(3);
        readWaterfalls = rdr.GetBoolean(4);
        readStreams = rdr.GetBoolean(5);
        readMountainViews = rdr.GetBoolean(6);
        readMeadows = rdr.GetBoolean(7);
        readLakes = rdr.GetBoolean(8);
        readLocation = rdr.GetString(9);
      }
      Trail foundTrail = new Trail(readName, readDifficulty, readSummits, readWaterfalls, readStreams, readMountainViews, readMeadows, readLakes, readLocation, readId);
      return foundTrail;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM trails WHERE id = @trailsId; DELETE FROM hikers_trails WHERE trail_id = @trailId;";
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

    // public List<Hiker> GetHikers()
    // {
    //   List<Hiker> allHikers = new List<Hiker>();
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT hikers.* FROM trails
    //     JOIN hikers_trails ON (trails.id = hikers_trails.trail_id)
    //     JOIN hikers ON (hikers_trails.hiker_id = hikers.id)
    //     WHERE trails.id = @trailId;";
    //   MySqlParameter trailId = new MySqlParameter("@trailId", _id);
    //   cmd.Parameters.Add(trailId);
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     int HikerId = rdr.GetInt32(0);
    //     string HikerHikerName = rdr.GetString(1);
    //     string HikerFirstName = rdr.GetString(2);
    //     string HikerLastName = rdr.GetString(3);
    //     int HikerZip = rdr.GetInt32(4);
    //     string HikerPhone = rdr.GetString(5);
    //     string HikerEmail = rdr.GetString(6);
    //     int HikerGender = rdr.GetInt32(7);
    //     int HikerCar = rdr.GetInt32(8);
    //     Hiker newHiker = new Hiker(HikerHikerName, HikerFirstName, HikerLastName, HikerZip, HikerPhone, HikerEmail, HikerGender, HikerCar, HikerId);
    //     allHikers.Add(newHiker);
    //   }
    //   conn.Close();
    //   if(conn != null)
    //   {
    //    conn.Dispose();
    //   }
    //   return allHikers;
    // }

  }
}
