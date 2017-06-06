using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskSystem
{
   
    public class UserTaskViewModel : UserTasks
    {
        public string AssignedToUsrName { get; set; }
        public string AssignedByUsrName { get; set; }
        public string ParentTaskName { get; set; }
    }
  

}
