using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace EntityHelper
{
    public class Procedure
    {
        #region Properties

        public bool HasParameter { get; set; }
        public string Name { get; set; }
        public string Parameter { get; set; }
        public string ParameterName { get; set; }

        #endregion Properties

        #region Methods

        public XmlDocument GetEntityXml<T>(List<Book> result)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XPathNavigator nav = xmlDoc.CreateNavigator();
            using (XmlWriter writer = nav.AppendChild())
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Books"));
                ser.Serialize(writer, result);
            }
            return xmlDoc;
        }

        public ResultFromProcedure GetResult()
        {
            using (var db = new BookContext())
            {
                try
                {
                    List<Book> result;
                    if (HasParameter)
                    {
                        int param;
                        if (!int.TryParse(Parameter, out param))
                        {
                            return new ResultFromProcedure { HasError = true, WrongParameter = true };
                        }
                        try
                        {
                            result = db.Database
                           .SqlQuery<Book>(Name + " " + ParameterName, new SqlParameter(ParameterName, param))
                           .ToList();
                        }
                        catch (Exception e)
                        {
                            return new ResultFromProcedure { HasError = true, ErrorMessage = e.Message };
                        }
                    }
                    else
                    {
                        try
                        {
                            result = db.Database
                           .SqlQuery<Book>(Name)
                           .ToList();
                        }
                        catch (Exception e)
                        {
                            return new ResultFromProcedure { HasError = true, ErrorMessage = e.Message };
                        }
                    }

                    if (result.Count <= 0)
                    {
                        return new ResultFromProcedure { HasError = false, EmptyResult = true };
                    }
                    var xml = GetEntityXml<Book>(result);
                    return new ResultFromProcedure { HasError = false, Xml = xml.InnerXml };
                }
                catch (Exception e)
                {
                    return new ResultFromProcedure { HasError = true, ErrorMessage = e.Message };
                }
            }
        }

        #endregion Methods
    }
}