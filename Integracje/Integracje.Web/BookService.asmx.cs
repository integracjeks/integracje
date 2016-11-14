using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Integracje.Web
{
    /// <summary>
    /// Summary description for BookService
    /// </summary>
    [WebService(Namespace = "http://integracjeks.somee.com/BookService.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetResultFromProcedure(EntityHelper.Procedure procedure)
        {
            var info = HttpContext.Current.Request.UserHostAddress;//  Current.Request.UserHostAddress 

            var result = procedure.GetResult();

            var resultJson = JsonConvert.SerializeObject(result);

            return resultJson;
        }
    }
}
