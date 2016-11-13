using EntityHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://integracjeks.somee.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            var Procedure = new ObservableCollection<Procedure>
            {
                new Procedure {Name= "GetAllBooks",HasParameter=false},
                new Procedure {Name= "GetBookById",HasParameter=true,ParameterName="@id"},
                new Procedure {Name= "GetMostTranslatedBooks",HasParameter=false},
                new Procedure {Name= "GetOldestBookOrBooks",HasParameter=false},
                new Procedure {Name= "GetYoungestBookOrBooks",HasParameter=false},
                new Procedure {Name= "GetAllFactBasedBooks",HasParameter=false},
                new Procedure {Name= "GetAllNonFactBasedBooks",HasParameter=false},
                new Procedure {Name= "GetAllBooksInYear",HasParameter=true,ParameterName="@year"},
                new Procedure {Name= "GetAllBooksWrittenByMen",HasParameter=false},
                new Procedure {Name= "GetAllBooksWrittenByWomen",HasParameter=false}
            };

            var result = Procedure[1];
            result.Parameter = "5";

            var r=result.GetResult();


            return r.Xml;
        }
    }
}
