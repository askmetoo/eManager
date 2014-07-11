using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eManager.Web.DAL
{
    public class eManagerInitializer : System.Data.Entity.DropCreateDatabaseAlways<eManagerContext>
    {
        protected override void Seed(eManagerContext context)
        {
            var departments = new List<Department>
            {
                new Department() { Name = "Engineering", X = 20, Y = 30, Width = 120, Height = 60 },
                new Department() { Name = "Purchasing", X = 500, Y = 30, Width = 120, Height = 60 },
                new Department() { Name = "Sales", X = 100, Y = 400, Width = 120, Height = 60 },
                new Department() { Name = "Shipping", X = 500, Y = 300, Width = 120, Height = 60 },
                new Department() { Name = "Human Resource", X = 300, Y = 200, Width = 150, Height = 60 }
            };

            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { EmployeeID=10001, Name="Ahsan Aqeel", HireDate=DateTime.Parse("2010-01-02"),
                    DepartmentID = departments.Single(d => d.Name == "Engineering").Id },
                new Employee { EmployeeID=10002, Name="Ali Raza", HireDate=DateTime.Parse("2010-02-01"),
                    DepartmentID = departments.Single(d => d.Name == "Purchasing").Id },
                new Employee { EmployeeID=10003, Name="Mussab Vahedy", HireDate=DateTime.Parse("2012-03-05"),
                    DepartmentID = departments.Single(d => d.Name == "Engineering").Id },
                new Employee { EmployeeID=10004, Name="Nabeel Shawkat", HireDate=DateTime.Parse("2011-11-12"),
                    DepartmentID = departments.Single(d => d.Name == "Shipping").Id }
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var dependents = new List<Dependent>
            {
                new Dependent { Name = "Fahad Survar", Age=12, Relation=Constants.Relationship.Children,
                    EmployeeID = employees.SingleOrDefault(d => d.EmployeeID == 10002).EmployeeID
                },
                new Dependent { Name = "Sana Mukhtar", Age=30, Relation=Constants.Relationship.Spouce,
                    EmployeeID = employees.SingleOrDefault(d => d.EmployeeID == 10002).EmployeeID
                },
                new Dependent { Name = "Noama Khalid", Age=28, Relation=Constants.Relationship.Spouce,
                    EmployeeID = employees.SingleOrDefault(d => d.EmployeeID == 10001).EmployeeID
                },
                new Dependent { Name = "Atif Khan", Age=62, Relation=Constants.Relationship.Parents,
                    EmployeeID = employees.SingleOrDefault(d => d.EmployeeID == 10003).EmployeeID
                }
            };

            dependents.ForEach(s => context.Dependents.Add(s));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event { Title = "Safety Drill", StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1), IsActive = true
                },
                new Event { Title = "Security Awareness", StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2), IsActive = true
                },
                new Event { Title = "Executive Visit", StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(3), IsActive = true
                },
                new Event { Title = "Maintenance", StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(4), IsActive = true
                },
                new Event { Title = "Holidays", StartDate = DateTime.Now.AddDays(4),
                    EndDate = DateTime.Now.AddDays(5), IsActive = true
                }
            };

            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();
        }
    }
}