using System;

namespace shopGuru_android.Model
{
    class Session
    {
        public static Lazy<Session> session = new Lazy<Session>();

        private string _username;
        private string _password;
        private string _email;
        private string _number;

        //Statistics
        /*private double _spendings;
        private double _savings;
        private int _unique;*/

        public string Username { get => _username; }
        public string Password { get => _password; }
        public string Email { get => _email; }
        public string Number { get => _number; }
        /*public double Spendings { get => _spendings; }
        public double Savings { get => _savings; }
        public int Unique { get => _unique;  }*/

        public Session(string username, string password, string email, string number)
        {
            _username = username;
            _password = password;
            _email = email;
            _number = number;
            //getStatisticsFromServers
        }

        ~Session()
        {
            //SendToServer
        }

    }
}