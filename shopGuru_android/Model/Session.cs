using System;

namespace shopGuru_android.Model
{
    public class Session
    {
        private static Session instance;

        //Statistics
        /*private double _spendings;
        private double _savings;
        private int _unique;*/

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        /*public double Spendings { get => _spendings; }
        public double Savings { get => _savings; }
        public int Unique { get => _unique;  }*/

        public static Session Instance()
        {
            if(instance == null)
            {
                instance = new Session();
            }
            return instance;
        }
        

        private Session() {}

    }
}