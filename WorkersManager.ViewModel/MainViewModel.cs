using System.Collections.ObjectModel;
using WorkersManager.Common.DataProvider;
using WorkersManager.Common.Model;

namespace WorkersManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private WorkerViewModel _selectedWorker;
        private readonly IWorkersDataProvider _workerDataProvider;

        public MainViewModel(IWorkersDataProvider workerDataProvider)
        {
            _workerDataProvider = workerDataProvider;
        }

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
        }
    }
}
