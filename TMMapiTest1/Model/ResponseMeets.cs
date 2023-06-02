using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMMapiTest1.Models;

namespace TMMapiTest1.Model
{
    public class ResponseMeets
    {
        public ResponseMeets(Meets meets)
        {
            id = meets.Id;
            name = meets.Name;
            meetDateTime = meets.MeetDateTime;
            eventt = meets.Event;
            adress = meets.Adress;
            userId = meets.OwnerId;
            peopleNumber = meets.PeopleNumber;
            comment = meets.Comment;
        }
        public int id { get; set; }
        public string name { get; set; }
        public DateTime meetDateTime { get; set; }
        public string eventt { get; set; }
        public string adress { get; set; }
        public int userId { get; set; }
        public decimal peopleNumber { get; set; }
        public string comment { get; set; }
    }
}