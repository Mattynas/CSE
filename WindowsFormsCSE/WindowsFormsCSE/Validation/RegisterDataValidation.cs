using System.Text.RegularExpressions;
using WindowsFormsCSE.Exceptions.Register;
using WindowsFormsCSE.Properties;

namespace WindowsFormsCSE.Validation
{
    public class RegisterDataValidation
    {
        public static bool RegisterValidation(string username, string email, string password, string confirmPassword)
        {
            var patternForEmail = Resources.REGISTRATION_emailPattern;
            var patternForOthers = Resources.REGISTRATION_passwordPattern;

            if (!Regex.IsMatch(username, patternForOthers))
            {
                throw new InvalidUsernameException();
            }
            else if (!Regex.IsMatch(email, patternForEmail))
            {
                throw new InvalidEmailException();
            }
            else if (!Regex.IsMatch(password, patternForOthers))
            {
                throw new InvalidPasswordException();
            }
            else if (password != confirmPassword)
            {
                throw new PasswordsDontMachException();
            }
            return true;
        }
    }
}
