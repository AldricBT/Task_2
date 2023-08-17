using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    interface IWorker
    {
        string Lastname { get; set; }
        string Name { get; set; }        
        string Patronymic { get; set; }
        string Phone { get; set; }   
        string Passport { get; set; }
        
    }
}
