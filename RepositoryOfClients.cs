using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Win32;
using System.IO;

namespace Task_2
{
    internal class RepositoryOfClients
    {
        private string path;
        private List<Client> clients;

        public string Path
        { 
            get { return path; } 
            set {  path = value; } 
        }

        public List<Client> Clients
        {
            get { return clients; }
            set { clients = value; }
        }

        public RepositoryOfClients(string path)
        {
            this.path = path; 
            if (File.Exists(path)) 
            { 
                Load();
            }
            this.clients = new List<Client>();
        }

        /// <summary>
        /// Изменение данных клиента
        /// </summary>
        /// <param name="clientPresent">Клиент, данные которого нужно изменить</param>
        /// <param name="clientNew">Данные, на которые изменяются текущие</param>
        public void Edit(Client clientPresent, Client clientNew)
        {
            int index = clients.FindIndex(c => c == clientPresent);
            if (index != -1)
                clients[index] = clientNew;
        }

        /// <summary>
        /// Добавление клиента в базу (в памяти)
        /// </summary>
        /// <param name="client">экземпляр клиента</param>
        public void Add(Client client) 
        {
            clients.Add(client);
        }

        /// <summary>
        /// Сохранение базы из памяти в файл
        /// </summary>
        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(clients);
            File.WriteAllText(path, jsonString);
        }

        /// <summary>
        /// Загрузка базы из файла в память
        /// </summary>
        public void Load()
        {            
            string jsonString = File.ReadAllText(path);
            this.clients =  JsonSerializer.Deserialize<List<Client>>(jsonString);            
        }



    }
}
