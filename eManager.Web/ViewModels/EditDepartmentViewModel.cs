using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.ViewModels
{
    public class EditDepartmentViewModel : AbstractDepartment
    {
        public int DepartmentID { get; set; }
        //public string CategoryCode { get; set; }
        //public SelectList Categories { get; set; }
        public byte[] RowVersion { get; set; }
    }
}