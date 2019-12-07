using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_n01364240
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Page(object sender, EventArgs e)
        {

            //Initiating the connection to controller
            PageController db = new PageController();

            //Creating a new page record
            Page new_page = new Page();

            //Setting the Page data
            new_page.SetPagetitle(page_title.Text);
            new_page.SetPagebody(page_body.Text);
            new_page.SetAuthorname(author_name.Text);

            //Addding the page to database
            db.AddPage(new_page);

            //after the adding redirecting the page to Page List
            Response.Redirect("ListPages.aspx");
        }
    }
}
