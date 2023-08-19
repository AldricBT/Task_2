using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Task_3
{
    interface IWorker
    {
        string Lastname { get; set; }
        string Name { get; set; }        
        string Patronymic { get; set; }
        string Phone { get; set; }   
        string Passport { get; set; }
        DateTime EditTime { get; set; }
        string EditData { get; set; }
        string EditType { get; set; }
        string EditWho { get; set; }

    }
}
