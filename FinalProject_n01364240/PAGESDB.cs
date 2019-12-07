using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace FinalProject_n01364240
{
    public class PAGESDB
    {
        // connecting to the database
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "cms"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3308"; } }

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        // this method will return list of dictionary with each dictionary contains the page record
        // this project has been made with the reference of https://github.com/christinebittle/crud_essentials
        // when - it was taken on 1st december
        // what - to understand the logic and use it to for my page cms
        // why - to get idea of a CMS application
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            //attempting to run the code in try & catch to avoid errors and catch them!
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);

                // Connecting to the database
                Connect.Open();

                //passing the query
                MySqlCommand cmd = new MySqlCommand(query, Connect);

                //setting the resultset variable
                MySqlDataReader resultset = cmd.ExecuteReader();


                //reading the resultset
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    //iterating to the resultset
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));
                    }

                    ResultSet.Add(Row);
                }
                resultset.Close(); // closing the resultset


            }
            catch (Exception ex)
            {
                // writing to the debug line
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            // closing the connection
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }
    }
}
