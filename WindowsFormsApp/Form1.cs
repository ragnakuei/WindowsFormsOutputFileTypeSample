using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.GenerateFile;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var outputFileBtnMap = new OutputFileMapDTO[]
                                   {
                                       new OutputFileMapDTO { Button = btnTxt, FileType  = FileType.Txt },
                                       new OutputFileMapDTO { Button = btnCsv, FileType  = FileType.Csv },
                                       new OutputFileMapDTO { Button = btnXml, FileType  = FileType.Xml },
                                       new OutputFileMapDTO { Button = btnJson, FileType = FileType.Json },
                                   };
            cbxOutputFiles.DisplayMember = nameof(OutputFileMapDTO.FileType);

            foreach (var outputFileMapDto in outputFileBtnMap)
            {
                outputFileMapDto.Button.Tag = outputFileMapDto;
                cbxOutputFiles.Items.Add(outputFileMapDto);
            }
        }

        private void OutputFileType(object sender, EventArgs e)
        {
            if (sender is Button btn
             && btn.Tag is OutputFileMapDTO target)
            {
                OutputFile(target);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var cbxOutputFilesSelectedItem = cbxOutputFiles.SelectedItem as OutputFileMapDTO;
            OutputFile(cbxOutputFilesSelectedItem);
        }

        private static void OutputFile(OutputFileMapDTO target)
        {
            var generateFile   = new GenerateFileFactory().Create(target.FileType);
            var targetFileType = generateFile.Generate();
            MessageBox.Show(targetFileType);
        }
    }
}
