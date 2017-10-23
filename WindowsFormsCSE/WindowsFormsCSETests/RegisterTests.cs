using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsCSE.Validation;
using WindowsFormsCSE.Exceptions.Register;


namespace WindowsFormsCSETests
{
    [TestClass]
    public class RegisterTests
    {
        [TestMethod]
        public void RegisterValidationTest()
        {
            String username = "labutis";
            String email = "mikimausas@gmail.com";
            String password = "123456";
            String confirmPassword = "123456";

            String wrongEmail = "blogasEmailas.com";
            String wrongConfirmPassword = "12556665";
            String wrongUsername = "labutis;;";


            Assert.IsTrue(RegisterDataValidation.RegisterValidation(username,email,password,confirmPassword));
           
            try
            {
                Assert.IsTrue(RegisterDataValidation.RegisterValidation(username, wrongEmail, password, confirmPassword));
            }
            catch(InvalidEmailException)
            {
                Console.WriteLine("Invalid Email Exception found");
            }

            try
            {
                Assert.IsTrue(RegisterDataValidation.RegisterValidation(username, email, password, wrongConfirmPassword));
            }
            catch(PasswordsDontMachException)
            {
                Console.WriteLine("Password do not match exception found");
            }

            try
            {
                Assert.IsTrue(RegisterDataValidation.RegisterValidation(wrongUsername, email, password, confirmPassword));
            }
            catch(InvalidUsernameException)
            {
                Console.WriteLine("Bad username exception found");
            }
        }
    }
}
