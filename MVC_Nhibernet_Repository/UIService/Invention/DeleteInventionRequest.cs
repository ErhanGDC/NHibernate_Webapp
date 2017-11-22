using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace UIService
{
    public class DeleteInventionRequest : BaseRequest
    {
        public int Id { get; set; }
    }
}
