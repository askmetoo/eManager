using System.Web.Mvc;

namespace eManager.Web.Models
{
    public class Service
    {
        public virtual int Id { get; set; }
        public virtual string Header { get; set; }
        public virtual string Title { get; set; }
        [AllowHtml]
        public virtual string Description { get; set; }
    }
}
