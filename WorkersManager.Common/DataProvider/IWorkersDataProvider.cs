using System;
using System.Collections.Generic;
using System.Text;
using WorkersManager.Common.Model;

namespace WorkersManager.Common.DataProvider
{
    public interface IWorkersDataProvider
    {
        IEnumerable<Worker> LoadWorkers();

        void SaveWorker(Worker worker);

        IEnumerable<Department> LoadDepartments();
    }
}
