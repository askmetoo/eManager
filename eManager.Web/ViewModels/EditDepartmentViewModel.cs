
namespace eManager.Web.ViewModels
{
    public class EditDepartmentViewModel : AbstractDepartment
    {
        public int Id { get; set; }
        //public string CategoryCode { get; set; }
        //public SelectList Categories { get; set; }
        public byte[] RowVersion { get; set; }
    }
}