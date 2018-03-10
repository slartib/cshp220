using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
  class Program
  {
    static void Main(string[] args)
    {
      var users = new List<Models.User>();

      users.Add(new Models.User { Name = "Dave", Password = "hello" });
      users.Add(new Models.User { Name = "Steve", Password = "steve" });
      users.Add(new Models.User { Name = "Lisa", Password = "hello" });

      var helloPW = from user in users
      where user.Password == "hello"
      select user;

      foreach (var u in helloPW)
      {
        Console.WriteLine("Name: " + u.Name + "\tPassword: " + u.Password);
      }

      Console.WriteLine("First user with hello password, Name: " + helloPW.First().Name + "\tPassword: " + helloPW.First().Password);
      users.Remove(helloPW.FirstOrDefault());

      var lowerPW = from user in users
        where user.Password == user.Name.ToLower()
        select user;

      foreach (var u in lowerPW)
      {
        Console.WriteLine("Before password delete Name:" + u.Name + "\tPassword: " + u.Password);
        u.Password = "";
        Console.WriteLine("After password delete: " + u.Name + "\tPassword: " + u.Password);
      }

      var all_users = from user in users
        select user;

      foreach (var u in all_users)
      {
        Console.WriteLine("Name: " + u.Name + "\tPassword: " + u.Password);
      }
    }


  }
}
