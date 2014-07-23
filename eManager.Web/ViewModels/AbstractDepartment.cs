using System.ComponentModel.DataAnnotations;

namespace eManager.Web.ViewModels
{
    public abstract class AbstractDepartment
    {
        [Required]
        public string Name { get; set; }
    }
}