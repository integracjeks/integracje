using Integracje.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Integracje.Helpers
{
    class JSONHelper
    {
        private const string fileName = "MOCK_DATA.json";
        public List<Book> BookList { get; private set; }

        public JSONHelper()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            string json = File.ReadAllText(path);
            BookList = JsonConvert.DeserializeObject<List<Book>>(json);
        }
    }
}
