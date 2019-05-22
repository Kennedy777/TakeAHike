using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class Hiker
  {
    private string _hikerName;
    private string _firstName;
    private string _lastName;
    private int _zip;
    private string _phone;
    private string _email;
    private int _gender;
    private int _car;
    private int _id;

    public Hiker(string hikerName, string firstName, string lastName, int zip, string phone, string email, int gender, int car, int id = 0)
    {
      _hikerName =hikerName;
      _firstName = firstName;
      _lastName = lastName;
      _zip = zip;
      _phone = phone;
      _email = email;
      _gender = gender;
      _car = car;
      _id = id;
    }

    public string GetHikerName()
    {
      return _hikerName;
    }

    public string GetFirstName()
    {
      return _firstName;
    }

    public string GetLastName()
    {
      return _lastName;
    }

    public int GetZipCode()
    {
      return _zip;
    }

    public string GetPhone()
    {
      return _phone;
    }

    public string GetEmail()
    {
      return _email;
    }

    public int GetGender()
    {
      return _gender;
    }

    public int GetCar()
    {
      return _car;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO hikers (hiker_name, first_name, last_name, zip, phone_number, email, gender, car) VALUES (@hikerHikerName, @hikerFirstName, @hikerLastName, @hikerZip, @hikerPhone, @hikerEmail, @hikerGender, @hikerCar);";

      MySqlParameter hikerHikerName = new MySqlParameter();
      hikerHikerName.ParameterName = "@hikerHikerName";
      hikerHikerName.Value = this._hikerName;
      cmd.Parameters.Add(hikerHikerName);

      MySqlParameter hikerFirstName = new MySqlParameter();
      hikerFirstName.ParameterName = "@hikerFirstName";
      hikerFirstName.Value = this._firstName;
      cmd.Parameters.Add(hikerFirstName);

      MySqlParameter hikerLastName = new MySqlParameter();
      hikerLastName.ParameterName = "@hikerLastName";
      hikerLastName.Value = this._lastName;
      cmd.Parameters.Add(hikerLastName);

      MySqlParameter hikerZip = new MySqlParameter();
      hikerZip.ParameterName = "@hikerZip";
      hikerZip.Value = this._zip;
      cmd.Parameters.Add(hikerZip);

      MySqlParameter hikerPhone= new MySqlParameter();
      hikerPhone.ParameterName = "@hikerPhone";
      hikerPhone.Value = this._phone;
      cmd.Parameters.Add(hikerPhone);

      MySqlParameter hikerEmail= new MySqlParameter();
      hikerEmail.ParameterName = "@hikerEmail";
      hikerEmail.Value = this._email;
      cmd.Parameters.Add(hikerEmail);

      MySqlParameter hikerGender = new MySqlParameter();
      hikerGender.ParameterName = "@hikerGender";
      hikerGender.Value = this._gender;
      cmd.Parameters.Add(hikerGender);

      MySqlParameter hikerCar = new MySqlParameter();
      hikerCar.ParameterName = "@hikerCar";
      hikerCar.Value = this._car;
      cmd.Parameters.Add(hikerCar);

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
      cmd.CommandText = @"DELETE FROM hikers;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if( conn != null )
      {
        conn.Dispose();
      }
    }

    public static List<Hiker> GetAll()
    {
      List<Hiker> allHikers = new List<Hiker>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM hikers;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int HikerId = rdr.GetInt32(0);
        string HikerHikerName = rdr.GetString(1);
        string HikerFirstName = rdr.GetString(2);
        string HikerLastName = rdr.GetString(3);
        int HikerZip = rdr.GetInt32(4);
        string HikerPhone = rdr.GetString(5);
        string HikerEmail = rdr.GetString(6);
        int HikerGender = rdr.GetInt32(7);
        int HikerCar = rdr.GetInt32(8);
        Hiker newHiker = new Hiker(HikerHikerName, HikerFirstName, HikerLastName, HikerZip, HikerPhone, HikerEmail, HikerGender, HikerCar, HikerId);
        allHikers.Add(newHiker);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return allHikers;
    }

    public static List<Hiker> GetFiltered(int inputtedGender, int inputtedCar)
    {
      List<Hiker> filteredHikers = new List<Hiker>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM hikers WHERE gender = @gender AND car = @car;";

      MySqlParameter genderFilter = new MySqlParameter();
      genderFilter.ParameterName = "@gender";
      genderFilter.Value = inputtedGender;
      cmd.Parameters.Add(genderFilter);

      MySqlParameter carFilter = new MySqlParameter();
      carFilter.ParameterName = "@car";
      carFilter.Value = inputtedCar;
      cmd.Parameters.Add(carFilter);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int HikerId = rdr.GetInt32(0);
        string HikerHikerName = rdr.GetString(1);
        string HikerFirstName = rdr.GetString(2);
        string HikerLastName = rdr.GetString(3);
        int HikerZip = rdr.GetInt32(4);
        string HikerPhone = rdr.GetString(5);
        string HikerEmail = rdr.GetString(6);
        int HikerGender = rdr.GetInt32(7);
        int HikerCar = rdr.GetInt32(8);
        Hiker newHiker = new Hiker(HikerHikerName, HikerFirstName, HikerLastName, HikerZip, HikerPhone, HikerEmail, HikerGender, HikerCar, HikerId);
        filteredHikers.Add(newHiker);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return filteredHikers;
    }

    public override bool Equals(System.Object otherHiker)
    {
      if(!(otherHiker is Hiker))
      {
        return false;
      }
      else
      {
        Hiker newHiker = (Hiker) otherHiker;
        bool idEquality = this.GetId() == newHiker.GetId();
        bool hikerNameEquality = this.GetHikerName() == newHiker.GetHikerName();
        bool firstNameEquality = this.GetFirstName() == newHiker.GetFirstName();
        bool lastNameEquality = this.GetLastName() == newHiker.GetLastName();
        bool zipEquality = this.GetZipCode() == newHiker.GetZipCode();
        bool phoneEquality = this.GetPhone() == newHiker.GetPhone();
        bool emailEquality = this.GetEmail() == newHiker.GetEmail();
        bool genderEquality = this.GetGender() == newHiker.GetGender();
        bool carEquality = this.GetCar() == newHiker.GetCar();
        return (idEquality && hikerNameEquality && firstNameEquality && lastNameEquality && zipEquality && phoneEquality && emailEquality && genderEquality && carEquality);
      }
    }

    public static Hiker Find(int hikerId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM hikers WHERE id = (@id);";
      MySqlParameter id = new MySqlParameter("@id", hikerId);
      cmd.Parameters.Add(id);
      MySqlDataReader rdr = cmd .ExecuteReader() as MySqlDataReader;
      int readId = 0;
      string readHikerName = "";
      string readFirstName = "";
      string readLastName = "";
      int readZip = 0;
      string readPhone = "";
      string readEmail = "";
      int readGender = 0;
      int readCar = 0;
      while(rdr.Read())
      {
        readId = rdr.GetInt32(0);
        readHikerName = rdr.GetString(1);
        readFirstName = rdr.GetString(2);
        readLastName = rdr.GetString(3);
        readZip = rdr.GetInt32(4);
        readPhone = rdr.GetString(5);
        readEmail = rdr.GetString(6);
        readGender = rdr.GetInt32(7);
        readCar = rdr.GetInt32(8);
      }
      Hiker foundHiker = new Hiker(readHikerName, readFirstName, readLastName, readZip, readPhone, readEmail, readGender, readCar, readId);
      return foundHiker;
    }

    public void AddTrail(Trail newTrail)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO hikers_trails (hiker_id, trail_id) VALUES (@hikerId, @trailId);";
      MySqlParameter trailId = new MySqlParameter();
      trailId.ParameterName = "@trailId";
      trailId.Value = newTrail.GetId();
      cmd.Parameters.Add(trailId);
      MySqlParameter hikerId = new MySqlParameter();
      hikerId.ParameterName = "@hikerId";
      hikerId.Value = this._id;
      cmd.Parameters.Add(hikerId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public List<Trail> GetTrails()
    {
      List<Trail> allTrails = new List<Trail>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT trails.* FROM hikers
        JOIN hikers_trails ON (hikers.id = hikers_trails.hiker_id)
        JOIN trails ON (hikers_trails.trail_id = trails.id)
        WHERE hikers.id = @hikerId;";
      MySqlParameter hikerId = new MySqlParameter("@hikerId", _id);
      cmd.Parameters.Add(hikerId);
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

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM hikers WHERE id = @hikerId; DELETE FROM hikers_trails WHERE hiker_id = @hikerId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@hikerId";
      thisId.Value = this.GetId();
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
       conn.Close();
      }
    }

    public void Edit(string newHikerName, string newFirstName, string newLastName, int newZip, string newPhone, string newEmail, int newGender, int newCar)
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"UPDATE hikers SET hiker_name = @hikerHikerName WHERE id = @hikerId; UPDATE hikers SET first_name = @hikerFirstName WHERE id = @hikerId; UPDATE hikers SET last_name = @hikerLastName WHERE id = @hikerId; UPDATE hikers SET zip = @hikerZip WHERE id = @hikerId; UPDATE hikers SET phone_number = @hikerPhoneNumber WHERE id = @hikerId; UPDATE hikers SET email = @hikerEmail WHERE id = @hikerId; UPDATE hikers SET gender = @hikerGender WHERE id = @hikerId; UPDATE hikers SET car = @hikerCar WHERE id = @hikerId;";

    MySqlParameter hikerHikerNameParameter = new MySqlParameter();
    hikerHikerNameParameter.ParameterName = "@hikerHikerName";
    hikerHikerNameParameter.Value = newHikerName;
    cmd.Parameters.Add(hikerHikerNameParameter);

    MySqlParameter hikerFirstNameParameter = new MySqlParameter();
    hikerFirstNameParameter.ParameterName = "@hikerFirstName";
    hikerFirstNameParameter.Value = newFirstName;
    cmd.Parameters.Add(hikerFirstNameParameter);

    MySqlParameter hikerLastNameParameter = new MySqlParameter();
    hikerLastNameParameter.ParameterName = "@hikerLastName";
    hikerLastNameParameter.Value = newLastName;
    cmd.Parameters.Add(hikerLastNameParameter);

    MySqlParameter hikerZipParameter = new MySqlParameter();
    hikerZipParameter.ParameterName = "@hikerZip";
    hikerZipParameter.Value = newZip;
    cmd.Parameters.Add(hikerZipParameter);

    MySqlParameter hikerPhoneParameter = new MySqlParameter();
    hikerPhoneParameter.ParameterName = "@hikerPhoneNumber";
    hikerPhoneParameter.Value = newPhone;
    cmd.Parameters.Add(hikerPhoneParameter);

    MySqlParameter hikerEmailParameter = new MySqlParameter();
    hikerEmailParameter.ParameterName = "@hikerEmail";
    hikerEmailParameter.Value = newEmail;
    cmd.Parameters.Add(hikerEmailParameter);

    MySqlParameter hikerGenderParameter = new MySqlParameter();
    hikerGenderParameter.ParameterName = "@hikerGender";
    hikerGenderParameter.Value = newGender;
    cmd.Parameters.Add(hikerGenderParameter);

    MySqlParameter hikerCarParameter = new MySqlParameter();
    hikerCarParameter.ParameterName = "@hikerCar";
    hikerCarParameter.Value = newCar;
    cmd.Parameters.Add(hikerCarParameter);

    MySqlParameter hikerIdParameter = new MySqlParameter();
    hikerIdParameter.ParameterName = "@hikerId";
    hikerIdParameter.Value = this._id;
    cmd.Parameters.Add(hikerIdParameter);

    cmd.ExecuteNonQuery();
    _hikerName = newHikerName;
    _firstName = newFirstName;
    _lastName = newLastName;
    _zip = newZip;
    _phone = newPhone;
    _email = newEmail;
    _gender = newGender;
    _car = newCar;
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }


  }
}
