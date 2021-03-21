using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using WorkersManager.Common.DataProvider;
using WorkersManager.Common.Model;

namespace WorkersManager.DataAccess
{
    public class WorkersDataProvider : IWorkersDataProvider
    {
        private static readonly string _workersFileName = "workers.json";
        private static readonly string _departmentsFileName = "departments.json";


        public IEnumerable<Department> LoadDepartments()
        {
            IEnumerable<Department> departmentList;
            if (!File.Exists(_workersFileName))
            {
                departmentList = new List<Department>
                {
                    new Department
                    {
                        Id = 1,
                        Title = "Департамент разработки",
                        DateOfCreation = new DateTime(year: 2009, month: 1, day: 15),
                        Workers = LoadWorkersFromDepartment(1)
                    },
                    new Department
                    {
                        Id = 2,
                        Title = "Отдел администрирования",
                        DateOfCreation = new DateTime(year: 2000, month: 1, day: 15),
                        Workers = LoadWorkersFromDepartment(1)
                    },
                    new Department
                    {
                        Id = 3,
                        Title = "Подразделение маркетологов",
                        DateOfCreation = new DateTime(year: 2010, month: 1, day: 15),
                        Workers = LoadWorkersFromDepartment(1)
                    },
                    new Department
                    {
                        Id = 4,
                        Title = "Совет директоров",
                        DateOfCreation = new DateTime(year: 1999, month: 1, day: 10),
                        Workers = LoadWorkersFromDepartment(1)
                    },
                };
            }
            else
            {
                var json = File.ReadAllText(_departmentsFileName);
                departmentList = JsonConvert.DeserializeObject<List<Department>>(json);
            }
            return departmentList;
        }

        private List<Worker> LoadWorkersFromDepartment(int id)
        {
            return LoadWorkers().Where(w => w.DepartmentId == id).ToList();
        }

        public IEnumerable<Worker> LoadWorkers()
        {
            IEnumerable<Worker> workerList;
            if (!File.Exists(_workersFileName))
            {
                workerList = new List<Worker>
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
            else
            {
                var json = File.ReadAllText(_workersFileName);
                workerList = JsonConvert.DeserializeObject<List<Worker>>(json);
            }
            return workerList;
        }

        public void Save(IEnumerable<Worker> workers, IEnumerable<Department> departments)
        {
            var json = JsonConvert.SerializeObject(workers, Formatting.Indented);
            File.WriteAllText(_workersFileName, json);
            Debug.WriteLine($"Сохранен следующий рабочих: {workers.Count()}");
            json = JsonConvert.SerializeObject(departments, Formatting.Indented);
            File.WriteAllText(_departmentsFileName, json);
            Debug.WriteLine($"Сохранен следующий департаментов: {departments.Count()}");
        }
    }
}
