namespace onlinePharmacyApp.Migrations
{
    using onlinePharmacyApp.ETClasses;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<onlinePharmacyApp.Data.PharmaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(onlinePharmacyApp.Data.PharmaDbContext context)
        {
            context.Admin.Add(new Admin { Name = "admin", Email = "admin@pharma.com", Password = "Admin@123" });

            context.Customers.Add(new Customer { Email = "narendra123@gmail.com", Password = "Narendra@123", Name = "Narendra", Phone = "8234567890", Address = "Nalgonda" });
            context.Customers.Add(new Customer { Email = "moses123@gmail.com", Password = "Moses@123", Name = "Naveen Moses", Phone = "8234567891", Address = "Vizag" });
            context.Customers.Add(new Customer { Email = "jonsai123@gmail.com", Password = "JonSai@123", Name = "JonSai", Phone = "7234567892", Address = "Thadepalli" });
            context.Customers.Add(new Customer { Email = "glory123@gmail.com", Password = "Glory@123", Name = "Priscilla Glory", Phone = "9234567893", Address = "Warangal" });
            context.Customers.Add(new Customer { Email = "narasimha123@gmail.com", Password = "Narasimha@123", Name = "Narasimha", Phone = "7234567894", Address = "Kadapa" });
            context.Customers.Add(new Customer { Email = "bhavana123@gmail.com", Password = "Bhavana@123", Name = "Bhavana Ramya", Phone = "8234567895", Address = "Khammam" });
            context.Customers.Add(new Customer { Email = "vidhya123@gmail.com", Password = "Vidhya@123", Name = "Vidhya Latha", Phone = "6234567896", Address = "Ongole" });


            context.Medicines.Add(new Medicine { MName = "Aspirin", stock = 110, Price = 60, Discount = 5, MType = "Pain killer" });
            context.Medicines.Add(new Medicine { MName = "Feveron", stock = 220, Price = 18, Discount = 5, MType = "Pain killer" });
            context.Medicines.Add(new Medicine { MName = "Naproxen", stock = 152, Price = 25, Discount = 5, MType = "Pain killer" });
            context.Medicines.Add(new Medicine { MName = "Dolo 650", stock = 355, Price = 40, Discount = 5, MType = "Fever" });
            context.Medicines.Add(new Medicine { MName = "Dart", stock = 155, Price = 43, Discount = 5, MType = "Fever" });
            context.Medicines.Add(new Medicine { MName = "Formost 400", stock = 215, Price = 250, Discount = 5, MType = "Asthma" });
            context.Medicines.Add(new Medicine { MName = "Aspirinol", stock = 160, Price = 45, Discount = 5, MType = "Headache" });
            context.Medicines.Add(new Medicine { MName = "Saridon", stock = 325, Price = 50, Discount = 5, MType = "Headache" });
            context.Medicines.Add(new Medicine { MName = "Paracetamol", stock = 255, Price = 10, Discount = 5, MType = "Cold" });
            context.Medicines.Add(new Medicine { MName = "Cetirizine", stock = 410, Price = 20, Discount = 5, MType = "Cold" });
            context.Medicines.Add(new Medicine { MName = "Vicks Inhaler", stock = 95, Price = 60, Discount = 5, MType = "Cold" });
            context.Medicines.Add(new Medicine { MName = "Montair LC", stock = 110, Price = 220, Discount = 5, MType = "Allergy" });
            context.Medicines.Add(new Medicine { MName = "Levocis", stock = 90, Price = 82, Discount = 5, MType = "Allergy" });

        }
    }
}
