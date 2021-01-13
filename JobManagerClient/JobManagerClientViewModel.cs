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
using JobManagerClient.DataProviders;


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
            if( checkData())
            {
                Job job = new Job(name, carType, licensePlate, faliure);
                Jobs.Insert(0, job);
                JobDataProvider.CreateJob(job);
                clearTextBoxes();
            }          
        }

        private bool checkData()
        {   
            if( name == null || carType == null || licensePlate == null || faliure == null)
            {
                MessageBox.Show("Egyetlen mezőt se hagyjon üresen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return checkLicensePlate() && checkName();
           
        }

        private bool checkName()
        {
            name = name.Trim();
            
            if( !name.Contains(" "))
            {
                MessageBox.Show("A névnek tartalmaznia kell legalább egy szóközt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            string[] nameList = name.Split(" ");
            name = "";

            for( int i = 0; i< nameList.Length; i++)
            {
                name += char.ToUpper(nameList[i][0]) + nameList[i].Substring(1) + " ";
            }

            name = name.Trim();

            return true;
        }

        private bool checkLicensePlate()
        {
            if( ! (licensePlate.Length == 6 || licensePlate.Length == 7) )
            {
                MessageBox.Show("A rendszám formátuma: AAA000 vagy AAA-000 lehet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ( licensePlate.Substring(3, 1) != "-")
            {

                licensePlate = licensePlate.Substring(0, 3) + "-" + licensePlate.Substring(3, 3);
            }

            licensePlate = licensePlate.ToUpper();

            for (int i = 0; i < 3; i++)
            {
                int j = i + 4;

                if (!char.IsLetter(licensePlate, i) || !char.IsDigit(licensePlate, j))
                {
                    MessageBox.Show("A rendszám formátuma: AAA000 vagy AAA-000 lehet", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            

            return true;
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
                    JobDataProvider.DeleteJob(Jobs.ElementAt(SelectedJob).Id);
                }
            }
        }

        private void EditJob()
        {

        }


        public JobManagerClientViewModel()
        {
            Jobs = new ObservableCollection<Job>(JobDataProvider.GetJobs());
            AddJobCommand = new DelegateCommand(AddJob);
            DeleteJobCommand = new DelegateCommand(DeleteJob);
            EditJobCommand = new DelegateCommand(EditJob);
        }

      

    }
}
