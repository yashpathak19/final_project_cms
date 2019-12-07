using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_n01364240
{
    public class Page
    {
        // assigning the datatype of the fields
        private string Pagetitle;
        private string Pagebody;
        private DateTime Pagepublisheddate;
        private string Authorname;

        //getting the fields
        public string GetPagetitle()
        {
            return Pagetitle;
        }
        public string GetPagebody()
        {
            return Pagebody;
        }
        public DateTime GetPagepublisheddate()
        {
            return Pagepublisheddate;
        }
        public string GetAuthorname()
        {
            return Authorname;
        }

        //setting the fields
        public void SetPagetitle(string value)
        {
            Pagetitle = value;
        }
        public void SetPagebody(string value)
        {
            Pagebody = value;
        }
        public void SetPagepublisheddate(DateTime value)
        {
            Pagepublisheddate = value;
        }
        public void SetAuthorname(string value)
        {
            Authorname = value;
        }
    }
}