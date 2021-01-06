using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.VisualStudio.PlatformUI;


namespace JobManagerClient
{
    public class JobManagerClientViewModel
    {
        public ICommand AddJobCommand { get; }

        public ICommand DeleteJobCommand { get; }

        public ICommand EditJobCommand { get; }

        public int SelectedJob { get; set; }

        public string name { get; set; }

        public string carType { get; set; }

        public string licensePlate { get; set; }

        public string faliure { get; set; }

        public ObservableCollection<Job> Jobs { get; }

        private void AddJob()
        {
            Job job = new Job(name, carType, licensePlate, faliure);
            Jobs.Insert(0,job);
        }

        private void DeleteJob()
        {
            if (SelectedJob >= 0)
            {
                Jobs.Remove(Jobs.ElementAt(SelectedJob));
            }
        }

        private void EditJob()
        {

        }


        public JobManagerClientViewModel()
        {
            Jobs = new ObservableCollection<Job>();
            AddJobCommand = new DelegateCommand(AddJob);
            DeleteJobCommand = new DelegateCommand(DeleteJob);
            EditJobCommand = new DelegateCommand(EditJob);
        }

    }
}
