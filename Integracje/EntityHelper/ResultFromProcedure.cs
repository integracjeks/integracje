using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityHelper
{
    public class ResultFromProcedure
    {
        public string Xml { get; set; }
        public bool WrongParameter { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public bool EmptyResult { get; set; }
    }
}
