using System.Collections.ObjectModel;
using System.Linq;
using WorkersManager.Common.DataProvider;
using WorkersManager.Common.Model;
using WorkersManager.ViewModel.Command;

namespace WorkersManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private WorkerViewModel _selectedWorker;
        private readonly IWorkersDataProvider _workerDataProvider;

        public MainViewModel(IWorkersDataProvider workerDataProvider)
        {
            _workerDataProvider = workerDataProvider;
            Load();
            LoadCommand = new DelegateCommand(Load);
            SaveCommand = new DelegateCommand(Save);

        }
        public DelegateCommand LoadCommand { get; }
        public DelegateCommand SaveCommand { get; }

        public ObservableCollection<WorkerViewModel> Workers { get; } = new();
        public ObservableCollection<Department> Departments { get; } = new();

        public WorkerViewModel SelectedWorker
        {
            get { return _selectedWorker; }
            set
            {
                if (_selectedWorker != value)
                {
                    _selectedWorker = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsWorkerSelected));
                }
            }
        }

        public bool IsWorkerSelected => SelectedWorker != null;
        public bool CanBeSorted => Workers.Count > 1;


        public void Load()
        {
            var workers = _workerDataProvider.LoadWorkers();
            var departments = _workerDataProvider.LoadDepartments();

            Workers.Clear();
            foreach (var worker in workers)
            {
                Workers.Add(new WorkerViewModel(worker, _workerDataProvider));
            }

            Departments.Clear();
            foreach (var department in departments)
            {
                Departments.Add(department);
            }
            RaisePropertyChanged(nameof(CanBeSorted));
        }

        public void Add()
        {
            var newWorker = new WorkerViewModel(new Worker { LastName = "Новый", FirstName = "работник", Age=20, DepartmentId=1, Id=5, Salary=55000 }, _workerDataProvider);
            Workers.Add(newWorker);
            SelectedWorker = newWorker;
            RaisePropertyChanged(nameof(CanBeSorted));
        }

        public void Delete()
        {
            if (SelectedWorker!=null)
            {
                Workers.Remove(SelectedWorker);
                RaisePropertyChanged(nameof(CanBeSorted));
            }
        }

        public void SortWorkersByName()
        {
            var sortedWorkers = Workers.OrderBy(w => w.FirstName).ToList();
            Workers.Clear();
            foreach (var worker in sortedWorkers)
            {
                Workers.Add(worker);
            }
        }

        public void SortWorkersByLastName()
        {
            var sortedWorkers = Workers.OrderBy(w => w.LastName).ToList();
            Workers.Clear();
            foreach (var worker in sortedWorkers)
            {
                Workers.Add(worker);
            }
        }

        public void SortWorkersBySalary()
        {
            var sortedWorkers = Workers.OrderBy(w => w.Salary).ToList();
            Workers.Clear();
            foreach (var worker in sortedWorkers)
            {
                Workers.Add(worker);
            }
        }

        public void Save()
        {
            _workerDataProvider.Save(Workers.Select(w=>w.Worker), Departments);
        }
    }
}
