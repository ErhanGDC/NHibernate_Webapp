using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIService
{
    public class DeleteScientistRequest : BaseRequest
    {
        public int Id { get; set; }
    }
}