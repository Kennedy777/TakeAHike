using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class User
  {
    private string _name;
    private string _gender;
    private int _id;

    public User (string name, string gender, int id = 0)
    {
      _name = name;
      _gender = gender;
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

    public string GetGender()
    {
      return _gender;
    }
    public void SetGender(string newGender)
    {
      _gender = newGender;
    }

    public int GetId()
    {
      return _id;
    }

  }
}
