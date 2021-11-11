using System;
using backend.Database;
using Entity;

namespace backend
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AbstractDBFactory dBFactory = AbstractDBFactory.CreateDBFactory();
//Console.WriteLine(dBFactory);
            IDBMapper dbMapper = dBFactory.CreateDBMapper();

           Student s = new Student();
            s.Class = "aaaa";
            Lecturer l = new Lecturer();
            dbMapper.AddUser(l);
           dbMapper.AddUser(s);
          dbMapper.GetAllUsers();
            Console.WriteLine(dbMapper.GetUserByLastname("cervar").ToString());
        }
    }
}
