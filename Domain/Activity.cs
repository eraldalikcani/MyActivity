using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    //are going to set columns(id,title,date,descr,category,city,venue) in our database table called Activities
    //with entity framework(object relational map app)
    public class Activity
    {
        public Guid Id { get; set; } //must be named Id not any other name      // primary key 
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}