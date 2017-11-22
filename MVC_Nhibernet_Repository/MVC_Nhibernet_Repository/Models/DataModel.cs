using MVC_Nhibernet_Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Nhibernet_Repository.Models
{
    public class DataModel
    {
        public List<Scientists> Scientists { get; set; }
        public List<Inventions> Invention { get; set; }
    }
}