using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskSystem
{
    public interface EntityBase
    {
      int Id { get; set; }
    }
    public class UserTasks : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedBy { get; set; }
        public int AssignedTo { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CurrentStatus { get; set; }
        public int? SubOf { get; set; }
        public DateTime? CompletedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }

    public class ApplicationUsers : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
    }

}
