using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcga.models
{
    public class PagerResult
    {
        public PagerResult()
        {
        }
        public PagerResult(int page = 1,int perPage = 10)
        {
            currentPage = page;
            recordPerPage = perPage;
        }

        public int currentPage { get; set; }
        public int recordPerPage { get; set; }
        public int totalRecords { get; set; }
        public int totalPages
        {
            get
            {
                if (recordPerPage <= 0)
                    return 0;
                return (int)Math.Ceiling((double)totalRecords / recordPerPage);
            }
        }

        public void setResult<T>(List<T> list)
        {
            if (currentPage > totalPages)
                currentPage = 1;
            data = list;
        }

        public IList data { get; set; }

        public int orderBy { get; set; }
        public string search { get; set; }
    }
}
