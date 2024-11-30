using PerondaApp.Entities;

namespace PerondaApp.Resources;

public class SampleEmployees
{
    public enum Position
    {
        machineOperator = 1,
        lineProduction = 2,
        technologist = 3,
        qualityController = 4,
        warehouseman = 5,
        printer = 6,
        commercialDirector = 7,
        tradeOffice = 8,
        accountant = 9
    }

    public static List<Employee> GenerateSampleEmployees()
    {
        return new List<Employee>
        {
            new Employee{
                FirstName = "PLANET", Surname = " Venus ",
                Position = "stoneware", Company = "matte",
            },
        };


        //var employees = new[]
        //{
        //    //new Employee { FirstName = "Dorota", Surname = "Fabis", Position = "seler" },
        //    //new Employee { FirstName = "Fabian", Surname = "Fabisiak", Position = "Cx machine operator" },
        //    //new Employee { FirstName = "Sebastian", Surname = "Borowy", Position = "Cxy machine operator" },
        //    //new Employee { FirstName = "Katarzyna", Surname = "Hirsz", Position = "technologist" },
        //    //new Employee { FirstName = "łukasz" , Surname = "Beryl", Position = "technologist" },
        //    //new Employee { FirstName = "Magda", Surname = "Zych", Position = "technologist" },
        //    //new Employee { FirstName = "Adam", Surname = "Nowicki", Position = "seler" },
        //    //new Employee { FirstName = "Piotr", Surname = "Krajewski", Position = "seler" },
        //    //new Employee { FirstName = "Przemysław" , Surname = "Zimoch", Position = "production line worker" },
        //    //new Employee { FirstName = "Fabian", Surname = "Daszyński", Position = "warehouseman" },
        //    new Employee { FirstName = "Tomasz", Surname = "Frątczak", Position = "factoryFX_box4_ production line" },
        //    //new Employee { FirstName = "Ricardo" , Surname = "Salvador", Position = "production line worker" },
        //    //new Employee { FirstName = "Eleanor", Surname = "Eden", Position = "seler" },
        //    //new Employee { FirstName = "Dominika", Surname = "Ziętek", Position = "designer" },
        //    //new Employee { FirstName = "Ala", Surname = "Abramczyk", Position = "commercial director" },
        //    //new Employee { FirstName = "Witold", Surname = "Ochocki", Position = "chief process technologist" },
        //    //new Employee { FirstName = "Marek", Surname = "Miętus", Position = "factoryFX_box1_ production line" },
        //};

        //static void AddBusinessPartners(IRepository<BusinessPartner> businessPartnerRepository)
        //{
        //    //*public string FullName => $" {FirstName} {Surname} ";
        //    //public override string ToString() => $" {GetType().Name}   ID: {Id}  {FullName} +   @ {Position} -- {Company}";
        //    string fullName =   FirstName  + Surname;
        //    string firstName;
        //    string surname;
        //    businessPartnerRepository.Add(new BusinessPartner { FullName => { "   Karol Cichocki" } });
        //    businessPartnerRepository.Add(new BusinessPartner { FirstName = "Opoczno" });
        //    businessPartnerRepository.Add(new BusinessPartner { FullName => ("Karol Szymczyk  ") }); //Manager'  "Opoczno" });
        //    //businessPartnerRepository.Add(new BusinessPartner { Name = "Nexterio" });
        //    //businessPartnerRepository.Add(new BusinessPartner { Name = "Leroy Marlin" });
        //    //businessPartnerRepository.Add(new BusinessPartner { Name = "Ceramika Końskie" });
        //    businessPartnerRepository.Save();
        //}

        //AddManyItems(_employeeRepository);
        //AddBusinessPartners(businessPartnersRepository); //źle tu wszystko
    }
}