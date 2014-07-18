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
                new Employee { Id=10001, Name="Ahsan Aqeel", HireDate=DateTime.Parse("2010-01-02"),
                    DepartmentID = departments.Single(d => d.Name == "Engineering").Id },
                new Employee { Id=10002, Name="Ali Raza", HireDate=DateTime.Parse("2010-02-01"),
                    DepartmentID = departments.Single(d => d.Name == "Purchasing").Id },
                new Employee { Id=10003, Name="Mussab Vahedy", HireDate=DateTime.Parse("2012-03-05"),
                    DepartmentID = departments.Single(d => d.Name == "Engineering").Id },
                new Employee { Id=10004, Name="Nabeel Shawkat", HireDate=DateTime.Parse("2011-11-12"),
                    DepartmentID = departments.Single(d => d.Name == "Shipping").Id }
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var dependents = new List<Dependent>
            {
                new Dependent { Name = "Fahad Survar", Age=12, Relation=Constants.Relationship.Children,
                    EmployeeID = employees.SingleOrDefault(d => d.Id == 10002).Id
                },
                new Dependent { Name = "Sana Mukhtar", Age=30, Relation=Constants.Relationship.Spouce,
                    EmployeeID = employees.SingleOrDefault(d => d.Id == 10002).Id
                },
                new Dependent { Name = "Noama Khalid", Age=28, Relation=Constants.Relationship.Spouce,
                    EmployeeID = employees.SingleOrDefault(d => d.Id == 10001).Id
                },
                new Dependent { Name = "Atif Khan", Age=62, Relation=Constants.Relationship.Parents,
                    EmployeeID = employees.SingleOrDefault(d => d.Id == 10003).Id
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

            var services = new List<Service>
            {
                new Service { Header = "Construction", Title = "Maintenance & Construction Services",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor." +
                        "Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec " +
                        "quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede " +
                        "justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis " +
                        "vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt."
                },
                new Service { Header = "Marketing", Title = "Marketing Strategies & Ideas For Your Business",
                    Description = " Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus " +
                        "quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. " +
                        "Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas " +
                        "tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. In enim " +
                        "justo semulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. "
                },
                new Service { Header = "Recruitment", Title = "Human Resources: Recruitment & Selection Hiring Services",
                    Description = "Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt " +
                        "tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus " +
                        "tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget " +
                        "bibendum sodales, augue velit cursus nunc. eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat " +
                        "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim."
                }
                              
            };

            services.ForEach(s => context.Services.Add(s));
            context.SaveChanges();
        }
    }
}