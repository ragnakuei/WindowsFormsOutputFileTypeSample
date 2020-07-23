using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var outputFileBtnMap = new OutputFileMapDTO[]
                                   {
                                       new OutputFileMapDTO { Button = btnTxt, FileType  = FileType.Txt, GetValueAction  = GenerateTxt },
                                       new OutputFileMapDTO { Button = btnCsv, FileType  = FileType.Csv, GetValueAction  = GenerateCsv },
                                       new OutputFileMapDTO { Button = btnXml, FileType  = FileType.Xml, GetValueAction  = GenerateXml },
                                       new OutputFileMapDTO { Button = btnJson, FileType = FileType.Json, GetValueAction = GenerateJson },
                                   };
            cbxOutputFiles.DisplayMember = nameof(OutputFileMapDTO.FileType);
            cbxOutputFiles.ValueMember   = nameof(OutputFileMapDTO.GetValueAction);

            foreach (var outputFileMapDto in outputFileBtnMap)
            {
                outputFileMapDto.Button.Tag = outputFileMapDto;
                cbxOutputFiles.Items.Add(outputFileMapDto);
            }
        }

        private void OutputFileType(object sender, EventArgs e)
        {
            var target = (sender as Button)?.Tag as OutputFileMapDTO;
            OutputFile(target);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var cbxOutputFilesSelectedItem = cbxOutputFiles.SelectedItem as OutputFileMapDTO;
            OutputFile(cbxOutputFilesSelectedItem);
        }

        private static void OutputFile(OutputFileMapDTO target)
        {
            var targetFileType = target.GetValueAction.Invoke();
            MessageBox.Show(targetFileType);
        }

        private string GenerateTxt()
        {
            return "txt";
        }

        private string GenerateCsv()
        {
            return "csv";
        }

        private string GenerateXml()
        {
            return "xml";
        }

        private string GenerateJson()
        {
            return "json";
        }
    }
}
