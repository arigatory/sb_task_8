using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WorkersManager.Common.DataProvider;
using WorkersManager.Common.Model;

namespace WorkersManager.DataAccess
{
    public class WorkersDataProvider : IWorkersDataProvider
    {
        public IEnumerable<Department> LoadDepartments()
        {
            return new List<Department>
            {
                new Department 
                {
                    Id = 1, 
                    Title = "Департамент разработки", 
                    DateOfCreation = new DateTime(year: 2009, month: 1, day: 15)
                },
                new Department
                {
                    Id = 2,
                    Title = "Отдел администрирования",
                    DateOfCreation = new DateTime(year: 2000, month: 1, day: 15)
                },
                new Department
                {
                    Id = 3,
                    Title = "Подразделение маркетологов",
                    DateOfCreation = new DateTime(year: 2010, month: 1, day: 15)
                },
                new Department
                {
                    Id = 4,
                    Title = "Совет директоров",
                    DateOfCreation = new DateTime(year: 1999, month: 1, day: 10)
                },

            };

        }

        public IEnumerable<Worker> LoadWorkers()
        {
            return new List<Worker>
            {
                new Worker
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Age = 30,
                    DepartmentId = 1,
                    Salary = 160_000
                },
                new Worker
                {
                    Id = 2,
                    FirstName = "Елена",
                    LastName = "Петрова",
                    Age = 35,
                    DepartmentId = 2,
                    Salary = 200_000
                }
            };
        }

        public void SaveWorker(Worker worker)
        {
            Debug.WriteLine($"Сохранен следующий рабочий: {worker.FirstName} {worker.LastName}");
        }
    }
}
