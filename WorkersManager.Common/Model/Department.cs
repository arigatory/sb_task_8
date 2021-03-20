using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersManager.Common.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset DateOfCreation { get; set; }
        public int NumberOfWorkers { get; set; }
    }
}
