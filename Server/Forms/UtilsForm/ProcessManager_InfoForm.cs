using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms.UtilsForm
{
    public partial class ProcessManager_InfoForm : Form
    {
        public ProcessManager_InfoForm()
        {
            InitializeComponent();
        }

        private void saveInfoBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, processInfoTxtBx.Text);
            }
        }

        private void saveIconBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Png Files (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    processIcon.Image.Save(memoryStream, ImageFormat.Png);
                    File.WriteAllBytes(saveFileDialog.FileName, memoryStream.ToArray());
                }
            }
        }
    }
}
