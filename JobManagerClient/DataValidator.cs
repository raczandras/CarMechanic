using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobManagerClient
{
    public class DataValidator
    {

        public string correctName(string name)
        {
            name = name.Trim();

            string[] nameList = name.Split(" ");
            name = "";

            for (int i = 0; i < nameList.Length; i++)
            {
                name += char.ToUpper(nameList[i][0]) + nameList[i].Substring(1) + " ";
            }

            name = name.Trim();

            return name;
        }

        public string correctLicensePlate(string licensePlate)
        {
            if (licensePlate.Substring(3, 1) != "-")
            {
                licensePlate = licensePlate.Substring(0, 3).ToUpper() + "-" + licensePlate.Substring(3, 3);
            }

            return licensePlate;
        }

        public bool checkName(string name)
        {
            if (!name.Contains(" "))
            {
                return false;
            }

            return true;
        }

        public bool checkLicensePlate(string licensePlate)
        {

            licensePlate = licensePlate.ToUpper();

            for (int i = 0; i < 3; i++)
            {
                int j = i + 4;

                if (!char.IsLetter(licensePlate, i) || !char.IsDigit(licensePlate, j))
                {
                    
                    return false;
                }
            }

            return true;
        }
    }
}
