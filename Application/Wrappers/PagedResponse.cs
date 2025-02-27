using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PagedResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalRecords { get; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords) : base(data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }
    }


}
