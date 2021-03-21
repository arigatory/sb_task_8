using System;
using System.Collections.Generic;
using System.Text;
using WorkersManager.Common.Model;

namespace WorkersManager.Common.DataProvider
{
    public interface IWorkersDataProvider
    {
        IEnumerable<Worker> LoadWorkers();

        void Save(IEnumerable<Worker> workers, IEnumerable<Department> departments);

        IEnumerable<Department> LoadDepartments();
    }
}
