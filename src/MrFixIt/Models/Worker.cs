using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Available should change to false when they claim a job
        public bool Avaliable { get; set; }
        public string UserName { get; set; }
        //this comes from Identity.User

        //One-To-Many relationship with Jobs (one worker has many jobs)
        public virtual ICollection<Job> Jobs { get; set; }

        //constructor, with available set to true (which will need to be changed when a worker claims a job)
        public Worker()
        {
            Avaliable = true;
        }

    }
}