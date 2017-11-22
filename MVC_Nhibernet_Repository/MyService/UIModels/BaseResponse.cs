using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Nhibernet_Repository.Models
{
    public class BaseResponse
    {
        public bool Result { get; set; }
        public string ResultMessage { get; set; }      
    }
}