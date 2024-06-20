using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Poeple
{
    public class Client : Person
    {
        private string _drivers_license;

        public Client(int id, string firstname, int lastname, int age, string address, string email, string phonenumber, bool gender, string drivers_license):base(id, firstname, lastname, age, address, email, phonenumber, gender)
        {
            Drivers_license = drivers_license;
        }

        public string Drivers_license
        {
            get
            {
                return _drivers_license;
            }
            set
            {
                _drivers_license = value;
            }
        }
    }
}
