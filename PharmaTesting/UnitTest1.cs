using Castle.Core.Resource;
using onlinePharmacyApp.ETClasses;
using System.ComponentModel.DataAnnotations;

namespace PharmaTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AdminEmailIsRequired()
        {
            var admin = new Admin();
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void AdminEmailIsValid()
        {
            var Admin = new Admin { Email = "Invalid email" };
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(Admin, new ValidationContext(Admin), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void AdminPasswordRequired()
        {
            var admin = new Admin();
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }

        [Test]
        public void AdminNameIsRequired()
        {
            var admin = new Admin();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }

        [Test]
        public void CustomerEmailIsRequired()
        {
            var customer = new Customer();
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void CustomerEmailIsValid()
        {
            var customer = new Admin { Email = "Invalid email" };
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void CustomerPasswordRequired()
        {
            var customer = new Customer();
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }

        [Test]
        public void CustomerNameIsRequired()
        {
            var customer = new Customer();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }
        [Test]
        public void CustomerPhoneNoIsRequired()
        {
            var customer = new Customer();
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Phone Number"));
        }

        [Test]
        public void CustomerAddressIsRequired()
        {
            var customer = new Customer();
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, new ValidationContext(customer), validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Address"));
        }
    }
}