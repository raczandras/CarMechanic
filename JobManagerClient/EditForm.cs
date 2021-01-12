using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JobManagerClient
{
    public static class EditForm
    {
        public static Job ShowDialog(Job job)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                Text = "Szerkesztés",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label nameLabel = new Label() { Left = 50, Top = 10, Text = "Név:", Height = 20 };
            TextBox nameBox = new TextBox() { Left = 50, Top = 30, Width = 400, Text=job.Name };

            Label carTypeLabel = new Label() { Left = 50, Top = 60, Text = "Autótípus:", Height = 20 };
            TextBox carTypeBox = new TextBox() { Left = 50, Top = 80, Width = 400, Text=job.CarType };

            Label licensePlateLabel = new Label() { Left = 50, Top = 110, Text = "Rendszám:", Height = 20 };
            TextBox licensePlateBox = new TextBox() { Left = 50, Top = 130, Width = 400, Text=job.LicensePlate };

            Label faliureLabel = new Label() { Left = 50, Top = 160, Text = "Hiba:", Height = 20 };
            TextBox faliureBox = new TextBox() { Left = 50, Top = 180, Width = 400, Text=job.Failure };


            Button ok = new Button() { Text = "Mentés", Left = 50, Width = 100, Top = 230, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Mégse", Left = 350, Width = 100, Top = 230, DialogResult = DialogResult.Cancel };

            

            prompt.Controls.Add(nameLabel);
            prompt.Controls.Add(nameBox);
            prompt.Controls.Add(carTypeLabel);
            prompt.Controls.Add(carTypeBox);
            prompt.Controls.Add(licensePlateLabel);
            prompt.Controls.Add(licensePlateBox);
            prompt.Controls.Add(faliureLabel);
            prompt.Controls.Add(faliureBox);
            prompt.Controls.Add(ok);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            DialogResult result = prompt.ShowDialog();

            if( result == DialogResult.OK)
            {
                string name = nameBox.Text;
                string carType = carTypeBox.Text;
                string licensePlate = licensePlateBox.Text;
                string faliure = faliureBox.Text;

                if (name.Length == 0 || carType.Length == 0 || licensePlate.Length == 0 || faliure.Length == 0)
                {
                    MessageBox.Show("Egyetlen mezőt se hagyjon üresen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ShowDialog(job);
                }

                else if (!(licensePlate.Length == 6 || licensePlate.Length == 7))
                {
                    MessageBox.Show("A rendszám formátuma: AAA000 vagy AAA-000 lehet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ShowDialog(job);
                }
                else
                {
                    DataValidator dataValidator = new DataValidator();
                    name = dataValidator.correctName(name);
                    licensePlate = dataValidator.correctLicensePlate(licensePlate);

                    if (dataValidator.checkName(name))
                    {
                        if (dataValidator.checkLicensePlate(licensePlate))
                        {
                            job.Name = name;
                            job.CarType = carType;
                            job.LicensePlate = licensePlate;
                            job.Failure = faliure;
                            return job;
                        }
                        else
                        {
                            MessageBox.Show("A rendszám formátuma: AAA000 vagy AAA-000 lehet", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return ShowDialog(job);
                        }
                    }
                    else
                    {
                        MessageBox.Show("A névnek tartalmaznia kell legalább egy vezetéknevet és egy keresztnevet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ShowDialog(job);
                    }
                }
            }

            return job;
        }
    }
}
