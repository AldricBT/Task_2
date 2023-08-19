using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
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
                if ((!string.IsNullOrEmpty(value))&&(Math.Floor(Math.Log10(Int64.Parse(value)) + 1) == 11))
                    client.Phone = value;
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

        public DateTime EditTime
        { 
            get { return client.EditTime; }
            set { client.EditTime = DateTime.Now; } 
        }

        public string EditData
        {
            get { return client.EditData; }
            set { client.EditData = value; }
        }

        public string EditType
        {
            get { return client.EditType; }
            set { client.EditType = value; }
        }

        public string EditWho
        {
            get { return client.EditWho; }
            set {  client.EditWho = value; }
        }
        
    }
}
