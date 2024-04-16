using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Model.Poeple
{
    public class Client
    {
        private string _firstname;
        private string _lastname;
        private string _adresse;
        private string _phonenumber;
        private int _age;

        public Client(string firstname, string lastname, string adresse, string phonenumber, int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Adresse = adresse;
            Phonenumber = phonenumber;
            Age = age;
        }

        private string Firstname { get { return _firstname; } set { _firstname = value; } }
        private string Lastname { get { return _lastname; } set { _lastname = value; } }
        private string Adresse { get { return _adresse; } set { _adresse = value; } }
        private string Phonenumber { get { return _phonenumber; } set { _phonenumber = value; } }
        private int Age { get { return _age; } set { _age = value; } }
    }
}
