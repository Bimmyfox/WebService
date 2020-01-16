using TestTaskKolgatina.Models;
using System.Linq;

namespace TestTaskKolgatina.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any()) { return; }

            AddPassports(context);
            AddEmployees(context);
        }

        static void AddEmployees(EmployeeContext context)
        {
            var employees = new Employee[]
                {
                new Employee{Name="Carson",Surname="Alexander",Phone="290402349028784", CompanyId=123, PassportId = 1},
                new Employee{Name="Meredith",Surname="Alonso",Phone="19029382", CompanyId=1, PassportId = 2},
                new Employee{Name="Arturo",Surname="Anand",Phone="08937450", CompanyId=1, PassportId = 3},
                new Employee{Name="Gytis",Surname="Barzdukas",Phone="293478682", CompanyId=2, PassportId = 4},
                new Employee{Name="Yan",Surname="Li",Phone="79439852", CompanyId=2, PassportId = 5},
                new Employee{Name="Peggy",Surname="Justice",Phone="70198453", CompanyId=3, PassportId = 6},
                new Employee{Name="Laura",Surname="Norman",Phone="9823401", CompanyId=5, PassportId = 7},
                new Employee{Name="Nino",Surname="Olivetto",Phone="49375934", CompanyId=123, PassportId = 8}
                };
            foreach (Employee s in employees)
            {
                context.Employees.Add(s);
            }
            context.SaveChanges();
        }

        static void AddPassports(EmployeeContext context)
        {
            var passports = new Passport[]
           {
                new Passport{Type="rus", Number="25367172"},
                new Passport{Type="rus", Number="34534694"},
                new Passport{Type="international", Number="67409291231"},
                new Passport{Type="international", Number="09128465312"},
                new Passport{Type="rus", Number="92683487"},
                new Passport{Type="international", Number="04298623894"},
                new Passport{Type="international", Number="034982734"},
                new Passport{Type="international", Number="098464004"},
           };
            foreach (Passport c in passports)
            {
                context.Passports.Add(c);
            }
            context.SaveChanges();
        }
    }
}