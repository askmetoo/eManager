using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eManager.Web.Models
{
    public static class Constants
    {
        public enum Relationship
        {
            Parents,
            Spouce,
            Children
        };

        public static Dictionary<string, string> DepartmentCategory = 
            new Dictionary<string, string>()
        {
            {"Infrastructure", "Infrastructure"},
            {"Commercial", "Commercial"},
            {"Functional", "Functional"},
        };
    }
}