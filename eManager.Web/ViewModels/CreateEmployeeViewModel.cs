using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [HiddenInput(DisplayValue=false)]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
    }
}