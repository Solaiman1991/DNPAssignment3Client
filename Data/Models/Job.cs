using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginExample.Data.Models
{
    public class Job
    {
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}