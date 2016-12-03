using Integracje.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Integracje.Helpers
{
    internal class JSONHelper
    {
        #region Fields

        private const string fileName = "MOCK_DATA.json";

        #endregion Fields

        #region Constructors

        public JSONHelper()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            string json = File.ReadAllText(path);
            BookList = JsonConvert.DeserializeObject<List<Book>>(json);
        }

        #endregion Constructors

        #region Properties

        public List<Book> BookList { get; private set; }

        #endregion Properties
    }
}