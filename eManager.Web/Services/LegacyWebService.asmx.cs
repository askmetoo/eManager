using eManager.Data;
using eManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;

namespace eManager.Web.Services
{
    /// <summary>
    /// Summary description for LegacyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LegacyWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public DepartmentDto HelloWorld()
        {
            //return "Hello World";
            DepartmentRepository repository = new DepartmentRepository(new eManagerContext());
            Department d = repository.FindAll().First();

            return new DepartmentDto()
            {
                Id = d.Id,
                Name = d.Name
            };
            //XmlDocument xm = new XmlDocument(); 
            //return xm.LoadXml(repository.FindAll().ToString());
        }
    }
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
