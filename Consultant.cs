using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Consultant : IWorker
    {

        private Client client;

        public Consultant(Client client)             
        {
            this.client = client;
        }


        public string Lastname
        {
            get { return client.Lastname; }
            set { }
        }

        public string Name
        {
            get { return client.Name; }
            set { }
        }

        public string Patronymic
        {
            get { return client.Patronymic; }
            set { }
        }

        public string Phone
        {
            get { return client.Phone; }
            set
            {
                if (Math.Floor(Math.Log10(Int64.Parse(value)) + 1) == 11) client.Phone = value;
            }
        }


        public string Passport
        {
            get
            {
                string stars = "";
                for (int i = 0; i < client.Passport.Length; i++)
                {
                    stars += "*";
                }
                return stars;
            }
            set { }
        }

        
    }
}
