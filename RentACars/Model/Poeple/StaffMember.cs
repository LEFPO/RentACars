using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Poeple
{
    public class StaffMember : Person
    {
        private string _login;
        private string _password;
        private double _salary;
        private string _account;

        public StaffMember (int id, string firstname, int lastname, int age, string address, string email, string phonenumber, bool gender, string login, string password, double salary, string account) : base(id, firstname, lastname, age, address, email, phonenumber, gender)
        {
            Login = login;
            Password = password;
            Salary = salary;
            Account = account;
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public double Salary
        {
            get
            {
                return _salary;
            }
            set 
            {                
                _salary = value;
            }
        }
        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
            }
        }
    }
}
