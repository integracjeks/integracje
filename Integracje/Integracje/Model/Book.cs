using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracje.Model
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public int pages { get; set; }
        public int year { get; set; }
        public string isbn { get; set; }
        public string genre { get; set; }
        public string price { get; set; }
        public string authors_first_name { get; set; }
        public string authors_last_name { get; set; }
        public int fact_based { get; set; }
        public int toms_quantity { get; set; }
        public string authors_email { get; set; }
        public string authors_gender { get; set; }
        public string original_lanuguage { get; set; }
        public int translated_languages_quantity { get; set; }
    }
}
