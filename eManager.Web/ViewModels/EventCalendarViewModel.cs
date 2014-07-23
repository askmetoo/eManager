
namespace eManager.Web.ViewModels
{
    public class EventCalendarViewModel
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsEditable { get; set; }
    }
}