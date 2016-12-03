using Integracje.Model;
using System;
using System.Data.SqlClient;

namespace Integracje.Helpers
{
    public class SQLHelper
    {
        #region Fields

        private const string CONNECTION_STIRNG = "Server=689d6cf8-4bc2-4070-80e2-a6a9012752a8.sqlserver.sequelizer.com;Database=db689d6cf84bc2407080e2a6a9012752a8;User ID=wrntvhhakanzejdt;Password=kXZEpF5EXMvQ4gAfadiPii2YqGY8WWb22PAbFWQuUa6n4JgsFy5goBKb5apPP5Rb;";

        private const string createQuery = "CREATE TABLE[dbo].[Books](" +
            " [id] [int] NOT NULL, " +
            " [title] [varchar](250) NOT NULL," +
            " [pages] [int] not null, " +
            " [year] [int] not null, " +
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

        private const string insertQuery = "INSERT INTO [dbo].[Books]([id] ,[title] ,[pages] ,[year],[isbn],[genre] ,[price],[authors_first_name] ,[authors_last_name],[fact_based],[toms_quantity],[authors_email],[authors_gender],[original_lanuguage],[translated_languages_quantity])" +
            "VALUES( {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})";

        #endregion Fields

        #region Constructors

        public SQLHelper()
        {
        }

        #endregion Constructors

        #region Properties

        public SqlConnection Connection { get; set; }

        #endregion Properties

        #region Methods

        public void CreateDatabase()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STIRNG))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(createQuery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                }
            }
        }

        public void InsertIntem(Book item)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    Console.WriteLine("insert id: " + item.id);

                    connection.Open();
                    SqlCommand cmd = new SqlCommand(string.Format(insertQuery,
                        item.id,
                        "'" + item.title + "'",
                        item.pages,
                        item.year,
                        "'" + item.isbn + "'",
                        "'" + item.genre + "'",
                        "'" + item.price + "'",
                        "'" + item.authors_first_name + "'",
                        "'" + item.authors_last_name + "'",
                        item.fact_based,
                        item.toms_quantity,
                        "'" + item.authors_email + "'",
                        "'" + item.authors_gender + "'",
                        "'" + item.original_lanuguage + "'",
                        item.translated_languages_quantity), connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                }
            }
        }

        public void InsertTest()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STIRNG))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(string.Format(insertQuery, 1, "'title'", 324, 234, "'isbnumer'", "'genre'", "'$50'", "'imieautora'",
                    "'nazwiskoautroa'", 1, 4, "'mail'", "'hender'", "'en'", 5), conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            /*
          (<id, int,>
           ,<title, varchar(250),>
           ,<pages, int,>
           ,<year, int,>
           ,<isbn, varchar(250),>
           ,<genre, varchar(250),>
           ,<price, varchar(250),>
           ,<authors_first_name, varchar(250),>
           ,<authors_last_name, varchar(250),>
           ,<fact_based, int,>
           ,<toms_quantity, int,>
           ,<authors_email, varchar(250),>
           ,<authors_gender, varchar(250),>
           ,<original_lanuguage, varchar(250),>
           ,<translated_languages_quantity, int,>)
         */
        }

        public object SqlReturn(string sql)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STIRNG))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                return result;
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(CONNECTION_STIRNG);
        }

        #endregion Methods
    }
}