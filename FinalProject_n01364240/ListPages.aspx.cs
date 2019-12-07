using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_n01364240
{
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //initializing the page_result element
            pages_result.InnerHtml = "";

            string search_string = "";

            // when the user clicks on the search button, it catches that.
            if (Page.IsPostBack)
            {
                //getting the user's entered string
                search_string = page_search.Text;
            }

            string query = "select * from pages";

            if (search_string != "")
            {
                // searching for the user's entered page title
                query += " WHERE pagetitle like '%" + search_string + "%' ";
            }

            // initializing the db object
            var db = new PAGESDB();
            // calling the list query method to get results in list of dictionary
            // every dictionary contains page record
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                // setting page records on page elements
                string page_id = row["pageid"];
                pages_result.InnerHtml += "<div class=\"listitem\">";

                pages_result.InnerHtml += "<div class=\"col5\"><a href=\"ViewPage.aspx?pageid=" + page_id + "\">" + row["pagetitle"] + "</a></div>";

                pages_result.InnerHtml += "<div class=\"col5\">" + row["authorname"] + "</div>";

                pages_result.InnerHtml += "<div class=\"col5\">" + row["pagepublisheddate"] + "</div>";

                pages_result.InnerHtml += "<div class=\"col5\"><a href=\"EditPage.aspx?pageid=" + page_id + "\">" + "<button class=\"edit_button\" type=\"button\">Edit</button></a></div>";
                pages_result.InnerHtml += "<div class=\"col5last\"><a href=\"DeletePage.aspx?pageid=" + page_id + "\"> <button class=\"delete_button\" type=\"button\">Delete</button></a></div>";

                pages_result.InnerHtml += "</div>";
            }
        }
    }
}