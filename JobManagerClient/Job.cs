using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.PlatformUI;
using System.ComponentModel;

namespace JobManagerClient
{
    public class Job : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }
       

        public string CarType { get; set; }

        public string LicensePlate { get; set; }

        public string Failure { get; set; }

        public string State { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Job(int id, DateTime date, string name, string carType, string licensePlate, string failure, string state)
        {
            Id = id;
            Date = date;
            Name = name;
            CarType = carType;
            LicensePlate = licensePlate;
            Failure = failure;
            State = state;
        }

        public Job(string name, string carType, string licensePlate, string failure)
        {
            Id = 0;
            Date = DateTime.Now;
            Name = name;
            CarType = carType;
            LicensePlate = licensePlate;
            Failure = failure;
            State = "Elvégzésre vár";
        }

        public void Refresh()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("name"));
            PropertyChanged(this, new PropertyChangedEventArgs("CarType"));
            PropertyChanged(this, new PropertyChangedEventArgs("LicensePlate"));
            PropertyChanged(this, new PropertyChangedEventArgs("Failure"));
        }


    }
}
