using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Nhibernet_Repository.Models
{
    public class Scientist
    {
        public  int ID { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Title { get; set; }
    }
}