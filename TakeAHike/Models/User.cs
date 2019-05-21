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




  }
}
