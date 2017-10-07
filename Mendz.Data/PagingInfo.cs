namespace Mendz.Data
{
    /// <summary>
    /// Represents paging information.
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Gets or sets the offset row number.
        /// </summary>
        public int OffsetRow { get; set; }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Gets or sets the number of total rows.
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Creates paging information.
        /// </summary>
        public PagingInfo()
        {
        }

        /// <summary>
        /// Creates paging information.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        public PagingInfo(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
