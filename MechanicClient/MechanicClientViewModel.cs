using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.VisualStudio.PlatformUI;
using System.ComponentModel;
using System.Windows.Forms;

namespace MechanicClient
{
    public class MechanicClientViewModel
    {

        public ICommand RecordedJob { get; }

        public ICommand WorkingOnJob { get; }

        public ICommand CompletedJob { get; }

        public int SelectedJob { get; set; }

        public ObservableCollection<Job> Jobs { get; }

        public MechanicClientViewModel()
        {
            Jobs = new ObservableCollection<Job>();
            Job job = new Job(0, DateTime.Now, "Rácz András", "Suzuki swift", "FFB-550", "Motorhiba", "Elvégzésre vár");
            Job job2 = new Job(0, DateTime.Now, "Rácz András", "Suzuki swift", "FFB-550", "Motorhiba", "Elvégzésre vár");
            Job job3 = new Job(0, DateTime.Now, "Rácz András", "Suzuki swift", "FFB-550", "Motorhiba", "Elvégzésre vár");
            Job job4 = new Job(0, DateTime.Now, "Rácz András", "Suzuki swift", "FFB-550", "Motorhiba", "Elvégzésre vár");
            Job job5 = new Job(0, DateTime.Now, "Rácz András", "Suzuki swift", "FFB-550", "Motorhiba", "Elvégzésre vár");

            Jobs.Add(job);
            Jobs.Add(job2);
            Jobs.Add(job3);
            Jobs.Add(job4);
            Jobs.Add(job5);


            RecordedJob = new DelegateCommand(SetToRecorded);
            WorkingOnJob = new DelegateCommand(SetToWorkingOn);
            CompletedJob = new DelegateCommand(SetToCompleted);
        }

        private void SetToCompleted(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elkészült";
            Jobs[selected].Refresh();
          
        }

        private void SetToWorkingOn(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elvégzés alatt áll";
            Jobs[selected].Refresh();
        }

        private void SetToRecorded(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elvégzésre vár";
            Jobs[selected].Refresh();
        }
    }
}
