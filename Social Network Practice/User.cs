using System;
using System.Text.RegularExpressions;

namespace User
{
    using DataBase;

    class User
    {
        public int Id { get; set; }
        private string _name;
        private string _surname;
        private int _age;
        private string _email;
        private string _hashedPassword;

        public User(in string name, in string surname, in int age, in string email, in string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            HashedPassword = password;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if ((!Regex.IsMatch(value, @"^[\p{L}]+$")) || value == null)
                    throw new InvalidOperationException("Name must contain only letters");

                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if ((!Regex.IsMatch(value, @"^[\p{L}]+$")) || value == null)
                    throw new InvalidOperationException("Surname must contain only letters");

                _surname = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            private set
            {
                if (value < 18 || value > 99)
                    throw new InvalidOperationException("Age must be more than 17 and less than 99.");

                _age = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                if (!Verify.MailHelper.IsValidEmail(value))
                    throw new InvalidOperationException("Mail format is not correct");

                DataBase.AddMail(value);
                _email = value;
            }
        }
        public string HashedPassword
        {
            get
            {
                return _hashedPassword;
            }
            private set
            {                                
                if (String.IsNullOrWhiteSpace(value) || value?.Length < 8)
                    throw new InvalidOperationException("Password must be more than 7 characters.");

                _hashedPassword = value.GetHashCode().ToString();
            }
        }                
    }
}
