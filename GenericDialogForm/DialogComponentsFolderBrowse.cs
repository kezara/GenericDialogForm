using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericDialogForm
{
    public partial class DialogComponentsFolderBrowse : UserControl, IDialogComponents
    {
        private string _pathSelected;

        public string PathSelected
        {
            get
            {
                _pathSelected = textBox1.Text;
                return _pathSelected;
            }
            private set { _pathSelected = value; }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">List of strings that represent label, texbox and button text</param>
        public DialogComponentsFolderBrowse(List<string> text)
        {
            InitializeComponent();
            label1.Text = text[0];
            textBox1.Text = text[1];
            button1.Text = text[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog
            {
                SelectedPath = textBox1.Text
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderDialog.SelectedPath;
            }
        }

        public void SetLocation(Point location)
        {
            Location = location;
        }

        public Point GetLocation()
        {
            return Location;
        }
    }
}
