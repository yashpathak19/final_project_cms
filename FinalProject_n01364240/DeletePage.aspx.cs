using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_n01364240
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initializing the controller
            PageController controller = new PageController();
            //this will be called when page is loaded
            if (!Page.IsPostBack)
            {
                // calling the method view page to fetch the data
                ViewPage(controller);
            }
        }

        protected void ViewPage(PageController controller)
        {

            bool valid = true;
            
            // getting the page id from the url
            string pageid = Request.QueryString["pageid"];

            //if pageid doesnt exists it means we can not browse since setting the valid variable to false
            if (String.IsNullOrEmpty(pageid)) valid = false;

            // if page id exists its valid and we can browse
            if (valid)
            {
                // calling the method find page to get the record of the page
                Page page_record = controller.FindPage(Int32.Parse(pageid));

                // setting the page element with the data of page record
                page_title.InnerHtml = page_record.GetPagetitle();
                page_body.InnerHtml = page_record.GetPagebody();
                page_published_date.InnerHtml = page_record.GetPagepublisheddate().ToString("yyyy-MM-dd");
                author_name.InnerHtml = page_record.GetAuthorname();
            }
            else
            {
                valid = false;
            }

            // showing error as pageid doesn't exists in url
            if (!valid)
            {
                page_detail.InnerHtml = "Oops, there was an error finding this page!";
            }
        }

        protected void Remove_Page(object sender, EventArgs e)
        {
            //getting the pageid from the url
            string pageid = Request.QueryString["pageid"];

            // initializing the controller
            PageController controller = new PageController();

            //calling the controller method to delete the page
            controller.DeletePage(Int32.Parse(pageid));
            //redirecting the page to list pages
            Response.Redirect("ListPages.aspx");
        }

        protected void Cancel(object sender, EventArgs e)
        {
            // redirecting the page to page list
            Response.Redirect("ListPages.aspx");
        }

    }
}