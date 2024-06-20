using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Poeple
{
    public class Manager : StaffMember
    {
        private string _role;

        public Manager(int id, string firstname, int lastname, int age, string address, string email, string phonenumber, bool gender, string login, string password, double salary, string account, string role) : base(id, firstname, lastname, age, address, email, phonenumber, gender, login, password, salary, account)
        {
            Role = role;
        }

        public string Role
        {
            get 
            { 
                return _role; 
            }
            set
            {
                _role = value;
            }
        }
    }
}
