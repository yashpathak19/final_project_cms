using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_n01364240
{
    public partial class WebsitePages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PAGESDB db = new PAGESDB();
            ListPages(db);
        }

        protected void ListPages(PAGESDB db)
        {
            string query = "select * from pages";
            List<Dictionary<String, String>> rs = db.List_Query(query);

            foreach (Dictionary<String, String> row in rs)
            {
                main_menu.InnerHtml += "<li><a href=\"ViewPage.aspx?pageid=" + row["pageid"] + "\">" + row["pagetitle"] + "</a></li>";
            }
        }
    }
}