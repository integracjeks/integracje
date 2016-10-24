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



        string createQuery = "CREATE TABLE[dbo].[Books]("+
            " [id] [int] NOT NULL, "+
            " [title] [varchar](250) NOT NULL,"+
            " [pages] [int] not null, "+
            " [year] [int] not null, "+
            " [isbn] [varchar](250) NOT NULL ," +
            " [genre] [varchar](250) NOT NULL ," +
            " [price] [varchar](250) NOT NULL ," +
            " [authors_first_name] [varchar](250) NOT NULL ," +
            " [authors_last_name] [varchar](250) NOT NULL ," +
            " [fact_based] [int] NOT NULL ," +
            " [toms_quantity] [int] NOT NULL ," +
            " [authors_email] [varchar](250) NOT NULL ," +
            " [authors_gender] [varchar](250) NOT NULL ," +
            " [original_lanuguage] [varchar](250) NOT NULL ," +
            " [translated_languages_quantity] [int] NOT NULL " +
            ")";

/*
 *      CREATE TABLE [dbo].[Tools]( [id][int] NOT NULL, [typ] [int] NOT NULL, [name] [varchar](255) NULL, [manufacturer] [varchar](255) NULL, [model] [varchar](255) NULL, [barcode] [varchar](255) NULL, [size] [int] NULL, [lower_band] [int] NULL, [upper_band] [int] NULL, [spec_size] [varchar](255) NULL, [spec_type] [varchar](255) NULL, [voltage_in_v] [int] NULL, [capacity] [int] NULL, [power_in_wat] [int] NULL, [update_date] [datetime] NULL )
 * 
 * 
        CREATE TABLE[dbo].[Tools]( [id]
        [int] NOT NULL, [typ] [int] NOT NULL, [name] [varchar](255) NULL, [manufacturer]
        [varchar](255) NULL,
	                                                    [model]
        [varchar](255) NULL, [barcode]
        [varchar](255) NULL, [size]
        [int] NULL, [lower_band]
        [int] NULL, [upper_band]
        [int] NULL,
                                                        [spec_size]
        [varchar](255) NULL, [spec_type]
        [varchar](255) NULL, [voltage_in_v]
        [int] NULL, [capacity]
        [int] NULL,
                                                        [power_in_wat]
        [int] NULL, [update_date]
        [datetime]
        NULL )
        
         */
    }
}
