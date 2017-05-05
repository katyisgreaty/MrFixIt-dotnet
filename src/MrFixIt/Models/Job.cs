using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Completed = in the "still needed" functionality. Build this up
        public bool Completed { get; set; }
        //Pending = actively being worked on. Will need this for "Still needed" functionality"
        public bool Pending { get; set; }

        //One-To-Many relationship between Job and Worker
        public virtual Worker Worker { get; set; }

        public Worker FindWorker(string UserName)
        {
            Worker thisWorker = new MrFixItContext().Workers.FirstOrDefault(i => i.UserName == UserName);
            return thisWorker;
        }
    }
}
