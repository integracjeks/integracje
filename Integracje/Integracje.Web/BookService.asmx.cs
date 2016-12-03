using EntityHelper;
using Newtonsoft.Json;
using System;
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
        #region Methods

        [WebMethod]
        public string GetResultFromProcedure(EntityHelper.Procedure procedure)
        {
            ResultFromProcedure result;

            var logger = new Logger(HttpContext.Current.Request.UserHostAddress, DateTime.Now, procedure.Name);
            var actvitiesCount = logger.GetActivitiesCountOfLastTenMinutes();

            if (actvitiesCount == -1)
            {
                result = new ResultFromProcedure { HasError = true, ErrorMessage = "Blad podczas logowania" };
            }
            else if (actvitiesCount <= 3)
            {
                result = procedure.GetResult();
            }
            else
            {
                result = new ResultFromProcedure { HasError = true, ErrorMessage = "Przekroczyles ilosc zapytan" };
            }

            var resultJson = JsonConvert.SerializeObject(result);

            return resultJson;
        }

        #endregion Methods
    }
}