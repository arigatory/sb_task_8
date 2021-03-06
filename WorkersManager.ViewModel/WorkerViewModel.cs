using WorkersManager.Common.DataProvider;
using WorkersManager.Common.Model;
using WorkersManager.ViewModel.Command;

namespace WorkersManager.ViewModel
{
    public class WorkerViewModel : ViewModelBase
    {
        private readonly Worker _worker;
        private readonly IWorkersDataProvider _workersDataProvider;

        public WorkerViewModel(Worker worker, IWorkersDataProvider workersDataProvider)
        {
            _worker = worker;
            _workersDataProvider = workersDataProvider;
        }


        public string FirstName
        {
            get => _worker.FirstName;
            set
            {
                if (_worker.FirstName != value)
                {
                    _worker.FirstName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanSave));
                }
            }
        }

        public string LastName
        {
            get => _worker.LastName;
            set
            {
                if (_worker.LastName != value)
                {
                    _worker.LastName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Age
        {
            get => _worker.Age;
            set
            {
                if (_worker.Age != value)
                {
                    _worker.Age = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int DepartmentId
        {
            get => _worker.DepartmentId;
            set
            {
                if (_worker.DepartmentId != value)
                {
                    _worker.DepartmentId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Salary
        {
            get => _worker.Salary;
            set
            {
                if (_worker.Salary != value)
                {
                    _worker.Salary = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool CanSave => !string.IsNullOrEmpty(FirstName);

        public Worker Worker => _worker;
    }
}
