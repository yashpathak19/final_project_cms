using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace FinalProject_n01364240
{
    public class PageController : PAGESDB
    {
        // this method will find the page record by giving an id to the method
        public Page FindPage(int id)
        {
            // initalizing the mysql connection
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            // initialzing the page record
            Page result_page = new Page();

            //running try catch for finding th student, to prevent errors.
            try
            {
                //getting the page record
                string query = "select * from pages where pageid = " + id;
                //writing to command line
                Debug.WriteLine("Connection Initialized...");
                //conncting to the database
                Connect.Open();
                //connecting the above query to mysql database
                MySqlCommand cmd = new MySqlCommand(query, Connect);

                //getting the result and setting it to resultset variable.
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Initializing the pages
                List<Page> pages = new List<Page>();

                //Reading the result set
                while (resultset.Read())
                {
                    // intializing the page record variable to store the data
                    Page page_record = new Page();

                    //iterating the resultset
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        if (resultset.IsDBNull(i)) continue;
                        string value = resultset.GetString(i);
                        // writing to the deubg log
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        // checking everything to against key, if it matches the key then setting to the page record.
                        if (key == "pagetitle")
                        {
                            page_record.SetPagetitle(value);
                        }
                        else if (key == "pagebody")
                        {
                            page_record.SetPagebody(value);
                        }
                        else if (key == "pagepublisheddate")
                        {
                            page_record.SetPagepublisheddate(DateTime.ParseExact(value, "yyyy-MM-dd hh:mm:ss tt", new CultureInfo("en-US")));
                        }
                        else if (key == "authorname")
                        {
                            page_record.SetAuthorname(value);
                        }

                    }
                    pages.Add(page_record);
                }

                result_page = pages[0];

            }
            catch (Exception ex)
            {
                //Writing to the debug line
                Debug.WriteLine("Something went wrong in the find Pages method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }

        public void AddPage(Page new_page)
        {
            // {} will take the values described after that in accordance of their position

            string query = "insert into pages (pagetitle, pagebody, pagepublisheddate, authorname) values ('{0}','{1}','{2}','{3}')";
            query = String.Format(query, new_page.GetPagetitle(), new_page.GetPagebody(), new_page.GetPagepublisheddate().ToString("yyyy-MM-dd"), new_page.GetAuthorname());

            // connecting to the mysql

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                // opening the connection
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // writing to the debug line
                Debug.WriteLine("Something went wrong in the AddPage Method!");
                Debug.WriteLine(ex.ToString());
            }
            // closing the connection
            Connect.Close();
        }


        public void UpdatePage(int pageid, Page updated_page)
        {
            // {} will take the values described after that in accordance of their position
            string query = "update pages set pagetitle='{0}', pagebody='{1}', authorname='{2}' where pageid={3}";
            query = String.Format(query, updated_page.GetPagetitle(), updated_page.GetPagebody(), updated_page.GetAuthorname(), pageid);

            // intializing the mysql connection
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                // opening the connection
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                // writing to the debug lines
                Debug.WriteLine("Something went wrong in the UpdatePages Method!");
                Debug.WriteLine(ex.ToString());
            }

            // closing the connection
            Connect.Close();
        }

        public void DeletePage(int pageid)
        {
            // {} will take the values described after that in accordance of their position
            string removepage = String.Format("delete from pages where pageid = {0}", pageid);

            // connecting to the mysql connection
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            // executing the query with the connection
            MySqlCommand cmd_removestudent = new MySqlCommand(removepage, Connect);
            try
            {
                // opening the connecton
                Connect.Open();
                cmd_removestudent.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removestudent);
            }
            catch (Exception ex)
            {
                // writing the debug lines
                Debug.WriteLine("Something went wrong in the delete Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            // closing the line
            Connect.Close();
        }
    }
}