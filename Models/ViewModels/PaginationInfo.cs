namespace Amazon.Models.ViewModels
{
    public class PaginationInfo
    {
        public int tItems {  get; set; }
        public int iPerPage { get; set; }
        public int curPage { get; set; }
        public int tNumPages => (int)(Math.Ceiling((decimal)tItems/iPerPage));
    }
}
