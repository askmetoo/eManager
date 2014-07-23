﻿using System.Collections.Generic;

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