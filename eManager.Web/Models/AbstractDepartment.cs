﻿using eManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Models
{
    public abstract class AbstractDepartment
    {
        [Required]
        public string Name { get; set; }
    }
}