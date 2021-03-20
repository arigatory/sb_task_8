using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersManager.Common.Model
{
    public class Worker
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
    }
}
