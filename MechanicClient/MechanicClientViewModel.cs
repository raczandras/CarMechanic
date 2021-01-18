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
using MechanicClient.DataProviders;

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
            Jobs = new ObservableCollection<Job>(JobDataProvider.GetJobs().Reverse());
            RecordedJob = new DelegateCommand(SetToRecorded);
            WorkingOnJob = new DelegateCommand(SetToWorkingOn);
            CompletedJob = new DelegateCommand(SetToCompleted);
        }

        private void SetToCompleted(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elkészült";
            Jobs[selected].Refresh();
            JobDataProvider.UpdateJob(Jobs[selected]);
        }

        private void SetToWorkingOn(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elvégzés alatt áll";
            Jobs[selected].Refresh();
            JobDataProvider.UpdateJob(Jobs[selected]);
        }

        private void SetToRecorded(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elvégzésre vár";
            Jobs[selected].Refresh();
            JobDataProvider.UpdateJob(Jobs[selected]);
        }
    }
}
