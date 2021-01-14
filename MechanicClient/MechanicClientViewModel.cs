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
    public class MechanicClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RecordedJobCommand { get; }

        public ICommand WorkingOnJobCommand { get; }

        public ICommand CompletedJobCommand { get; }

        public int SelectedJob { get; set; }

        public ObservableCollection<Job> Jobs { get; }

        public MechanicClientViewModel()
        {
            Jobs = new ObservableCollection<Job>();
            RecordedJobCommand = new DelegateCommand(SetToRecorded);
            WorkingOnJobCommand = new DelegateCommand(SetToWorkingOn);
            CompletedJobCommand = new DelegateCommand(SetToCompleted);
        }

        private void SetToCompleted(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elkészült";
        }

        private void SetToWorkingOn(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elvégzés alatt áll";
        }

        private void SetToRecorded(object obj)
        {
            int selected = SelectedJob;
            Jobs[selected].State = "Elvégzésre vár";
        }
    }
}
