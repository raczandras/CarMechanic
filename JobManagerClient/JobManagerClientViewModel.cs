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


namespace JobManagerClient
{
    public class JobManagerClientViewModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddJob()
        {
            DataValidator dataValidator = new DataValidator();

            if (name == null || carType == null || licensePlate == null || faliure == null)
            {
                MessageBox.Show("Egyetlen mezőt se hagyjon üresen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!(licensePlate.Length == 6 || licensePlate.Length == 7))
            {
                MessageBox.Show("A rendszám formátuma: AAA000 vagy AAA-000 lehet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                name = dataValidator.correctName(name);
                licensePlate = dataValidator.correctLicensePlate(licensePlate);

                if (dataValidator.checkData(name, licensePlate))
                {
                    Job job = new Job(name, carType, licensePlate, faliure);
                    Jobs.Insert(0, job);
                    clearTextBoxes();
                }
            }
        
        }

        private void clearTextBoxes()
        {
            name = string.Empty;
            PropertyChanged(this, new PropertyChangedEventArgs("name"));

            carType = string.Empty;
            PropertyChanged(this, new PropertyChangedEventArgs("carType"));

            licensePlate = string.Empty;
            PropertyChanged(this, new PropertyChangedEventArgs("licensePlate"));

            faliure = string.Empty;
            PropertyChanged(this, new PropertyChangedEventArgs("faliure"));
        }

        private void DeleteJob()
        {   
            if (SelectedJob >= 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Biztosan törölni szeretné?", "Törlés", buttons, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Jobs.Remove(Jobs.ElementAt(SelectedJob));
                }
            }
        }

        private void EditJob()
        {
            if( SelectedJob >= 0)
            {
                int selected = SelectedJob;
                Jobs[selected] = EditForm.ShowDialog(Jobs[SelectedJob]);
                Jobs[selected].Refresh();
            }
            
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
