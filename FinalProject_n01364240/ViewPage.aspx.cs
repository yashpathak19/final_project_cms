using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_n01364240
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageController controller = new PageController();
            //getting the page details
            ViewPageDetails(controller);
        }

        protected void Delete_Page(object sender, EventArgs e)
        {
            // this method will delete the page 
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            PageController controller = new PageController();

            if (valid)
            {
                controller.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }

        protected void ViewPageDetails(PageController controller)
        {
            // this method will get the page id and get the record to view pages
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {

                Page page_record = controller.FindPage(Int32.Parse(pageid));


                page_title.InnerHtml = page_record.GetPagetitle();
                page_body.InnerHtml = page_record.GetPagebody();
                author_name.InnerHtml = page_record.GetAuthorname();
                page_published_date.InnerHtml = page_record.GetPagepublisheddate().ToString("yyyy-MM-dd");
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                page_detail.InnerHtml = "Oops, there was an error finding this page!";
            }
        }

    }
}