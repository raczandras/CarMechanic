using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MechanicClient
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

        public Job()
        {
        }

        public void Refresh()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("State"));
            
        }
    }
}
