using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACars.Poeple
{
    public class Person
    {
        private int _id;
        private string _firstname;
        private int _lastname;
        private int _age;
        private string _address;
        private string _email;
        private string _phonenumber;
        private bool _gender;

        public Person(int id, string firstname, int lastname, int age, string address, string email, string phonenumber, bool gender)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Address = address;
            Email = email;
            Phonenumber = phonenumber;
            Gender = gender;
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Phonenumber
        {
            get
            {
                return _phonenumber;
            }
            set
            {
                _phonenumber = value;
            }
        }
        public bool Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }
        public int Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
    }
}
