using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMMapiTest1.Models;

namespace TMMapiTest1.Model
{
    public class ResponseUsers
    {
        public ResponseUsers(Users users)
        {
            id = users.Id;
            login = users.Login;
            password = users.Password;
            newMessagesCount = users.NewMessagesCount;
            friendsCount = users.FriendsCount;
            status = users.Status;
        }
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int? newMessagesCount { get; set; }
        public int? friendsCount { get; set; }
        public string status { get; set; }
    }
}