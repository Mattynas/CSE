using System.Text.RegularExpressions;
using shopGuru_android.Exceptions.UserData;


namespace shopGuru_android.authenticator
{
    public class UserDataValidation
    {
        private static string _patternForEmail = @"^\w{ 0,20}$";
        private static string _patternForOthers = @"^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static void LoginValidation(string username, string password)
        {
            if (!Regex.IsMatch(username, _patternForOthers))
            {
                throw new InvalidUsernameException();
            }
            else if (!Regex.IsMatch(password, _patternForOthers))
            {
                throw new InvalidPasswordException();
            }
        }
        public static void RegisterValidation(string username, string email, string password, string confirmPassword)
        {
            if (!Regex.IsMatch(username, _patternForOthers))
            {
                throw new InvalidUsernameException();
            }
            else if (!Regex.IsMatch(email, _patternForEmail))
            {
                throw new InvalidEmailException();
            }
            else if (!Regex.IsMatch(password, _patternForOthers))
            {
                throw new InvalidPasswordException();
            }
            else if (password != confirmPassword)
            {
                throw new PasswordsDontMachException();
            }
        }
    }
}
