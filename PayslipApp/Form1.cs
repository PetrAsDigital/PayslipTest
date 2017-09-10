using Ninject;
using PayslipLib;
using ReaderLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PayslipApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _fileName;
        private string[] _fileContent;

        public IReader reader { get { return NinjectBindings.kernel.Get<IReader>(); } }
        public IPayCalc payCalc { get { return NinjectBindings.kernel.Get<IPayCalc>(); } }


        private void buttonInput_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                InitialDirectory = Application.ExecutablePath
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _fileContent = File.ReadAllLines(dialog.FileName);
                    _fileName = Path.GetFileName(dialog.FileName);

                    labelInput.Text = _fileName;
                    if (!labelInput.Visible)
                        labelInput.Visible = true;
                }
                catch(IOException ex)
                {
                    MessageBox.Show($"exError: Could not read file from disk. Original error: {ex.Message}");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"General exception: {ex.Message}");
                }
            }

            MessageBox.Show("File uploaded successfully");
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            if (!CheckAll())
                return;

            var allPersons = reader.ReadAllPersons(_fileContent);
            allPersons = payCalc.ProcessAllPersons(allPersons);

            SaveToFile(allPersons);
        }

        private bool CheckAll()
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                MessageBox.Show("First choose an input csv file...");
                return false;
            }

            if (!_fileContent.Any())
            {
                MessageBox.Show($"Selected file {_fileName} is empty...");
                return false;
            }

            return true;
        }

        private void SaveToFile(List<IPerson> allPersons)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Name,Pay period,Gross income,Income tax,Net income,Super");
            allPersons.Select(a => csv.AppendLine($"{a.FirstName} {a.LastName},{string.Format("{0:dd MMM}", a.PaymentStartDate)} - {string.Format("{0:dd MMM}", a.PaymentEndDate)},{a.GrossIncome},{a.IncomeTax},{a.NetIncome},{a.Super}")).ToList();

            var dialog = new SaveFileDialog()
            {
                FileName = "Output.csv",
                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                InitialDirectory = Application.ExecutablePath
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, csv.ToString());
                MessageBox.Show($"File {Path.GetFileName(dialog.FileName)} has been saved");
            }
        }
    }
}
