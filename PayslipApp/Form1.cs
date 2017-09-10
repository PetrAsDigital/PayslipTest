using PayslipLib;
using ReaderLib;
using ReaderLib.Classes;
using System;
using System.IO;
using System.Linq;
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

        private IReader reader = new CsvReader();
        private IPayCalc payCalc = new PayCalc_2017();


        private void buttonInput_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"..\..\InputFiles")
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
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                MessageBox.Show("First choose an input csv file...");
                return;
            }

            if (!_fileContent.Any())
            {
                MessageBox.Show($"Selected file {_fileName} is empty...");
                return;
            }

            var allPersons = reader.ReadAllPersons(_fileContent);

            if (allPersons == null || allPersons.Count < 1)
                MessageBox.Show("No content to process");

            allPersons = payCalc.ProcessAllPersons(allPersons);

            if (allPersons == null)
                return;

            //var dialog = new SaveFileDialog()
            //{
            //    DefaultExt = "csv",
            //    Filter = "csv files (*.csv)|All files (*.*)|*.*",
            //    InitialDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"InputFiles")
            //};

        }
    }
}
