using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagerClient
{
    public class Job
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string CarType { get; set; }

        public string LicensePlate { get; set; }

        public string Failure { get; set; }

        public Job(int id, DateTime date, string name, string carType, string licensePlate, string failure)
        {
            Id = id;
            Date = date;
            Name = name;
            CarType = carType;
            LicensePlate = licensePlate;
            Failure = failure;
        }

        public Job(string name, string carType, string licensePlate, string failure)
        {
            Id = 0;
            Date = DateTime.Now;
            Name = name;
            CarType = carType;
            LicensePlate = licensePlate;
            Failure = failure;
        }

        public Job()
        {
        }
    }
}
