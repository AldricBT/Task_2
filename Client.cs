using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    /// <summary>
    /// Класс клиента для хранения его данных
    /// </summary>
    internal class Client
    {
        private string lastname;
        private string name;
        private string patronymic;
        private string phone;
        private string passport;

        public string Lastname
        {
            get { return this.lastname; }
            set { this.lastname = value; } 
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Patronymic
        {
            get { return this.patronymic; }
            set { this.patronymic = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public string Passport
        {
            get { return this.passport; }
            set { this.passport = value; }
        }

        public Client(string lastname, string name, string patronymic, string phone, string passport)
        {
            this.lastname = lastname;
            this.name = name;
            this.patronymic = patronymic;
            this.phone = phone;
            this.passport = passport;
        }
    }
}
