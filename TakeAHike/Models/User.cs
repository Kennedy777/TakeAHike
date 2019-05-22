using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TakeAHike.Models
{
  public class User
  {
    private string _userName;
    private string _firstName;
    private string _lastName;
    private int _zip;
    private string _phone;
    private string _email;
    private int _gender;
    private int _car;
    private int _id;

    public User(string userName, string firstName, string lastName, int zip, string phone, string email, int gender, int car, int id = 0)
    {
      _userName =userName;
      _firstName = firstName;
      _lastName = lastName;
      _zip = zip;
      _phone = phone;
      _email = email;
      _gender = gender;
      _car = car;
      _id = id;
    }

    public string GetUserName()
    {
      return _userName;
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
      cmd.CommandText = @"INSERT INTO users (user_name, first_name, last_name, zip, phone_number, email, gender, car) VALUES (@userUserName, @userFirstName, @userLastName, @userZip, @userPhone, @userEmail, @userGender, @userCar);";

      MySqlParameter userUserName = new MySqlParameter();
      userUserName.ParameterName = "@userUserName";
      userUserName.Value = this._userName;
      cmd.Parameters.Add(userUserName);

      MySqlParameter userFirstName = new MySqlParameter();
      userFirstName.ParameterName = "@userFirstName";
      userFirstName.Value = this._firstName;
      cmd.Parameters.Add(userFirstName);

      MySqlParameter userLastName = new MySqlParameter();
      userLastName.ParameterName = "@userLastName";
      userLastName.Value = this._lastName;
      cmd.Parameters.Add(userLastName);

      MySqlParameter userZip = new MySqlParameter();
      userZip.ParameterName = "@userZip";
      userZip.Value = this._zip;
      cmd.Parameters.Add(userZip);

      MySqlParameter userPhone= new MySqlParameter();
      userPhone.ParameterName = "@userPhone";
      userPhone.Value = this._phone;
      cmd.Parameters.Add(userPhone);

      MySqlParameter userEmail= new MySqlParameter();
      userEmail.ParameterName = "@userEmail";
      userEmail.Value = this._email;
      cmd.Parameters.Add(userEmail);

      MySqlParameter userGender = new MySqlParameter();
      userGender.ParameterName = "@userGender";
      userGender.Value = this._gender;
      cmd.Parameters.Add(userGender);

      MySqlParameter userCar = new MySqlParameter();
      userCar.ParameterName = "@userCar";
      userCar.Value = this._car;
      cmd.Parameters.Add(userCar);

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
      cmd.CommandText = @"DELETE FROM users;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if( conn != null )
      {
        conn.Dispose();
      }
    }

    public static List<User> GetAll()
    {
      List<User> allUsers = new List<User>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM users;";
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

    public static List<User> FilterUsers(int inputtedGender, int inputtedCar)
    {
      List<User> filteredUsers = new List<User>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM trails WHERE gender = @gender AND car = @car;";

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
        filteredUsers.Add(newUser);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return filteredUsers;
    }

    public override bool Equals(System.Object otherUser)
    {
      if(!(otherUser is User))
      {
        return false;
      }
      else
      {
        User newUser = (User) otherUser;
        bool idEquality = this.GetId() == newUser.GetId();
        bool userNameEquality = this.GetUserName() == newUser.GetUserName();
        bool firstNameEquality = this.GetFirstName() == newUser.GetFirstName();
        bool lastNameEquality = this.GetLastName() == newUser.GetLastName();
        bool zipEquality = this.GetZipCode() == newUser.GetZipCode();
        bool phoneEquality = this.GetPhone() == newUser.GetPhone();
        bool emailEquality = this.GetEmail() == newUser.GetEmail();
        bool genderEquality = this.GetGender() == newUser.GetGender();
        bool carEquality = this.GetCar() == newUser.GetCar();
        return (idEquality && userNameEquality && firstNameEquality && lastNameEquality && zipEquality && phoneEquality && emailEquality && genderEquality && carEquality);
      }
    }

    public static User Find(int userId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM users WHERE id = (@id);";
      MySqlParameter id = new MySqlParameter("@id", userId);
      cmd.Parameters.Add(id);
      MySqlDataReader rdr = cmd .ExecuteReader() as MySqlDataReader;
      int readId = 0;
      string readUserName = "";
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
        readUserName = rdr.GetString(1);
        readFirstName = rdr.GetString(2);
        readLastName = rdr.GetString(3);
        readZip = rdr.GetInt32(4);
        readPhone = rdr.GetString(5);
        readEmail = rdr.GetString(6);
        readGender = rdr.GetInt32(7);
        readCar = rdr.GetInt32(8);
      }
      User foundUser = new User(readUserName, readFirstName, readLastName, readZip, readPhone, readEmail, readGender, readCar, readId);
      return foundUser;
    }

    public void AddTrail(Trail newTrail)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users_trails (user_id, trail_id) VALUES (@userId, @trailId);";
      MySqlParameter trailId = new MySqlParameter();
      trailId.ParameterName = "@trailId";
      trailId.Value = newTrail.GetId();
      cmd.Parameters.Add(trailId);
      MySqlParameter userId = new MySqlParameter();
      userId.ParameterName = "@userId";
      userId.Value = this._id;
      cmd.Parameters.Add(userId);
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
      cmd.CommandText = @"SELECT trails.* FROM users
        JOIN users_trails ON (users.id = users_trails.user_id)
        JOIN trails ON (users_trails.trail_id = trails.id)
        WHERE users.id = @userId;";
      MySqlParameter userId = new MySqlParameter("@userId", _id);
      cmd.Parameters.Add(userId);
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
      cmd.CommandText = @"DELETE FROM users WHERE id = @userId; DELETE FROM users_trails WHERE user_id = @userId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@userId";
      thisId.Value = this.GetId();
      cmd.Parameters.Add(thisId);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
       conn.Close();
      }
    }


  }
}
