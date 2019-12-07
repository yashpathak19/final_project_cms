using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_n01364240
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //initializing the controller
                PageController controller = new PageController();

                //calling the view page method to get the page record
                ViewPage(controller);
            }
        }

        protected void ViewPage(PageController controller)
        {

            bool valid = true;

            //getting the pageid from the search query
            string pageid = Request.QueryString["pageid"];

            //checking if the pageid exists or not
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //page id exists so we can get the page record
            if (valid)
            {
                // calling the find page method to get the page record
                Page page_record = controller.FindPage(Int32.Parse(pageid));

                // setting the page data
                page_title.Text = page_record.GetPagetitle();
                page_body.Text = page_record.GetPagebody();
                author_name.Text = page_record.GetAuthorname();
            }

            // page is not valid so showing the error
            if (!valid)
            {
                edit_page.InnerHtml = "Oops, there was an error finding this page!";
            }
        }

        protected void UpdatePage(object sender, EventArgs e)
        {

            //initializing the controller
            PageController controller = new PageController();

            bool valid = true;

            //getting the page id from the search query
            string pageid = Request.QueryString["pageid"];

            //checking if the pageid exists in the url or not
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //pageid exists so we can get the page record
            if (valid)
            {
                //initializing the page object
                Page new_page = new Page();

                //setting the entered page data to existing page record
                new_page.SetPagetitle(page_title.Text);
                new_page.SetPagebody(page_body.Text);
                new_page.SetAuthorname(author_name.Text);

                try
                {
                    // calling the update page method to update the page record with changed page data
                    controller.UpdatePage(Int32.Parse(pageid), new_page);
                    // redirecting the page to view page 
                    Response.Redirect("ViewPage.aspx?pageid=" + pageid);
                }
                catch
                {
                    valid = false;
                }

            }

            // page id doesn't exist, so it means it's not present in url or user entered a wrong pageid or it has been deleted from db
            if (!valid)
            {
                edit_page.InnerHtml = "Oops, there was an error finding this page!";
            }

        }
    }
}