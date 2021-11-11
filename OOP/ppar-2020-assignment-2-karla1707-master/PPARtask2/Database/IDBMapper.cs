using System;
using System.Collections.Generic;
using Entity;

namespace backend.Database
{
    public interface IDBMapper
    {

        void AddUser(User u);
        List<User> GetAllUsers();
        User GetUserByLastname(String lastName);



    }
}
