using MVC_Nhibernet_Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Nhibernet_Repository.Models
{
    public class Invention
    {
        public  int InventionID { get; set; }
        public  string Description { get; set; }
        public  Scientists ScientistID { get; set; }
    }
}